using UnityEngine;

namespace Baxter
{
    public static class HumanBoneVisualizer
    {
        /// <summary>
        /// 指定したオブジェクト以下に対し、LineRendererでボーン階層を表示できるようにする。
        /// VRM Animationに埋め込まれた骨格情報を検証するときに使えるデバッグ用のメソッド。
        /// </summary>
        /// <param name="root"></param>
        public static void Setup(Transform root)
        {
            AddLineRenderers(root);
        }

        private static void AddLineRenderers(Transform t)
        {
            var count = t.childCount;
            for (var i = 0; i < count; i++)
            {
                AddLineRenderers(t.GetChild(i));
            }

            if (t.parent != null)
            {
                AddLineRenderer(t.parent, t);
            }
        }
        
        //child -> parentに向くLineRendererを追加する
        private static void AddLineRenderer(Transform parent, Transform child)
        {
            var obj = new GameObject("line");
            obj.transform.SetParent(parent);
            obj.transform.localPosition = Vector3.zero;
            obj.transform.localRotation = Quaternion.identity;
            var lineRenderer = obj.AddComponent<LineRenderer>();
            lineRenderer.alignment = LineAlignment.View;
            lineRenderer.useWorldSpace = false;
            lineRenderer.positionCount = 2;
            lineRenderer.SetPosition(0, Vector3.zero);
            lineRenderer.SetPosition(1, child.localPosition);
            lineRenderer.widthMultiplier = 0.01f;
        }
    }
}
