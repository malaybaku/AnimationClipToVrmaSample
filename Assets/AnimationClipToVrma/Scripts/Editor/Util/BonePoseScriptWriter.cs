using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Baxter
{
    /// <summary>
    /// Animatorを指定することで、ボーン構造をコード断片として出力できるクラス
    /// </summary>
    public static class BonePoseScriptWriter
    {
        /// <summary>
        /// TポーズのアバターのAnimatorを指定して呼び出すことで、ボーン構造に関するスクリプト断片テキストを出力する
        /// </summary>
        /// <param name="animator"></param>
        /// <returns></returns>
        public static string[] CreateBoneAndLocalPoseDataMap(Animator animator)
        {
            var result = new List<string>(54);
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

                result.Add(@$"[HumanBodyBones.{bone}] = new Pose(
    new Vector3((float) {pos.x:R}, (float) {pos.y:R}, (float) {pos.z:R}),
    new Quaternion((float) {rot.x:R}, (float) {rot.y:R}, (float) {rot.z:R}, (float) {rot.w:R})
    ),");
            }

            return result.ToArray();
        }
    }   
}
