using UnityEngine;

public class WireframeTest : MonoBehaviour
{
    void Start()
    {
        MeshFilter meshFilter = GetComponent<MeshFilter>();
        if (meshFilter == null) return;

        Mesh oldMesh = meshFilter.sharedMesh;
        // メッシュをコピーして作成
        Mesh newMesh = new Mesh();
        newMesh.vertices = oldMesh.vertices;
        
        // 三角形ポリゴンのインデックスを取得し、線のリストとして再設定
        int[] indices = oldMesh.GetIndices(0);
        newMesh.SetIndices(indices, MeshTopology.Lines, 0);

        meshFilter.mesh = newMesh;
    }
}