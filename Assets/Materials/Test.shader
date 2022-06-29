Shader "Unlit/Shadow"
{
    Properties
    {
		_Diffuse("Diffuse",Color) = (1,1,1,1)
		_Specular("Specular",Color) = (1,1,1,1)
		_Gloss("Gloss",Range(8.0,256)) = 8.0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100


        Pass
        {
			Tags{"LightMode" = "ForwardBase"}
            CGPROGRAM
			#pragma multi_compile_fwdbase 
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"
			#include "Lighting.cginc"
			#include "AutoLight.cginc"
			fixed4 _Diffuse;
			fixed4 _Specular;
			fixed _Gloss;

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
				float3 normal:NORMAL;
            };

            struct v2f
            {
                float4 pos : SV_POSITION;
				float3 worldNormal : TEXCOORD0;
				float3 worldPos:TEXCOORD1;
				float3 vertexLight : TEXCOORD2;
				SHADOW_COORDS(3)
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;

            v2f vert (appdata v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
				o.worldNormal = UnityObjectToWorldNormal(v.normal);
				o.worldPos = mul(unity_ObjectToWorld,v.vertex).xyz;
				#ifdef LIGHTMAP_OFF
				float shLight = ShadeSH9(float4(v.normal,1.0));
				o.vertexLight = shLight;
				#ifdef VERTEXLIGHT_ON 
				float3 vertexLight = Shade4PointLights(unity_4LightPosX0,unity_4LightPosY0,unity_4LightPosZ0,
				unity_LightColor[0].rgb,unity_LightColor[1].rgb,unity_LightColor[2].rgb,unity_LightColor[3].rgb,
				unity_4LightAtten0,o.worldPos,o.worldNormal);
				o.vertexLight += vertexLight;
				#endif
				#endif
				TRANSFER_SHADOW(o);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
				fixed3 worldNormal  = normalize(i.worldNormal);
				fixed3 worldLightDir = normalize(UnityWorldSpaceLightDir(i.worldPos));
				fixed3 ambient = UNITY_LIGHTMODEL_AMBIENT.xyz;
				//fixed3 halfLambert = dot(worldNormal , worldLightDir) * 0.5 + 0.5;
				fixed3 diffuse = _LightColor0.rgb * _Diffuse.rgb * max(0,dot(worldNormal,worldLightDir));
				

				fixed3 viewDir = normalize(UnityWorldSpaceViewDir(i.worldPos));
				fixed3 halfDir = normalize(worldLightDir + viewDir);


				fixed3 specular = _LightColor0.rgb * _Specular.rgb * pow(max(0,dot(worldNormal,halfDir)),_Gloss);

				UNITY_LIGHT_ATTENUATION(atten, i, i.worldPos);

                
                return fixed4((ambient + (diffuse + specular) * atten + i.vertexLight), 1);
            }
            ENDCG
        }

		Pass
		{
			Tags{"LightMode" = "ForwardAdd"}
			Blend One One

			CGPROGRAM
			#pragma multi_compile_fwdadd_fullshadows
            #pragma vertex vert
            #pragma fragment frag

			#include "Lighting.cginc"
			#include "AutoLight.cginc"

			fixed4 _Diffuse;
			fixed4 _Specular;
			fixed _Gloss;

			struct a2v
			{
				float4 vertex:POSITION;
				float3 normal:NORMAL;
			};
			struct v2f
			{
				float4 pos:SV_POSITION;
				float3 worldNormal:TEXCOORD0;
				float3 worldPos: TEXCOORD1;
				LIGHTING_COORDS(2,3)

			};
			v2f vert(a2v v)
			{
				v2f o;
				o.pos = UnityObjectToClipPos(v.vertex);
				o.worldNormal = UnityObjectToWorldNormal(v.normal);
				o.worldPos = mul(unity_ObjectToWorld,v.vertex).xyz;
				TRANSFER_VERTEX_TO_FRAGMENT(o);
				return o;
				
			}
			fixed4 frag(v2f i):SV_Target
			{
				fixed3 worldNormal = normalize(i.worldNormal);
				fixed3 worldLightDir = normalize(UnityWorldSpaceLightDir(i.worldPos));

				//fixed3 halfLambert = dot(worldNormal,worldLightDir) *0.5 + 0.5;
				fixed3 diffuse = _LightColor0.rgb * _Diffuse.rgb * max(0,dot(worldNormal,worldLightDir));

				fixed3 viewDir = normalize(UnityWorldSpaceViewDir(i.worldPos));
				fixed3 halfDir = normalize(worldLightDir + viewDir);
				fixed3 specular = _LightColor0.rgb * _Specular.rgb * pow(max(0,dot(viewDir,halfDir)),_Gloss);

				//fixed3 atten = LIGHT_ATTENUATION(i);
				UNITY_LIGHT_ATTENUATION(atten,i,i.worldPos);

				return fixed4((diffuse + specular)*atten,1.0);
			}

			ENDCG
		}
    }
	FallBack "Diffuse"
}