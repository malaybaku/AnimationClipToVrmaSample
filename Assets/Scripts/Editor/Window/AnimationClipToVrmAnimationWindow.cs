using System;
using System.IO;
using UnityEditor;
using UnityEngine;

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

        void OnGUI()
        {
            EditorGUIUtility.labelWidth = 150;
            if (Application.isPlaying)
            {
                EditorGUILayout.LabelField("This feature is unavailable during playing.");
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

            var canExport = !Application.isPlaying && avatarIsValid && animationIsValid;
            GUI.enabled = canExport;
            if (canExport & GUILayout.Button("Export", GUILayout.MinWidth(100)))
            {
                TrySaveAnimationClip();
            }
            GUI.enabled = true;
        }

        void TrySaveAnimationClip()
        {
            var saveFilePath = EditorUtility.SaveFilePanel(
                "Save VRM Animation File", "", animationClip.name, FileExtension
            );

            if (string.IsNullOrEmpty(saveFilePath))
            {
                return;
            }

            try
            {
                var data = AnimationClipToVrmaCore.Create(avatarObject.GetComponent<Animator>(), animationClip);
                File.WriteAllBytes(saveFilePath, data);
                Debug.Log("VRM Animation file was saved to: " + Path.GetFullPath(saveFilePath));
            }
            catch (Exception ex)
            {
                Debug.LogException(ex);
            }
        }
        
        bool ShowAvatarValidityGUI()
        {
            if (avatarObject == null)
            {
                EditorGUILayout.LabelField("*Avatar is not selected.");
                return false;
            }

            if (avatarObject.scene.rootCount == 0)
            {
                EditorGUILayout.LabelField("*Avatar is not in scene: please put it on current scene.");
                return false;
            }

            var animator = avatarObject.GetComponent<Animator>();
            if (animator == null)
            {
                EditorGUILayout.LabelField(
                    "*Avatar does not have animator. Please specify object with Animator component.");
                return false;
            }

            if (!animator.isHuman)
            {
                EditorGUILayout.LabelField(
                    "*Avatar's animator is not humanoid. Please specify avatar with Humanoid rig setup.");
                return false;
            }
            
            return true;
        }

        bool ShowAnimationClipValidityGUI()
        {
            if (animationClip == null)
            {
                EditorGUILayout.LabelField("*Animation Clip is not selected.");
                return false;
            }

            if (!animationClip.isHumanMotion)
            {
                EditorGUILayout.LabelField("*The Clip is not Humanoid Animation.");
                return false;
            }

            return true;
        }
    }
}
