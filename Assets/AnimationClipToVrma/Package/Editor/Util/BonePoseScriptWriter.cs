using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Baxter
{
    /// <summary>
    /// Animatorを指定することで、ボーン構造をハードコードしたスクリプトを出力できるクラス
    /// </summary>
    public static class BonePoseScriptWriter
    {
        const string ClassNamespace = "Baxter";

        public static string BuildHumanoidValuesScript(Animator animator)
        {
            var lines = CreateLocalPoseValues(animator);

            var sb = new StringBuilder();
            sb.Append(
$@"// Auto-Generated File
// Source Object: {animator.gameObject.name}
using System.Collections.Generic;
using UnityEngine;

namespace {ClassNamespace}
{{
    public static class ReferenceHumanoid
    {{
        public static IReadOnlyDictionary<HumanBodyBones, Pose> BoneLocalPoseMap => Values;

        private static readonly Dictionary<HumanBodyBones, Pose> Values = new()
        {{
");

            foreach (var line in lines)
            {
                sb.AppendLine(line);
            }

            sb.Append(
$@"        }};
    }}
}}
");
            return sb.ToString();
        }

        /// <summary>
        /// TポーズのアバターのAnimatorを指定して呼び出すことで、ボーン構造に関するスクリプト断片テキストを出力する
        /// </summary>
        /// <param name="animator"></param>
        /// <returns></returns>
        private static string[] CreateLocalPoseValues(Animator animator)
        {
            var result = new List<string>(54);
            foreach (var bone in Enum.GetValues(typeof(HumanBodyBones))
                .Cast<HumanBodyBones>()
                .Where(bone => bone is not (
                    HumanBodyBones.LastBone or HumanBodyBones.Jaw or HumanBodyBones.LeftEye or HumanBodyBones.RightEye
                    ))
                )
            {
                var t = animator.GetBoneTransform(bone);
                if (t == null)
                {
                    continue;
                }

                var pos = t.localPosition;
                var rot = t.localRotation;

                result.Add(
@$"            [HumanBodyBones.{bone}] = new Pose(
                new Vector3((float){pos.x:R}, (float){pos.y:R}, (float){pos.z:R}),
                new Quaternion((float){rot.x:R}, (float){rot.y:R}, (float){rot.z:R}, (float){rot.w:R})
            ),");
                
            }

            return result.ToArray();
        }
    }   
}
