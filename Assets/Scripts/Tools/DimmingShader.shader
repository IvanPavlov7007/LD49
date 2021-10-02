Shader "PostProcess/DimmingShader"
{
	Properties
	{
		_MainTex("Texture", 2D) = "white" {}
		_DistanceMap("DistanceMap", 2D) = "white" {}
		_Visibility("Visibility", Float) = .0
		_DeltaRadius("Outer Radius", Float) = .0
	}
	SubShader
	{
		// No culling or depth
		Cull Off ZWrite Off ZTest Always

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;
			};

			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv;
				return o;
			}

			sampler2D _MainTex;
			sampler2D _DistanceMap;
			fixed _Visibility;
			fixed _DeltaRadius;

			fixed4 frag(v2f i) : SV_Target
			{
				fixed4 col = tex2D(_MainTex, i.uv);
				fixed r = tex2D(_DistanceMap, i.uv).r;
				fixed curVis = 1. - step(_Visibility, r) *((r - _Visibility) / _DeltaRadius);
				col = col * curVis;//fixed4(curVis, curVis, curVis, 1.);
				return col;
			}
			ENDCG
		}
	}
}
