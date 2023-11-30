using System.Linq;
using System.Text;
using UnityEngine;
using UniVRM10;

namespace Baxter
{
    /// <summary> ハードコードしたVRM Modelの骨格に基づいてアバターの骨格部分だけを動的生成するクラス </summary>
    public static partial class ReferenceHumanoid
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

        public static Animator CreateHumanoid()
        {
            var bones = BoneLocalPoseMap
                .Select(pair =>
                {
                    var obj = new GameObject(pair.Key.ToString());
                    obj.transform.localPosition = pair.Value.position;
                    obj.transform.localRotation = pair.Value.rotation;
                    return new BoneAndTransform(pair.Key, obj.transform);
                })
                .ToArray();

            //階層構造をいい感じにしていく
            //NOTE: ExampleHumanoidは任意ボーンも入ってる前提なため、ボーンの欠落は特にケアしない
            foreach (var bone in bones)
            {
                if (bone.Bone == HumanBodyBones.Hips)
                {
                    continue;
                }
            
                var vrm10Bone = Vrm10HumanoidBoneSpecification.ConvertFromUnityBone(bone.Bone);
                var parentVrm10Bone = Vrm10HumanoidBoneSpecification.GetDefine(vrm10Bone).ParentBone.Value;
                var parentBone = Vrm10HumanoidBoneSpecification.ConvertToUnityBone(parentVrm10Bone);
            
                var parentBoneItem = bones.First(b => b.Bone == parentBone);
                bone.Transform.SetParent(parentBoneItem.Transform, false);
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
    }
}