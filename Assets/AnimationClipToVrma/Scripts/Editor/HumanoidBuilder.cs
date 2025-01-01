using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UniVRM10;

namespace Baxter
{
    /// <summary> ハードコードしたVRM Modelの骨格に基づいてアバターの骨格部分だけを動的生成するクラス </summary>
    public static class HumanoidBuilder
    {
        readonly struct BoneAndTransform
        {
            public HumanBodyBones Bone { get; }
            public Transform Transform { get; }

            public BoneAndTransform(HumanBodyBones bone, Transform transform)
            {
                Bone = bone;
                Transform = transform;
            }
            
            public SkeletonBone ToSkeletonBone()
            {
                return new SkeletonBone
                {
                    name = Transform.name,
                    position = Bone == HumanBodyBones.Hips ? Vector3.zero : Transform.localPosition,
                    rotation = Bone == HumanBodyBones.Hips ? Quaternion.identity : Transform.localRotation,
                    scale = Transform.localScale,
                };
            }

            public HumanBone ToHumanBone()
            {
                //NOTE:
                // 指関節のHumanTraitNameには(なぜか) "Right Thumb Proximal"のような区切りがあり、
                // HumanBodyBonesの名称と一致しないので、調整が必要
                var splitBySpace = ((int)Bone) >= (int)HumanBodyBones.LeftThumbProximal;
                var humanName = Transform.name;
                if (splitBySpace)
                {
                    var replace = new StringBuilder();
                    replace.Append(humanName[0]);
                    foreach (var c in humanName.Skip(1))
                    {
                        if (char.IsUpper(c))
                        {
                            replace.Append(' ');
                        }
                        replace.Append(c);
                    }
                    humanName = replace.ToString();
                }
            
                var hb = new HumanBone
                {
                    boneName = Transform.name,
                    humanName = humanName,
                };
                hb.limit.useDefaultValues = true;
                return hb;
            }                  
        }
        
        /// <summary>
        /// TポーズになっているHumanoidのAnimatorを指定することで、
        /// 同じポーズを取っているがボーン名が一律、かつHumanoidと関係ないボーンは削除されたようなAnimatorを持つGameObjectを
        /// 新規生成し、そのオブジェクトを返す。
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public static Animator CreateHumanoid(Animator src)
        {
            return CreateHumanoid(CreateLocalPoseMap(src));
        }
        
        /// <summary>
        /// TポーズになっているHumanoidのボーンのローカル姿勢一覧を渡すことで、
        /// 同じポーズを取っていてボーン名が一律、かつHumanoidと関係ないボーンは削除されたようなAnimatorを持つGameObjectを
        /// 新規生成し、そのオブジェクトを返す。
        ///
        /// Animatorのかわりにハードコードしたボーン情報をほぼそのまま保持している場合、この関数を直接呼び出す。
        /// </summary>
        /// <param name="boneLocalPoseMap"></param>
        /// <returns></returns>
        public static Animator CreateHumanoid(IReadOnlyDictionary<HumanBodyBones, Pose> boneLocalPoseMap)
        {
            var bones = boneLocalPoseMap
                .Select(pair =>
                {
                    var obj = new GameObject(pair.Key.ToString());
                    obj.transform.localPosition = pair.Value.position;
                    obj.transform.localRotation = pair.Value.rotation;
                    return new BoneAndTransform(pair.Key, obj.transform);
                })
                .ToArray();

            //階層構造をいい感じにしていく
            foreach (var bone in bones)
            {
                if (bone.Bone == HumanBodyBones.Hips)
                {
                    continue;
                }
            
                var vrm10Bone = Vrm10HumanoidBoneSpecification.ConvertFromUnityBone(bone.Bone);
                var parentVrm10Bone = Vrm10HumanoidBoneSpecification.GetDefine(vrm10Bone).ParentBone.Value;
                // NOTE: 任意ボーンがない場合は親への遡りで反復処理になることがある
                while (true)
                {
                    var parentBone = Vrm10HumanoidBoneSpecification.ConvertToUnityBone(parentVrm10Bone);
                    var parentBoneItem = bones.FirstOrDefault(b => b.Bone == parentBone);
                    if (parentBoneItem.Transform != null)
                    {
                        bone.Transform.SetParent(parentBoneItem.Transform, false);
                        break;
                    }
                    parentVrm10Bone = Vrm10HumanoidBoneSpecification.GetDefine(parentVrm10Bone).ParentBone.Value;
                }
            }

            var root = new GameObject("root");
            root.transform.localPosition = Vector3.zero;
            root.transform.localRotation = Quaternion.identity;

            var hips = bones.First(b => b.Bone == HumanBodyBones.Hips);
            hips.Transform.SetParent(root.transform, false);
            
            var humanDescription = new HumanDescription()
            {
                skeleton = bones.Select(b => b.ToSkeletonBone()).ToArray(),
                human = bones.Select(b => b.ToHumanBone()).ToArray(),
                armStretch = 0.05f,
                legStretch = 0.05f,
                upperArmTwist = 0.5f,
                lowerArmTwist = 0.5f,
                upperLegTwist = 0.5f,
                lowerLegTwist = 0.5f,
                feetSpacing = 0,
                hasTranslationDoF = false,
            };

            // これらの改変は不要
            // hips.Transform.localPosition = Vector3.zero;
            // hips.Transform.localRotation = Quaternion.identity;
            var animator = root.AddComponent<Animator>();
            animator.avatar = AvatarBuilder.BuildHumanAvatar(root, humanDescription);
            
            return animator;
        }

        private static Dictionary<HumanBodyBones, Pose> CreateLocalPoseMap(Animator animator)
        {
            var result = new Dictionary<HumanBodyBones, Pose>();
            foreach (var bone in Enum.GetValues(typeof(HumanBodyBones)).Cast<HumanBodyBones>())
            {
                if (bone == HumanBodyBones.LastBone || bone == HumanBodyBones.Jaw ||
                    bone == HumanBodyBones.LeftEye || bone == HumanBodyBones.RightEye)
                {
                    continue;
                }

                var t = animator.GetBoneTransform(bone);
                if (t == null)
                {
                    continue;
                }

                var pos = t.localPosition;
                var rot = t.localRotation;
                result[bone] = new Pose(pos, rot);
            }
            return result;
        }
    }
}