using System.IO;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Baxter
{
    /// <summary>
    /// プロジェクトビュー上でAnimationClipを右クリックしてVRM Animationに変換する機能
    /// </summary>
    public static class AnimationClipToVrmaAssetCommand
    {
        private const string FileExtension = "vrma";

        [MenuItem("Assets/VRM/Convert to VRM Animation")]
        public static void ConvertAnimationClipToVrmAnimation()
        {
            var clip = Selection.activeObject as AnimationClip;

            if (clip == null)
            {
                Debug.LogError("Selected object is not an Animation Clip. Select Animation Clip and retry");
                return;
            }

            if (!clip.isHumanMotion)
            {
                Debug.LogError("Selected object is not an Humanoid Animation. Setup animation for humanoid and retry");
                return;
            }

            var saveFilePath = EditorUtility.SaveFilePanel(
                "Save VRM Animation File", "", clip.name, FileExtension
                );
            if (string.IsNullOrEmpty(saveFilePath))
            {
                return;
            }
            
            GameObject animatorObject = null;
            try
            {
                var animator = HumanoidBuilder.CreateHumanoid(ReferenceHumanoid.ReferenceBoneLocalPoseMap);
                animatorObject = animator.gameObject;
                var bytes = AnimationClipToVrmaCore.Create(animator, clip);
                File.WriteAllBytes(saveFilePath, bytes);
                Debug.Log("VRM Animation saved to: " + saveFilePath);
            }
            finally
            {
                if (animatorObject != null)
                {
                    Object.DestroyImmediate(animatorObject);
                }
            }
        }

        [MenuItem("Assets/VRM/Convert to VRM Animation", validate = true)]
        public static bool ConvertAnimationClipToVrmAnimationValidate()
        {
            return Selection.activeObject is AnimationClip;
        }
    }
}