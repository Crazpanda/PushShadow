// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/EntityOccluder"
{
    CGINCLUDE

    #include "UnityCG.cginc"
    #include "AutoLight.cginc"

    ENDCG

    SubShader
    {
        Tags
        {
            "RenderType" = "Opaque"
            "Queue" = "Geometry-1"
        }
        

        // Depth fill pass
        Pass
        {
            ColorMask 0

            CGPROGRAM

            #pragma vertex vert
            #pragma fragment frag

            struct v2f {
                float4 pos : SV_POSITION;
            };

            v2f vert(appdata_full v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos (v.vertex);
                return o;
            }

            half4 frag(v2f IN) : SV_Target
            {
                return (half4)1;
            }

            ENDCG
        }
    }
    FallBack "Mobile/VertexLit"
}