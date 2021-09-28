// Upgrade NOTE: replaced '_LightMatrix0' with 'unity_WorldToLight'

// Upgrade NOTE: replaced '_LightMatrix0' with 'unity_WorldToLight'

// Upgrade NOTE: replaced '_LightMatrix0' with 'unity_WorldToLight'

// Upgrade NOTE: replaced '_LightMatrix0' with 'unity_WorldToLight'

// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'
// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/LightDrawer"
{
    Properties
    {
        _Diffuse ("Diffuse", Color) = (1, 1, 1, 1)
    }

    SubShader
    {
        Tags { "Queue"="AlphaTest+48" }

        Pass{
            Tags { "LightMode"="ForwardAdd" }
            Blend One OneMinusSrcAlpha
            CGPROGRAM

            #pragma multi_compile_fwdadd_fullshadows 
            #pragma vertex vert
			#pragma fragment frag

            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #include "AutoLight.cginc"

            fixed4 _Diffuse;

            struct a2v {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };

            struct v2f {
                float4 pos : SV_POSITION;
                LIGHTING_COORDS(0, 1)
                float3 worldNormal : TEXCOORD2;
                float3 worldPos : TEXCOORD3;
            };

            v2f vert(a2v v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);

                o.worldNormal = UnityObjectToWorldNormal(v.normal);

                o.worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;
                TRANSFER_VERTEX_TO_FRAGMENT(o);
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                fixed3 worldNormal = normalize(i.worldNormal);
                fixed3 worldLightDir = normalize(_WorldSpaceLightPos0.xyz - i.worldPos);

                fixed3 diffuse = _LightColor0.rgb * _Diffuse.rgb * max(0, dot(worldNormal, worldLightDir));

                half atten = LIGHT_ATTENUATION(i);

                return fixed4(diffuse, _Diffuse.a) * atten;
            }

            ENDCG
        }
    }
FallBack "Mobile/VertexLit"
}