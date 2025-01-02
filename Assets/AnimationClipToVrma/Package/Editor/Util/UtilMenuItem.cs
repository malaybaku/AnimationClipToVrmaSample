using System;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace Baxter
{
    /// <summary>
    /// アバターのprefabを右クリックしたメニューから、HumanDescriptionの骨格情報をコードテキストとして変換するユーティリティ
    /// </summary>
    public static class UtilMenuItem
    {
        private const string MenuFolderName = "Assets/VRM/Util/";
        private const string MenuItemName = "Export Bone Pose Script";
        private const string MenuItemFullName = MenuFolderName + MenuItemName;

        [MenuItem(MenuItemFullName)]
        public static void SaveBonePoseScriptFragment()
        {
            Debug.Log(MenuItemName);
            var obj = Selection.activeObject as GameObject;
            var animator = obj.GetComponent<Animator>();
            var path = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                "ReferenceHumanoid.cs"
            );
            var script = BonePoseScriptWriter.BuildHumanoidValuesScript(animator);
            File.WriteAllText(path, script);
            Debug.Log(MenuItemName + ", file was saved to:" + path);
        }

        [MenuItem(MenuItemFullName, validate = true)]
        public static bool SaveBonePoseScriptFragmentValidate()
        {
            var obj = Selection.activeObject;
            return obj is GameObject go && 
                go.TryGetComponent<Animator>(out var animator) && 
                animator.isHuman;
        }
    }
}