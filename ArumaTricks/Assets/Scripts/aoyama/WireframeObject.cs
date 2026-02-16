using UnityEngine;
using UnityEngine.Rendering;
using System.Collections.Generic;

[ExecuteInEditMode]
public class WireframeObject : MonoBehaviour
{
    void OnEnable()
    {
        // 描画開始時と終了時のイベントに登録
        RenderPipelineManager.beginContextRendering += OnBeginContext;
        RenderPipelineManager.endContextRendering += OnEndContext;
    }

    void OnDisable()
    {
        // 登録を解除
        RenderPipelineManager.beginContextRendering -= OnBeginContext;
        RenderPipelineManager.endContextRendering -= OnEndContext;
        GL.wireframe = false;
    }

    // カメラが描画を始める直前に呼ばれる
    void OnBeginContext(ScriptableRenderContext context, List<Camera> cameras)
    {
        GL.wireframe = true;
    }

    // カメラが描画を終えた直後に呼ばれる
    void OnEndContext(ScriptableRenderContext context, List<Camera> cameras)
    {
        GL.wireframe = false;
    }
}