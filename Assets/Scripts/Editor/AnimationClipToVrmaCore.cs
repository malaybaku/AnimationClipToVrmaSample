using System;
using System.Collections.Generic;
using UniGLTF;
using UnityEngine;
using UniVRM10;

namespace Baxter
{
    /// <summary>
    /// AnimatorとAnimationClipからVRM Animationファイルのデータを出力する主機能。
    /// ウィンドウ / アセット右クリックのいずれの導線を用いる場合も、本クラスを用いて .vrma のバイナリを生成する。
    /// </summary>
    public static class AnimationClipToVrmaCore
    {
        private const float Frequency = 30f;
        
        /// <summary>
        /// 出力時のリファレンスになるHumanoidのアバターとHumanoid用Animationを指定することで、
        /// それを30FPSのVRM Animationバイナリに変換する。
        /// </summary>
        /// <param name="humanoid"></param>
        /// <param name="clip"></param>
        /// <returns></returns>
        public static byte[] Create(Animator humanoid, AnimationClip clip)
        {
            var data = new ExportingGltfData();
            using var exporter = new VrmAnimationExporter(data, new GltfExportSettings());
            exporter.Prepare(humanoid.gameObject);
            var go = humanoid.gameObject;

            exporter.Export(anim =>
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

                var rootTransform = humanoid.avatarRoot.transform;
                anim.SetPositionBoneAndParent(map[HumanBodyBones.Hips], rootTransform);
                
                foreach (var kv in map)
                {
                    var vrmBone = Vrm10HumanoidBoneSpecification.ConvertFromUnityBone(kv.Key);
                    var parent = GetParentBone(map, vrmBone) ?? rootTransform;
                    anim.AddRotationBoneAndParent(kv.Key, kv.Value, parent);
                }

                var frameCount = Mathf.FloorToInt(clip.length * Frequency);

                for (var i = 0; i < frameCount; i++)
                {
                    var time = i / Frequency;
                    clip.SampleAnimation(go, time);
                    anim.AddFrame(TimeSpan.FromSeconds(time));
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