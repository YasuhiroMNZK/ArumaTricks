Shader "Custom/WireframePaint"
{
    Properties
    {
        _WireColor("Wire Color", Color) = (1, 1, 1, 1)
        _SkinColor("Skin Color", Color) = (0.8, 0.6, 0.4, 1)
        _WireThickness("Wire Thickness", Range(0, 0.5)) = 0.05
    }
    SubShader
    {
        Tags { "RenderType" = "Opaque" }
        Pass
        {
            Cull Off
            HLSLPROGRAM
            #pragma vertex vert
            #pragma geometry geom
            #pragma fragment frag
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

            struct appdata { float4 positionOS : POSITION; float4 color : COLOR; };
            struct v2g { float4 posOS : TEXCOORD1; float4 projection : SV_POSITION; float4 color : COLOR; };
            struct g2f { float4 pos : SV_POSITION; float3 barycentric : TEXCOORD0; float4 color : COLOR; };

            float4 _WireColor, _SkinColor;
            float _WireThickness;

            v2g vert(appdata v) {
                v2g o;
                o.posOS = v.positionOS;
                o.projection = TransformObjectToHClip(v.positionOS.xyz);
                o.color = v.color; // 頂点カラーを渡す
                return o;
            }

            [maxvertexcount(3)]
            void geom(triangle v2g i[3], inout TriangleStream<g2f> triStream) {
                g2f o;
                for(int j = 0; j < 3; j++) {
                    o.pos = i[j].projection;
                    o.barycentric = (j == 0) ? float3(1,0,0) : (j == 1) ? float3(0,1,0) : float3(0,0,1);
                    o.color = i[j].color; // 頂点カラーを保持
                    triStream.Append(o);
                }
            }

            half4 frag(g2f i) : SV_Target {
                // 頂点カラーのRが1ならワイヤー、0なら肌色
                if (i.color.r > 0.5) {
                    float minBary = min(min(i.barycentric.x, i.barycentric.y), i.barycentric.z);
                    if (minBary > _WireThickness) discard;
                    return _WireColor;
                }
                return _SkinColor;
            }
            ENDHLSL
        }
    }
}