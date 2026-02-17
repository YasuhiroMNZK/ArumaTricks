Shader "Custom/URP_GlobalNoise"
{
    Properties
    {
        _BaseMap ("Base Texture", 2D) = "white" {}
        _NoiseStrength ("Displace Strength", Float) = 0.02
        _NoiseSpeed ("Noise Speed", Float) = 30.0
    }

    SubShader
    {
        Tags { "RenderPipeline" = "UniversalPipeline" "RenderType" = "Opaque" }

        Pass
        {
            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

            struct Attributes
            {
                float4 positionOS : POSITION;
                float3 normalOS   : NORMAL;
                float2 uv         : TEXCOORD0;
            };

            struct Varyings
            {
                float4 positionCS : SV_POSITION;
                float2 uv         : TEXCOORD0;
                float noiseVal    : TEXCOORD1; // ノイズ値をピクセルシェーダーに渡す
            };

            sampler2D _BaseMap;
            float _NoiseStrength;
            float _NoiseSpeed;

            // 高速な疑似乱数
            float random(float2 p)
            {
                return frac(sin(dot(p, float2(12.9898, 78.233))) * 43758.5453);
            }

            Varyings vert(Attributes input)
            {
                Varyings output;

                // 時間とUVを使って、ピクセルごとに異なるノイズを生成
                float r = random(input.uv + _Time.y * _NoiseSpeed);
                output.noiseVal = r;

                // 形状のノイズ：法線方向にランダムに突き出す
                float3 offset = input.normalOS * (r - 0.5) * _NoiseStrength;
                
                output.positionCS = TransformObjectToHClip(input.positionOS.xyz + offset);
                output.uv = input.uv;
                return output;
            }

            half4 frag(Varyings input) : SV_Target
            {
                // 元のテクスチャの色
                half4 col = tex2D(_BaseMap, input.uv);

                // 砂嵐（白黒ノイズ）を合成
                // noiseValが一定以上なら白、それ以外なら元の色にするなどで「パチパチ」させる
                if(input.noiseVal > 0.8) {
                    return half4(input.noiseVal, input.noiseVal, input.noiseVal, 1.0);
                }

                return col;
            }
            ENDHLSL
        }
    }
}