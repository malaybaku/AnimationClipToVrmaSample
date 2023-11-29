using System;
using System.IO;
using UnityEngine;

namespace Baxter
{
    public class HumanoidAnimationToVrma : MonoBehaviour
    {
        [SerializeField] private Animator humanoid;
        
        private void Start() => ExportBonePoseText();

        private void ExportBonePoseText()
        {
            var path = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                "bone_literal.txt"
                );
            var lines = BonePoseScriptWriter.CreateBoneAndLocalPoseDataMap(humanoid);
            File.WriteAllLines(path, lines);
        }
    }
}