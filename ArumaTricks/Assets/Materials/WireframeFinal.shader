Shader "Custom/WireframeFinal"
{
    Properties
    {
        _WireColor("Wire Color", Color) = (1, 1, 1, 1)
        _WireThickness("Wire Thickness", Range(0, 1)) = 0.05
    }
    SubShader
    {
        Tags { "RenderType" = "Opaque" "RenderPipeline" = "UniversalPipeline" }
        Pass
        {
            Cull Off
            HLSLPROGRAM
            #pragma vertex vert
            #pragma geometry geom
            #pragma fragment frag
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

            struct appdata { float4 positionOS : POSITION; };
            struct v2g { float4 projection : SV_POSITION; };
            struct g2f { float4 pos : SV_POSITION; float3 barycentric : TEXCOORD0; };

            float4 _WireColor;
            float _WireThickness;

            v2g vert(appdata v) {
                v2g o;
                o.projection = TransformObjectToHClip(v.positionOS.xyz);
                return o;
            }

            [maxvertexcount(3)]
            void geom(triangle v2g i[3], inout TriangleStream<g2f> triStream) {
                g2f o;
                o.pos = i[0].projection; o.barycentric = float3(1, 0, 0); triStream.Append(o);
                o.pos = i[1].projection; o.barycentric = float3(0, 1, 0); triStream.Append(o);
                o.pos = i[2].projection; o.barycentric = float3(0, 0, 1); triStream.Append(o);
            }

            half4 frag(g2f i) : SV_Target {
                float minBary = min(min(i.barycentric.x, i.barycentric.y), i.barycentric.z);
                if (minBary > _WireThickness) discard; // 辺じゃない場所を消す
                return _WireColor;
            }
            ENDHLSL
        }
    }
}