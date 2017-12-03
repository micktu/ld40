// Shader created with Shader Forge v1.37 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.37;sub:START;pass:START;ps:flbk:,iptp:1,cusa:True,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:True,tesm:0,olmd:1,culm:2,bsrc:0,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:1873,x:36401,y:32755,varname:node_1873,prsc:2|emission-859-OUT;n:type:ShaderForge.SFN_TexCoord,id:5758,x:32191,y:32914,varname:node_5758,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Subtract,id:8225,x:32486,y:33089,varname:node_8225,prsc:2|A-5758-UVOUT,B-4197-OUT;n:type:ShaderForge.SFN_Vector1,id:4197,x:32486,y:33204,varname:node_4197,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Divide,id:3829,x:32654,y:33089,varname:node_3829,prsc:2|A-8225-OUT,B-4197-OUT;n:type:ShaderForge.SFN_Abs,id:199,x:32817,y:33089,varname:node_199,prsc:2|IN-3829-OUT;n:type:ShaderForge.SFN_Length,id:3581,x:32486,y:32965,varname:node_3581,prsc:2|IN-199-OUT;n:type:ShaderForge.SFN_OneMinus,id:6776,x:32642,y:32965,varname:node_6776,prsc:2|IN-3581-OUT;n:type:ShaderForge.SFN_Clamp01,id:2330,x:32817,y:32965,varname:node_2330,prsc:2|IN-6776-OUT;n:type:ShaderForge.SFN_Rotator,id:3017,x:33480,y:32927,varname:node_3017,prsc:2|UVIN-5758-UVOUT,ANG-1314-OUT;n:type:ShaderForge.SFN_Multiply,id:7032,x:33107,y:33091,varname:node_7032,prsc:2|A-2330-OUT,B-2015-OUT;n:type:ShaderForge.SFN_Slider,id:2015,x:33007,y:33232,ptovrint:False,ptlb:TWIRL,ptin:_TWIRL,varname:node_2015,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-8,cur:4.2,max:8;n:type:ShaderForge.SFN_Time,id:7524,x:32687,y:33442,varname:node_7524,prsc:2;n:type:ShaderForge.SFN_Multiply,id:1770,x:32873,y:33465,varname:node_1770,prsc:2|A-7524-T,B-6369-OUT;n:type:ShaderForge.SFN_Slider,id:6369,x:32530,y:33578,ptovrint:False,ptlb:SpinSpeed,ptin:_SpinSpeed,varname:node_6369,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-0.5,cur:-0.1,max:0.5;n:type:ShaderForge.SFN_Frac,id:5616,x:33032,y:33465,varname:node_5616,prsc:2|IN-1770-OUT;n:type:ShaderForge.SFN_Multiply,id:690,x:33208,y:33465,varname:node_690,prsc:2|A-5616-OUT,B-6930-OUT;n:type:ShaderForge.SFN_Tau,id:6930,x:33048,y:33611,varname:node_6930,prsc:2;n:type:ShaderForge.SFN_Add,id:1314,x:33391,y:33091,varname:node_1314,prsc:2|A-7032-OUT,B-690-OUT;n:type:ShaderForge.SFN_Subtract,id:7012,x:32979,y:32717,varname:node_7012,prsc:2|A-3017-UVOUT,B-6190-OUT;n:type:ShaderForge.SFN_Vector1,id:6190,x:32948,y:32657,varname:node_6190,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Divide,id:3277,x:33150,y:32717,varname:node_3277,prsc:2|A-7012-OUT,B-6190-OUT;n:type:ShaderForge.SFN_Abs,id:4888,x:33319,y:32717,varname:node_4888,prsc:2|IN-3277-OUT;n:type:ShaderForge.SFN_ComponentMask,id:6707,x:33480,y:32717,varname:node_6707,prsc:2,cc1:0,cc2:1,cc3:-1,cc4:-1|IN-4888-OUT;n:type:ShaderForge.SFN_Relay,id:4115,x:33642,y:32429,varname:node_4115,prsc:2|IN-2330-OUT;n:type:ShaderForge.SFN_ArcTan2,id:2944,x:33697,y:32717,varname:node_2944,prsc:2,attp:0|A-6707-G,B-6707-R;n:type:ShaderForge.SFN_Multiply,id:6639,x:33897,y:32717,varname:node_6639,prsc:2|A-2944-OUT,B-9954-OUT;n:type:ShaderForge.SFN_Slider,id:9954,x:33561,y:32635,ptovrint:False,ptlb:NumSpookesX2,ptin:_NumSpookesX2,varname:node_9954,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:1,cur:1.6,max:6;n:type:ShaderForge.SFN_Frac,id:1519,x:33935,y:32854,varname:node_1519,prsc:2|IN-6639-OUT;n:type:ShaderForge.SFN_Clamp01,id:7029,x:34097,y:32854,varname:node_7029,prsc:2|IN-1519-OUT;n:type:ShaderForge.SFN_RemapRange,id:1546,x:34254,y:32854,varname:node_1546,prsc:2,frmn:0,frmx:1,tomn:-1,tomx:1|IN-7029-OUT;n:type:ShaderForge.SFN_Abs,id:8885,x:34408,y:32854,varname:node_8885,prsc:2|IN-1546-OUT;n:type:ShaderForge.SFN_Multiply,id:2004,x:34622,y:32784,varname:node_2004,prsc:2|A-4115-OUT,B-8885-OUT;n:type:ShaderForge.SFN_Slider,id:6673,x:34256,y:32506,ptovrint:False,ptlb:CenterPower,ptin:_CenterPower,varname:node_6673,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:3,cur:1.5,max:0.5;n:type:ShaderForge.SFN_Power,id:6191,x:34622,y:32622,varname:node_6191,prsc:2|VAL-4115-OUT,EXP-6673-OUT;n:type:ShaderForge.SFN_Add,id:7105,x:34829,y:32622,varname:node_7105,prsc:2|A-6191-OUT,B-2004-OUT;n:type:ShaderForge.SFN_Clamp01,id:3203,x:34989,y:32622,varname:node_3203,prsc:2|IN-7105-OUT;n:type:ShaderForge.SFN_Color,id:5600,x:35639,y:32908,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_5600,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.2426471,c2:0.6239352,c3:1,c4:1;n:type:ShaderForge.SFN_Relay,id:3003,x:34926,y:32940,varname:node_3003,prsc:2|IN-3203-OUT;n:type:ShaderForge.SFN_Multiply,id:7824,x:35045,y:32956,varname:node_7824,prsc:2|A-3003-OUT,B-7546-OUT;n:type:ShaderForge.SFN_Slider,id:7546,x:34852,y:33100,ptovrint:False,ptlb:refractorSTR,ptin:_refractorSTR,varname:node_7546,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0.01,cur:1,max:1;n:type:ShaderForge.SFN_Multiply,id:8616,x:35210,y:32956,varname:node_8616,prsc:2|A-7824-OUT,B-7824-OUT;n:type:ShaderForge.SFN_Rotator,id:5682,x:35454,y:32908,varname:node_5682,prsc:2|UVIN-8874-UVOUT,ANG-8616-OUT;n:type:ShaderForge.SFN_ScreenPos,id:8874,x:35210,y:32815,varname:node_8874,prsc:2,sctp:0;n:type:ShaderForge.SFN_SceneColor,id:7928,x:35454,y:32757,varname:node_7928,prsc:2|UVIN-5682-UVOUT;n:type:ShaderForge.SFN_Clamp01,id:5963,x:35639,y:32757,varname:node_5963,prsc:2|IN-7928-RGB;n:type:ShaderForge.SFN_Lerp,id:6629,x:35831,y:32757,varname:node_6629,prsc:2|A-5963-OUT,B-5600-RGB,T-3203-OUT;n:type:ShaderForge.SFN_Tex2d,id:1650,x:35488,y:33221,ptovrint:False,ptlb:node_1650,ptin:_node_1650,varname:node_1650,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:8afd37297bf9f044693a9d2a8b607fe1,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:9950,x:35910,y:33121,varname:node_9950,prsc:2|A-1650-RGB,B-5600-RGB;n:type:ShaderForge.SFN_Lerp,id:859,x:36120,y:33131,varname:node_859,prsc:2|A-4515-OUT,B-9950-OUT,T-1650-R;n:type:ShaderForge.SFN_Noise,id:4322,x:35647,y:33438,varname:node_4322,prsc:2|XY-6691-OUT;n:type:ShaderForge.SFN_TexCoord,id:7501,x:35267,y:33434,varname:node_7501,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Multiply,id:6691,x:35472,y:33473,varname:node_6691,prsc:2|A-7501-UVOUT,B-1253-TSL;n:type:ShaderForge.SFN_Time,id:1253,x:35242,y:33631,varname:node_1253,prsc:2;n:type:ShaderForge.SFN_Multiply,id:4515,x:36070,y:32915,varname:node_4515,prsc:2|A-6629-OUT,B-4322-OUT;proporder:2015-6369-9954-6673-5600-7546-1650;pass:END;sub:END;*/

