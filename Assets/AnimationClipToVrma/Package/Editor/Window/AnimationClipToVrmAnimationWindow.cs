using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace Baxter
{
    public class AnimationClipToVrmaWindow : EditorWindow
    {
        private const string FileExtension = "vrma";

        private GameObject avatarObject = null;
        private AnimationClip animationClip = null;

        [MenuItem("VRM1/VRM Animation Exporter")]
        public static void OpenAnimationClipToVrmaWindow()
        {
            var window = (AnimationClipToVrmaWindow)GetWindow(typeof(AnimationClipToVrmaWindow));
            window.titleContent = new GUIContent("VRM Animation Exporter");
            window.Show();
        }

        private void OnGUI()
        {
            minSize = new Vector2(300f, 250f);
            EditorGUIUtility.labelWidth = 150;
            
            EditorGUILayout.Space();
            WrappedLabel("再生用のアバターとモーションデータを指定することで、\nVRM Animation(.vrma)ファイルを出力します。");
            EditorGUILayout.Space();

            if (Application.isPlaying)
            {
                WrappedLabel("This feature is unavailable during playing.");
            }
            
            EditorGUILayout.LabelField("Avatar:");
            {
                avatarObject = (GameObject)EditorGUILayout.ObjectField(avatarObject, typeof(GameObject), true);
            }
            var avatarIsValid = ShowAvatarValidityGUI();
            
            EditorGUILayout.LabelField("Animation:");
            {
                animationClip = (AnimationClip)EditorGUILayout.ObjectField(animationClip, typeof(AnimationClip));
            }
            //NOTE: Always show animation clip validity GU
            var animationIsValid = ShowAnimationClipValidityGUI();

            EditorGUILayout.Space();
            WrappedLabel("出力時のFPSは30で固定です.");
            EditorGUILayout.Space();
            
            var canExport = !Application.isPlaying && avatarIsValid && animationIsValid;
            GUI.enabled = canExport;
            if (canExport & GUILayout.Button("Export", GUILayout.MinWidth(100)))
            {
                TrySaveAnimationClip();
            }
            GUI.enabled = true;
        }

        private void TrySaveAnimationClip()
        {
            var saveFilePath = EditorUtility.SaveFilePanel(
                "Save VRM Animation File", "", animationClip.name, FileExtension
            );

            if (string.IsNullOrEmpty(saveFilePath))
            {
                return;
            }

            GameObject referenceObj = null;
            try
            {
                referenceObj = GetAnimatorOnlyObject(avatarObject);
                var data = AnimationClipToVrmaCore.Create(referenceObj.GetComponent<Animator>(), animationClip);
                File.WriteAllBytes(saveFilePath, data);
                Debug.Log("VRM Animation file was saved to: " + Path.GetFullPath(saveFilePath));
            }
            catch (Exception ex)
            {
                Debug.LogException(ex);
            }
            finally
            {
                if (referenceObj != null)
                {
                    DestroyImmediate(referenceObj);
                }
            }
        }
        
        private bool ShowAvatarValidityGUI()
        {
            if (avatarObject == null)
            {
                WrappedLabel("*Avatar is not selected.");
                return false;
            }

            var animator = avatarObject.GetComponent<Animator>();
            if (animator == null)
            {
                WrappedLabel(
                    "*Avatar does not have animator. Please specify object with Animator component.");
                return false;
            }

            if (!animator.isHuman)
            {
                WrappedLabel(
                    "*Avatar's animator is not humanoid. Please specify avatar with Humanoid rig setup.");
                return false;
            }
            
            return true;
        }

        private bool ShowAnimationClipValidityGUI()
        {
            if (animationClip == null)
            {
                WrappedLabel("*Animation Clip is not selected.");
                return false;
            }

            if (!animationClip.isHumanMotion)
            {
                WrappedLabel("*The Clip is not Humanoid Animation.");
                return false;
            }

            return true;
        }

        // HumanBodyBoneの骨格と関係しない要素を削除していく。
        private static GameObject GetAnimatorOnlyObject(GameObject src)
        {
            var resultAnimator = HumanoidBuilder.CreateHumanoid(src.GetComponent<Animator>());
            return resultAnimator.gameObject;

            var result = Instantiate(src);
            //コンポーネントを消す
            var animator = result.GetComponent<Animator>();
            var components = result.GetComponentsInChildren<Component>();
            foreach (var c in components)
            {
                if (c != animator && c is not Transform)
                {
                    DestroyImmediate(c);
                }
            }

            //GameObjectを消す
            //NOTE: マイナーではあるが、以下のようなボーン構造に対して(知らないボーン)の部分を削除しないように対策している
            // - LeftUpperLeg / (知らないボーン) / LeftLowerLeg
            var boneTransforms = new HashSet<Transform>() { result.transform };
            var humanBodyBoneTransforms = new HashSet<Transform>();
            foreach (var bone in Enum.GetValues(typeof(HumanBodyBones)).Cast<HumanBodyBones>())
            {
                if (bone is HumanBodyBones.Jaw or HumanBodyBones.LastBone)
                {
                    continue;
                }

                var boneTransform = animator.GetBoneTransform(bone);
                if (boneTransform == null)
                {
                    continue;
                }

                // ここでparentを見ておくのが対策
                for (var t = boneTransform; t != null; t = t.parent)
                {
                    boneTransforms.Add(t);
                }

                boneTransform.name = bone.ToString();
                humanBodyBoneTransforms.Add(boneTransform);
            }

            var transforms = result.GetComponentsInChildren<Transform>();
            foreach (var t in transforms)
            {
                //親がすでに削除済みだとt == nullになりうることに注意
                if (t != null && !boneTransforms.Contains(t))
                {
                    DestroyImmediate(t.gameObject);
                }
            }

            //rootでもHumanBodyBonesでもない中間ボーンがある場合、それにも名前を振っておく
            result.gameObject.name = "root";
            boneTransforms.Remove(result.transform);
            boneTransforms.ExceptWith(humanBodyBoneTransforms);
            var otherBoneIndex = 0;
            foreach (var bt in boneTransforms)
            {
                bt.name = $"bones_{otherBoneIndex}";
                otherBoneIndex++;
            }
            return result;
        }

        private static void WrappedLabel(string label)
        {
            var style = new GUIStyle(GUI.skin.label)
            {
                wordWrap = true,
            };
            EditorGUILayout.LabelField(label, style);
        }
    }
}
