// Shader created with Shader Forge v1.37 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.37;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:3138,x:34656,y:32813,varname:node_3138,prsc:2|emission-7966-OUT,alpha-8732-OUT;n:type:ShaderForge.SFN_Slider,id:5905,x:32308,y:32661,ptovrint:False,ptlb:Desaturation,ptin:_Desaturation,varname:node_5905,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.6807877,max:1;n:type:ShaderForge.SFN_Color,id:6744,x:32413,y:32466,ptovrint:False,ptlb:Tint,ptin:_Tint,varname:node_6744,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5780933,c2:1,c3:0.4117647,c4:1;n:type:ShaderForge.SFN_Append,id:3695,x:32434,y:33175,varname:node_3695,prsc:2|A-1642-X,B-1642-Y;n:type:ShaderForge.SFN_Append,id:5612,x:32310,y:33311,varname:node_5612,prsc:2|A-9151-OUT,B-2874-OUT;n:type:ShaderForge.SFN_ValueProperty,id:2874,x:32070,y:33345,ptovrint:False,ptlb:LineDensity,ptin:_LineDensity,varname:node_2874,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.5;n:type:ShaderForge.SFN_Multiply,id:9262,x:32737,y:33303,varname:node_9262,prsc:2|A-3695-OUT,B-5612-OUT;n:type:ShaderForge.SFN_ValueProperty,id:2530,x:32336,y:33538,ptovrint:False,ptlb:speed,ptin:_speed,varname:node_2530,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_ValueProperty,id:8629,x:32336,y:33616,ptovrint:False,ptlb:speed2,ptin:_speed2,varname:node_8629,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:25;n:type:ShaderForge.SFN_Append,id:9217,x:32496,y:33538,varname:node_9217,prsc:2|A-2530-OUT,B-8629-OUT;n:type:ShaderForge.SFN_Time,id:655,x:32496,y:33696,varname:node_655,prsc:2;n:type:ShaderForge.SFN_Multiply,id:8707,x:32737,y:33538,varname:node_8707,prsc:2|A-9217-OUT,B-655-TSL;n:type:ShaderForge.SFN_Add,id:6536,x:32935,y:33403,varname:node_6536,prsc:2|A-9262-OUT,B-8707-OUT;n:type:ShaderForge.SFN_OneMinus,id:3421,x:33116,y:33427,varname:node_3421,prsc:2|IN-6536-OUT;n:type:ShaderForge.SFN_ComponentMask,id:8251,x:33289,y:33467,varname:node_8251,prsc:2,cc1:1,cc2:-1,cc3:-1,cc4:-1|IN-3421-OUT;n:type:ShaderForge.SFN_Frac,id:5004,x:33456,y:33371,varname:node_5004,prsc:2|IN-8251-OUT;n:type:ShaderForge.SFN_Power,id:7460,x:33634,y:33403,varname:node_7460,prsc:2|VAL-5004-OUT,EXP-3705-OUT;n:type:ShaderForge.SFN_ValueProperty,id:3705,x:33456,y:33556,ptovrint:False,ptlb:scanline EXP,ptin:_scanlineEXP,varname:node_3705,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:10;n:type:ShaderForge.SFN_Multiply,id:9762,x:33883,y:33425,varname:node_9762,prsc:2|A-7460-OUT,B-2033-OUT;n:type:ShaderForge.SFN_Slider,id:2033,x:33522,y:33655,ptovrint:False,ptlb:scanlineOpacity,ptin:_scanlineOpacity,varname:node_2033,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.3080601,max:1;n:type:ShaderForge.SFN_Add,id:6548,x:34105,y:33454,varname:node_6548,prsc:2|A-9762-OUT,B-9915-OUT;n:type:ShaderForge.SFN_Slider,id:9915,x:33907,y:33763,ptovrint:False,ptlb:opacity,ptin:_opacity,varname:node_9915,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.6324797,max:1;n:type:ShaderForge.SFN_ScreenPos,id:9487,x:32863,y:33009,varname:node_9487,prsc:2,sctp:0;n:type:ShaderForge.SFN_Time,id:343,x:32863,y:33163,varname:node_343,prsc:2;n:type:ShaderForge.SFN_Multiply,id:3460,x:33030,y:33095,varname:node_3460,prsc:2|A-9487-UVOUT,B-343-TSL;n:type:ShaderForge.SFN_Noise,id:2554,x:33197,y:33095,varname:node_2554,prsc:2|XY-3460-OUT;n:type:ShaderForge.SFN_RemapRange,id:4421,x:33354,y:33095,varname:node_4421,prsc:2,frmn:0,frmx:1,tomn:0.5,tomx:1|IN-2554-OUT;n:type:ShaderForge.SFN_Multiply,id:807,x:33536,y:33095,varname:node_807,prsc:2|A-4421-OUT,B-625-OUT;n:type:ShaderForge.SFN_ValueProperty,id:625,x:33354,y:33269,ptovrint:False,ptlb:fuzz power,ptin:_fuzzpower,varname:node_625,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.5;n:type:ShaderForge.SFN_Lerp,id:6107,x:33757,y:33108,varname:node_6107,prsc:2|A-3996-OUT,B-807-OUT,T-625-OUT;n:type:ShaderForge.SFN_Vector1,id:3996,x:33497,y:33003,varname:node_3996,prsc:2,v1:1;n:type:ShaderForge.SFN_Vector1,id:9151,x:32070,y:33264,varname:node_9151,prsc:2,v1:1;n:type:ShaderForge.SFN_FragmentPosition,id:1642,x:32143,y:33041,varname:node_1642,prsc:2;n:type:ShaderForge.SFN_OneMinus,id:8118,x:32677,y:32655,varname:node_8118,prsc:2|IN-5905-OUT;n:type:ShaderForge.SFN_Desaturate,id:8694,x:32878,y:32487,varname:node_8694,prsc:2|COL-6744-RGB,DES-8118-OUT;n:type:ShaderForge.SFN_Tex2d,id:2145,x:34246,y:33221,ptovrint:False,ptlb:maskTexture,ptin:_maskTexture,varname:node_2145,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:c5adc3d876c1c4543b8be5e22ed31fc7,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:8732,x:34435,y:33310,varname:node_8732,prsc:2|A-2145-R,B-6548-OUT;n:type:ShaderForge.SFN_Multiply,id:7966,x:34471,y:32977,varname:node_7966,prsc:2|A-7333-OUT,B-8732-OUT;n:type:ShaderForge.SFN_Multiply,id:7333,x:33983,y:32914,varname:node_7333,prsc:2|A-8694-OUT,B-6107-OUT;proporder:5905-6744-2874-2530-8629-3705-2033-9915-625-2145;pass:END;sub:END;*/