Shader "Shader Forge/exit" {
    Properties {
        _TWIRL ("TWIRL", Range(-8, 8)) = 4.2
        _SpinSpeed ("SpinSpeed", Range(-0.5, 0.5)) = -0.1
        _NumSpookesX2 ("NumSpookesX2", Range(1, 6)) = 1.6
        _CenterPower ("CenterPower", Range(3, 0.5)) = 1.5
        _Color ("Color", Color) = (0.2426471,0.6239352,1,1)
        _refractorSTR ("refractorSTR", Range(0.01, 1)) = 1
        _node_1650 ("node_1650", 2D) = "white" {}
        [MaterialToggle] PixelSnap ("Pixel snap", Float) = 0
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
            "CanUseSpriteAtlas"="True"
            "PreviewType"="Plane"
        }
        GrabPass{ }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend One OneMinusSrcAlpha
            Cull Off
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #pragma multi_compile _ PIXELSNAP_ON
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform sampler2D _GrabTexture;
            uniform float4 _TimeEditor;
            uniform float _TWIRL;
            uniform float _SpinSpeed;
            uniform float _NumSpookesX2;
            uniform float _CenterPower;
            uniform float4 _Color;
            uniform float _refractorSTR;
            uniform sampler2D _node_1650; uniform float4 _node_1650_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 screenPos : TEXCOORD1;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = UnityObjectToClipPos( v.vertex );
                #ifdef PIXELSNAP_ON
                    o.pos = UnityPixelSnap(o.pos);
                #endif
                o.screenPos = o.pos;
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                #if UNITY_UV_STARTS_AT_TOP
                    float grabSign = -_ProjectionParams.x;
                #else
                    float grabSign = _ProjectionParams.x;
                #endif
                i.screenPos = float4( i.screenPos.xy / i.screenPos.w, 0, 0 );
                i.screenPos.y *= _ProjectionParams.x;
                float2 sceneUVs = float2(1,grabSign)*i.screenPos.xy*0.5+0.5;
                float4 sceneColor = tex2D(_GrabTexture, sceneUVs);
////// Lighting:
////// Emissive:
                float node_4197 = 0.5;
                float node_2330 = saturate((1.0 - length(abs(((i.uv0-node_4197)/node_4197)))));
                float node_4115 = node_2330;
                float4 node_7524 = _Time + _TimeEditor;
                float node_3017_ang = ((node_2330*_TWIRL)+(frac((node_7524.g*_SpinSpeed))*6.28318530718));
                float node_3017_spd = 1.0;
                float node_3017_cos = cos(node_3017_spd*node_3017_ang);
                float node_3017_sin = sin(node_3017_spd*node_3017_ang);
                float2 node_3017_piv = float2(0.5,0.5);
                float2 node_3017 = (mul(i.uv0-node_3017_piv,float2x2( node_3017_cos, -node_3017_sin, node_3017_sin, node_3017_cos))+node_3017_piv);
                float node_6190 = 0.5;
                float2 node_6707 = abs(((node_3017-node_6190)/node_6190)).rg;
                float node_3203 = saturate((pow(node_4115,_CenterPower)+(node_4115*abs((saturate(frac((atan2(node_6707.g,node_6707.r)*_NumSpookesX2)))*2.0+-1.0)))));
                float node_7824 = (node_3203*_refractorSTR);
                float node_5682_ang = (node_7824*node_7824);
                float node_5682_spd = 1.0;
                float node_5682_cos = cos(node_5682_spd*node_5682_ang);
                float node_5682_sin = sin(node_5682_spd*node_5682_ang);
                float2 node_5682_piv = float2(0.5,0.5);
                float2 node_5682 = (mul(i.screenPos.rg-node_5682_piv,float2x2( node_5682_cos, -node_5682_sin, node_5682_sin, node_5682_cos))+node_5682_piv);
                float4 node_1253 = _Time + _TimeEditor;
                float2 node_6691 = (i.uv0*node_1253.r);
                float2 node_4322_skew = node_6691 + 0.2127+node_6691.x*0.3713*node_6691.y;
                float2 node_4322_rnd = 4.789*sin(489.123*(node_4322_skew));
                float node_4322 = frac(node_4322_rnd.x*node_4322_rnd.y*(1+node_4322_skew.x));
                float4 _node_1650_var = tex2D(_node_1650,TRANSFORM_TEX(i.uv0, _node_1650));
                float3 node_9950 = (_node_1650_var.rgb*_Color.rgb);
                float3 emissive = lerp((lerp(saturate(tex2D( _GrabTexture, node_5682).rgb),_Color.rgb,node_3203)*node_4322),node_9950,_node_1650_var.r);
                float3 finalColor = emissive;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
        Pass {
            Name "ShadowCaster"
            Tags {
                "LightMode"="ShadowCaster"
            }
            Offset 1, 1
            Cull Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_SHADOWCASTER
            #pragma multi_compile _ PIXELSNAP_ON
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            struct VertexInput {
                float4 vertex : POSITION;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.pos = UnityObjectToClipPos( v.vertex );
                #ifdef PIXELSNAP_ON
                    o.pos = UnityPixelSnap(o.pos);
                #endif
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
