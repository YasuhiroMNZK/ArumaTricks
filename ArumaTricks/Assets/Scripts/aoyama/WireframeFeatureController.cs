using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class WireframeFeatureController : ScriptableRendererFeature
{
    class WireframePass : ScriptableRenderPass
    {
        private bool m_IsOn;
        public WireframePass(bool isOn, RenderPassEvent renderEvent)
        {
            m_IsOn = isOn;
            this.renderPassEvent = renderEvent;
        }

        public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
        {
            var cmd = CommandBufferPool.Get("WireframeToggle");
            // 直接GL命令でワイヤーフレーム状態を上書き
            GL.wireframe = m_IsOn; 
            context.ExecuteCommandBuffer(cmd);
            CommandBufferPool.Release(cmd);
        }
    }

    WireframePass m_OnPass;
    WireframePass m_OffPass;

    public override void Create()
    {
        // 描画イベントを「AfterRenderingPrePasses（描画直前）」と「AfterRenderingOpaques（不透明物描画後）」に設定
        m_OnPass = new WireframePass(true, RenderPassEvent.AfterRenderingPrePasses);
        m_OffPass = new WireframePass(false, RenderPassEvent.AfterRenderingOpaques);
    }

    public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
    {
        renderer.EnqueuePass(m_OnPass);
        renderer.EnqueuePass(m_OffPass);
    }
}