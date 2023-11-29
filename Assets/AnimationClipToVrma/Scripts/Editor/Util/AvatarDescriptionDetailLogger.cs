using UnityEngine;

namespace Baxter
{
    /// <summary>
    /// このコンポーネントをアバターにアタッチして実行すると、起動時にHumanDescriptionの値の一部を取得してログに表示する
    /// </summary>
    public class AvatarDescriptionDetailLogger : MonoBehaviour
    {
        [SerializeField] private Animator animator;

        private void Start()
        {
            LogHumanTraitNames();
            LogAvatarDescriptionDetail(animator.avatar.humanDescription);
        }

        private void LogHumanTraitNames()
        {
            Debug.Log("HumanNames start");
            foreach (var humanName in HumanTrait.BoneName)
            {
                Debug.Log(humanName);
            }
            Debug.Log("HumanNames end");
        }
        
        private void LogAvatarDescriptionDetail(HumanDescription desc)
        {
            foreach (var h in desc.human)
            {
                var limit = h.limit;
                Debug.Log($"human: {h.humanName}, {h.boneName}, {limit.useDefaultValues}, {limit.axisLength:0.000}");
                Debug.Log("  center:" + ToLogString(limit.center));
                Debug.Log("  min   :" + ToLogString(limit.min));
                Debug.Log("  max   :" + ToLogString(limit.max));
            }
        }

        private static string ToLogString(Vector3 v) => $"{v.x:0.000}, {v.y:0.000}, {v.z:0.000}";
    }
}
