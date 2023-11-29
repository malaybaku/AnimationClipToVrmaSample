using System;
using System.Collections.Generic;
using System.IO;
using UniGLTF;
using UnityEngine;
using UniVRM10;

namespace Baxter
{
    public class HumanoidAnimationToVrma : MonoBehaviour
    {
        private const float Frequency = 30f;

        //Animationコンポーネント不要にできる？というかAnimatorと両立できなくない？
        [SerializeField] private Animator humanoid;
        [SerializeField] private AnimationClip clip;

        private Animator animationTarget;
        private bool runAnimation;
        private float time;
        
        private void Start()
        {
            //BuildAndShowTempHumanoidWithDebugRenderer();
            ExportAnimByRuntimeCreateHumanoid();
        }

        private void ExportAnimByExitingModel()
        {
             var path = Path.Combine(
                 Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                 "test_scene_model.vrma"
                 );
            var bytes = CreateVrmAnimation(humanoid, clip);
            File.WriteAllBytes(path, bytes);          
        }

        private void BuildAndShowTempHumanoidWithDebugRenderer()
        {
            var tempHumanoid = ReferenceHumanoid.CreateHumanoid();
            HumanBoneVisualizer.Setup(tempHumanoid.transform);
        }
        
        private void ExportAnimByRuntimeCreateHumanoid()
        {
            var path = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                "test_runtime_humanoid.vrma"
                );
            var tempHumanoid = ReferenceHumanoid.CreateHumanoid();
            var bytes = CreateVrmAnimation(tempHumanoid, clip);
            File.WriteAllBytes(path, bytes);
            Destroy(tempHumanoid.gameObject);
        }

        private void ExportBonePoseText()
        {
            var path = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                "bone_literal.txt"
                );
            var lines = BonePoseScriptWriter.CreateBoneAndLocalPoseDataMap(humanoid);
            File.WriteAllLines(path, lines);
        }
        
        private static byte[] CreateVrmAnimation(
            Animator humanoid, AnimationClip clip
            )
        {
            var data = new ExportingGltfData();
            using var exporter = new VrmAnimationExporter(data, new GltfExportSettings());
            exporter.Prepare(humanoid.gameObject);
            
            exporter.Export(vrma =>
            {
                var map = new Dictionary<HumanBodyBones, Transform>();
                foreach (HumanBodyBones bone in Enum.GetValues(typeof(HumanBodyBones)))
                {
                    if (bone == HumanBodyBones.LastBone)
                    {
                        continue;
                    }

                    var t = humanoid.GetBoneTransform(bone);
                    if (t == null)
                    {
                        continue;
                    }

                    map.Add(bone, t);
                }

                var hips = map[HumanBodyBones.Hips];

                var rootTransform = humanoid.avatarRoot.transform;
                vrma.SetPositionBoneAndParent(map[HumanBodyBones.Hips], rootTransform);
                
                foreach (var kv in map)
                {
                    var vrmBone = Vrm10HumanoidBoneSpecification.ConvertFromUnityBone(kv.Key);
                    var parent = GetParentBone(map, vrmBone) ?? rootTransform;
                    vrma.AddRotationBoneAndParent(kv.Key, kv.Value, parent);
                }

                var go = humanoid.gameObject;
                var frameCount = Mathf.FloorToInt(clip.length * Frequency);

                for (var i = 0; i < frameCount; i++)
                {
                    var time = i / Frequency;
                    clip.SampleAnimation(go, time);
                    vrma.AddFrame(TimeSpan.FromSeconds(time));
                }
            });

            return data.ToGlbBytes();
        }
        
        private static Transform GetParentBone(Dictionary<HumanBodyBones, Transform> map, Vrm10HumanoidBones bone)
        {
            while (true)
            {
                if (bone == Vrm10HumanoidBones.Hips)
                {
                    break;
                }
                var parentBone = Vrm10HumanoidBoneSpecification.GetDefine(bone).ParentBone.Value;
                var unityParentBone = Vrm10HumanoidBoneSpecification.ConvertToUnityBone(parentBone);
                if (map.TryGetValue(unityParentBone, out var found))
                {
                    return found;
                }
                bone = parentBone;
            }

            // hips has no parent
            return null;
        }
    }
}