using UnityEngine;
using System.Collections.Generic;

namespace aoyama
{
    public class WireframeManager : MonoBehaviour
    {
        private Mesh mesh;
        private Vector3[] vertices;
        private Color[] colors;

        void Start()
        {
            // 重要：現在のアセットからMeshのコピーを作成して代入する
            Mesh originalMesh = GetComponent<MeshFilter>().mesh;
            mesh = Instantiate(originalMesh);
            GetComponent<MeshFilter>().mesh = mesh; // メッシュを差し替える

            vertices = mesh.vertices;
            colors = new Color[vertices.Length];

            // 初期状態：すべて黒（ワイヤー化しない）
            for (int i = 0; i < colors.Length; i++)
            {
                colors[i] = Color.black;
            }
            mesh.colors = colors;
        }

        void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Water"))
            {
                bool changed = false;
                for (int i = 0; i < vertices.Length; i++)
                {
                    // ワールド空間での頂点位置
                    Vector3 worldPos = transform.TransformPoint(vertices[i]);
                    // 水のコライダーの中に頂点が入っているか確認
                    if (other.bounds.Contains(worldPos))
                    {
                        if (colors[i].r < 0.5f)
                        {
                            colors[i] = Color.red; // ワイヤー化フラグを立てる
                            changed = true;
                        }
                    }
                }
                if (changed) mesh.colors = colors;
            }
        }
    }
}