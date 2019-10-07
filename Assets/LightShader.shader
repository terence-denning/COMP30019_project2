
Shader "Custom/ObjectShader"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        
		
    }
    
    SubShader
    {
       
        Tags { "RenderType"="Opaque" }
        LOD 200
        Cull off

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Lambert vertex:vert
        
        #include "UnityCG.cginc"
        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0
        
        sampler2D _MainTex;
    
        
        struct Input
        {
            float2 uv_MainTex;
            float3 worldPos;
            float3 customColor;
        };
        
       
        
        //Varialbes Declaration
        float3 _PointLightColor;
        float3 _PointLightPosition;
        float _LightRange = 0;//Globle variable
        half _Glossiness;
        half _Metallic;
        fixed4 _Color;
        float3 _PlayerPos; //Globle variable
        float _Radius = 0; //Globle variable
        float4      MatD: MATERIALDIFFUSE; 
        //EOF Varialbes
        
        //Light with range function;
        void vert (inout appdata_full v, out Input o){
            UNITY_INITIALIZE_OUTPUT(Input,o);
            float4 worldVertex = mul(unity_ObjectToWorld, v.vertex);
            float3 worldNormal = normalize(mul(transpose((float3x3)unity_WorldToObject), v.normal.xyz)); 
            float dist = distance(_PointLightPosition,worldVertex);
            float attenuation = 1 - saturate(dist / _LightRange); 
            float Ka = 1;
            float3 amb = v.color.rgb * UNITY_LIGHTMODEL_AMBIENT.rgb * Ka;
            float fAtt = 0.5;
            float Kd = 0.5;
            float3 L = normalize(_PointLightPosition - worldVertex.xyz);
            float LdotN = dot(L, worldNormal.xyz);
            float3 dif = fAtt * _PointLightColor.rgb * Kd * v.color.rgb * saturate(LdotN);
            float Ks = 0.5;
            float specN = 5; // Values>>1 give tighter highlights
            float3 V = normalize(_WorldSpaceCameraPos - worldVertex.xyz);
            specN = 25; 
            float3 H = normalize(V + L);
            float3 spe = fAtt * _PointLightColor.rgb * Ks * pow(saturate(dot(worldNormal, H)), specN);
            o.customColor.rgb = attenuation * (MatD+amb.rgb + dif.rgb + spe.rgb);
        }

        // Reference to Tutorial https://www.febucci.com/2018/09/world-reveal-shader/
       
        
        void surf (Input IN, inout SurfaceOutput o)
        {
             
             
             fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
             o.Albedo = c.rgb + IN.customColor;
            
        }
        //End of reveald shader 
        
    
       
        ENDCG
    }
    FallBack "Diffuse"
}
