// Shader created with Shader Forge v1.37 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.37;sub:START;pass:START;ps:flbk:,iptp:1,cusa:True,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:True,tesm:0,olmd:1,culm:2,bsrc:0,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:1873,x:34538,y:32921,varname:node_1873,prsc:2|emission-1111-OUT,alpha-1838-OUT;n:type:ShaderForge.SFN_TexCoord,id:2732,x:31978,y:32875,varname:node_2732,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_RemapRange,id:6044,x:32174,y:32875,varname:node_6044,prsc:2,frmn:0,frmx:1,tomn:-1,tomx:1|IN-2732-UVOUT;n:type:ShaderForge.SFN_ArcTan2,id:8087,x:32515,y:32901,varname:node_8087,prsc:2,attp:2|A-3401-G,B-3401-R;n:type:ShaderForge.SFN_ComponentMask,id:3401,x:32336,y:32901,varname:node_3401,prsc:2,cc1:0,cc2:1,cc3:-1,cc4:-1|IN-6044-OUT;n:type:ShaderForge.SFN_Slider,id:1279,x:32193,y:32762,ptovrint:False,ptlb:health,ptin:_health,varname:node_1279,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.3589744,max:1;n:type:ShaderForge.SFN_Ceil,id:7803,x:32869,y:32858,varname:node_7803,prsc:2|IN-5972-OUT;n:type:ShaderForge.SFN_Subtract,id:5972,x:32701,y:32886,varname:node_5972,prsc:2|A-8087-OUT,B-1279-OUT;n:type:ShaderForge.SFN_OneMinus,id:1551,x:32571,y:32645,varname:node_1551,prsc:2|IN-1279-OUT;n:type:ShaderForge.SFN_Color,id:3245,x:32626,y:33103,ptovrint:False,ptlb:healedColor,ptin:_healedColor,varname:node_3245,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.6323529,c2:0.9543611,c3:1,c4:0.647;n:type:ShaderForge.SFN_Color,id:5911,x:32801,y:32633,ptovrint:False,ptlb:damageColor,ptin:_damageColor,varname:node_5911,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:0,c3:0,c4:0.297;n:type:ShaderForge.SFN_Multiply,id:7807,x:33044,y:32783,varname:node_7807,prsc:2|A-5911-RGB,B-7803-OUT;n:type:ShaderForge.SFN_Multiply,id:7680,x:33088,y:33130,varname:node_7680,prsc:2|A-9577-OUT,B-3245-RGB;n:type:ShaderForge.SFN_OneMinus,id:9577,x:32940,y:33020,varname:node_9577,prsc:2|IN-7803-OUT;n:type:ShaderForge.SFN_Add,id:394,x:33265,y:32954,varname:node_394,prsc:2|A-7807-OUT,B-7680-OUT;n:type:ShaderForge.SFN_Slider,id:2518,x:33326,y:33206,ptovrint:False,ptlb:opacity,ptin:_opacity,varname:node_2518,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_Multiply,id:4292,x:33532,y:33011,varname:node_4292,prsc:2|A-394-OUT,B-2518-OUT;n:type:ShaderForge.SFN_Tex2d,id:8453,x:33215,y:33386,ptovrint:False,ptlb:mask,ptin:_mask,varname:node_8453,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:1d2107a58e8735b49bacd25c7913034b,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:1838,x:34040,y:33249,varname:node_1838,prsc:2|A-2518-OUT,B-8453-A,C-5960-OUT;n:type:ShaderForge.SFN_Multiply,id:1111,x:34119,y:32823,varname:node_1111,prsc:2|A-4292-OUT,B-1838-OUT;n:type:ShaderForge.SFN_Multiply,id:3587,x:33545,y:32613,varname:node_3587,prsc:2|A-5911-A,B-7803-OUT;n:type:ShaderForge.SFN_Multiply,id:2884,x:33587,y:33463,varname:node_2884,prsc:2|A-3245-A,B-9577-OUT;n:type:ShaderForge.SFN_Add,id:5960,x:33814,y:32688,varname:node_5960,prsc:2|A-3587-OUT,B-2884-OUT;proporder:1279-3245-5911-2518-8453;pass:END;sub:END;*/

Shader "Shader Forge/HealthShader" {
    Properties {
        _health ("health", Range(0, 1)) = 0.3589744
        _healedColor ("healedColor", Color) = (0.6323529,0.9543611,1,0.647)
        _damageColor ("damageColor", Color) = (1,0,0,0.297)
        _opacity ("opacity", Range(0, 1)) = 1
        _mask ("mask", 2D) = "white" {}
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
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
            uniform float _health;
            uniform float4 _healedColor;
            uniform float4 _damageColor;
            uniform float _opacity;
            uniform sampler2D _mask; uniform float4 _mask_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = UnityObjectToClipPos( v.vertex );
                #ifdef PIXELSNAP_ON
                    o.pos = UnityPixelSnap(o.pos);
                #endif
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
////// Lighting:
////// Emissive:
                float2 node_3401 = (i.uv0*2.0+-1.0).rg;
                float node_7803 = ceil((((atan2(node_3401.g,node_3401.r)/6.28318530718)+0.5)-_health));
                float node_9577 = (1.0 - node_7803);
                float4 _mask_var = tex2D(_mask,TRANSFORM_TEX(i.uv0, _mask));
                float node_1838 = (_opacity*_mask_var.a*((_damageColor.a*node_7803)+(_healedColor.a*node_9577)));
                float3 node_1111 = ((((_damageColor.rgb*node_7803)+(node_9577*_healedColor.rgb))*_opacity)*node_1838);
                float3 emissive = node_1111;
                float3 finalColor = emissive;
                return fixed4(finalColor,node_1838);
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
