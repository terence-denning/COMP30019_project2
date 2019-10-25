
Shader "Custom/ObjectShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _PointLightColor("Point Light Color", Color) = (0, 0, 0)
		_PointLightPosition("Point Light Position", Vector) = (0.0, 0.0, 0.0)
		_LightRange("LightRange",float) = 0 
		_Radius("Radius",float) = 0 
		_PlayerPos("PlayerPos",Vector) = (0.0, 0.0, 0.0)
		_Worldpos("Worldpos",Vector) = (0.0, 0.0, 0.0)
		_Color("Color",Color) = (0, 0, 0)
    }
    SubShader
    {
        Cull off
        	Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"
            float3 _PointLightColor;
            float3 _PointLightPosition;
            sampler2D _MainTex;
            float4 _MainTex_ST;
            float _LightRange = 0;//Globle variable
            float3 _PlayerPos; //Globle variable
            float3 _Worldpos;
            float _Radius ;
            float _CutOff;
            float3 _Color;
             
            
            struct vertIn
			{
				float4 vertex : POSITION;
				float4 normal : NORMAL;
				float4 color : COLOR;
				 float2 uv : TEXCOORD2;
			};

			struct vertOut
			{
				float4 vertex : SV_POSITION;
				float4 color : COLOR;
				float4 worldVertex : TEXCOORD0;
				float3 worldNormal : TEXCOORD1;
				float2 uv : TEXCOORD2;
			};
			vertOut vert(vertIn v)
			{
			    vertOut o;
				float4 worldVertex = mul ((float4x4)unity_ObjectToWorld, v.vertex );
				float3 worldNormal = normalize(mul(transpose((float3x3)unity_WorldToObject), v.normal.xyz));
				o.vertex = UnityObjectToClipPos(v.vertex);
				v.color.rgb = _Color.rgb;
				o.color = v.color;
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				o.worldVertex = worldVertex;
				o.worldNormal = worldNormal;
				return o;
			}
			
            fixed4 frag(vertOut v) : SV_Target
			{
			    fixed4 albedo = tex2D(_MainTex, v.uv) * v.color;
			    float distan = distance(_PlayerPos, v.worldVertex);
                float radius = 1.2;
                 clip(radius - distan);              
                 return albedo ;

			}
            ENDCG
        }
       
    }
    
}