Shader "Shader Forge/test" {
    Properties {
        _Desaturation ("Desaturation", Range(0, 1)) = 0.6807877
        _Tint ("Tint", Color) = (0.5780933,1,0.4117647,1)
        _LineDensity ("LineDensity", Float ) = 0.5
        _speed ("speed", Float ) = 1
        _speed2 ("speed2", Float ) = 25
        _scanlineEXP ("scanline EXP", Float ) = 10
        _scanlineOpacity ("scanlineOpacity", Range(0, 1)) = 0.3080601
        _opacity ("opacity", Range(0, 1)) = 0.6324797
        _fuzzpower ("fuzz power", Float ) = 0.5
        _maskTexture ("maskTexture", 2D) = "white" {}
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend SrcAlpha OneMinusSrcAlpha
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform float _Desaturation;
            uniform float4 _Tint;
            uniform float _LineDensity;
            uniform float _speed;
            uniform float _speed2;
            uniform float _scanlineEXP;
            uniform float _scanlineOpacity;
            uniform float _opacity;
            uniform float _fuzzpower;
            uniform sampler2D _maskTexture; uniform float4 _maskTexture_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float4 screenPos : TEXCOORD2;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos( v.vertex );
                o.screenPos = o.pos;
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.screenPos = float4( i.screenPos.xy / i.screenPos.w, 0, 0 );
                i.screenPos.y *= _ProjectionParams.x;
////// Lighting:
////// Emissive:
                float3 node_8694 = lerp(_Tint.rgb,dot(_Tint.rgb,float3(0.3,0.59,0.11)),(1.0 - _Desaturation));
                float4 node_343 = _Time + _TimeEditor;
                float2 node_3460 = (i.screenPos.rg*node_343.r);
                float2 node_2554_skew = node_3460 + 0.2127+node_3460.x*0.3713*node_3460.y;
                float2 node_2554_rnd = 4.789*sin(489.123*(node_2554_skew));
                float node_2554 = frac(node_2554_rnd.x*node_2554_rnd.y*(1+node_2554_skew.x));
                float node_6107 = lerp(1.0,((node_2554*0.5+0.5)*_fuzzpower),_fuzzpower);
                float4 _maskTexture_var = tex2D(_maskTexture,TRANSFORM_TEX(i.uv0, _maskTexture));
                float4 node_655 = _Time + _TimeEditor;
                float node_9762 = (pow(frac((1.0 - ((float2(i.posWorld.r,i.posWorld.g)*float2(1.0,_LineDensity))+(float2(_speed,_speed2)*node_655.r))).g),_scanlineEXP)*_scanlineOpacity);
                float node_6548 = (node_9762+_opacity);
                float node_8732 = (_maskTexture_var.r*node_6548);
                float3 emissive = ((node_8694*node_6107)*node_8732);
                float3 finalColor = emissive;
                return fixed4(finalColor,node_8732);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
