Shader "Unlit/Laser1"
{
	Properties
	{
		_MainTex("Texture", 2D) = "white" {}
		_Size("Size", Vector) = (1024, 1024, 0, 0)
	}
	SubShader
	{
		Tags { "Queue" = "Transparent" "RenderType"="Transparent" }
		LOD 100

		ZWrite Off
		Blend SrcAlpha OneMinusSrcAlpha

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			// make fog work
			#pragma multi_compile_fog
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				UNITY_FOG_COORDS(1)
				float4 vertex : SV_POSITION;
			};

			sampler2D _MainTex;
			float4 _MainTex_ST;
			float2 _Size;

			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				UNITY_TRANSFER_FOG(o,o.vertex);
				return o;
			}

			float Strand(float2 uv, float hoffset, float hscale, float vscale, float t)
			{
				float2 R = _Size.xy;
				//vec2 R = iResolution.xy;
				uv /= R;

				float g = .3 * R.y;
				float d = 1. - abs(uv.y - (sin(uv.x * hscale*10. + t + hoffset) / 4. * vscale
					+ .5))*R.y;
				return  0.5 *(  clamp(d, 0., 1.)
					+ clamp(1. + d / g, 0., 1.) * .4);
			}

			half4 Muzzle(float2 uv)
			{
				float2 R = _Size.xy;

				//vec2 R = iResolution.xy;
				//float2 R = float2(uv.x / _ScreenParams.x, uv.y / _ScreenParams.y);
				//float2 R = float2(1.0, 1.0);
				
				float iTime = _Time[1] * 2.0f;

				float2 u = (R*float2(1, .5) - uv) / R.y;
				float T = floor(iTime * 20.),
					theta = atan2(u.y, u.x),
					len = (10. + sin(theta * 20. - T * 35.)) / 11.;
				u.y *= 4.;
				float d = max(-0.6, 1. - length(u) / len);
				return d*(1. + .5* half4(sin(theta * 10. + T * 10.77),
					-cos(theta *  8. - T *  8.77),
					-sin(theta *  6. - T *134.77),
					0));
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				float2 uv = 1 - i.uv;
				//uv.y = uv.y * 0.5 + 0.25;
				uv *= _Size.xy;
				half4 c = half4(0, 0, 0, 0);

				float iTime = _Time[1];

				float t = 2.*iTime,
				s = 1. + sin(iTime) * 5.;
				c += Strand(uv, 0.234 + s, 1.0, 0.3, 10.0 * t) *float4(0, 0, 1, 1);
				c += Strand(uv, 0.645 + s, 1.5, 0.20, 8.3 * t) *float4(1, 0, 1, 1);
				c += Strand(uv, 1.735 + s, 1.3, 0.2, 8.0 * t) *float4(0, 1, 1, 1);
				c += Strand(uv, 0.9245 + s, 1.6, 0.14, 12.0 * t) *float4(0, 1, 1, 1);
				c += Strand(uv, 0.4234 + s, 1.9, 0.3, 14.0 * t) *float4(1, 1, 0, 1);
				c += Strand(uv, 0.14525 + s, 1.2, 0.18, 9.0 * t) *float4(1, 0, 1, 1);
				//c += clamp(Muzzle(uv), 0, 1);
				//c.a = smoothstep(0.1, 0.3, c.a);
				return c;

				fixed4 col = tex2D(_MainTex, i.uv);
				UNITY_APPLY_FOG(i.fogCoord, col);
				return col;
			}
			ENDCG
		}
	}
}
