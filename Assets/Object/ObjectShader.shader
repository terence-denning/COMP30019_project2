
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
        sampler2D _DissolveTexture;
        
        struct Input
        {
            float2 uv_MainTex;
            float3 worldPos;
            float3 customColor;
        };
        
        //noise function reference to Noise Shader Library for Unity - https://github.com/keijiro/NoiseShader
        #define NOISE_SIMPLEX_1_DIV_289 0.00346020761245674740484429065744f
        
        float mod289(float x) {
            return x - floor(x * NOISE_SIMPLEX_1_DIV_289) * 289.0;
        }
        
        float2 mod289(float2 x) {
            return x - floor(x * NOISE_SIMPLEX_1_DIV_289) * 289.0;
        }
        
        float3 mod289(float3 x) {
            return x - floor(x * NOISE_SIMPLEX_1_DIV_289) * 289.0;
        }
        
        float4 mod289(float4 x) {
            return x - floor(x * NOISE_SIMPLEX_1_DIV_289) * 289.0;
        }
        
        
        float permute(float x) {
            return mod289(
                x*x*34.0 + x
            );
        }
        
        float3 permute(float3 x) {
            return mod289(
                x*x*34.0 + x
            );
        }
        
        float4 permute(float4 x) {
            return mod289(
                x*x*34.0 + x
            );
        }
        
        
        
        float4 grad4(float j, float4 ip)
        {
            const float4 ones = float4(1.0, 1.0, 1.0, -1.0);
            float4 p, s;
            p.xyz = floor( frac(j * ip.xyz) * 7.0) * ip.z - 1.0;
            p.w = 1.5 - dot( abs(p.xyz), ones.xyz );
            
            // GLSL: lessThan(x, y) = x < y
            // HLSL: 1 - step(y, x) = x < y
            p.xyz -= sign(p.xyz) * (p.w < 0);
            
            return p;
        }
        
        float snoise(float3 v)
        {
            const float2 C = float2(
                0.166666666666666667, // 1/6
                0.333333333333333333  // 1/3
            );
            const float4 D = float4(0.0, 0.5, 1.0, 2.0);
            
        // First corner
            float3 i = floor( v + dot(v, C.yyy) );
            float3 x0 = v - i + dot(i, C.xxx);
            
        // Other corners
            float3 g = step(x0.yzx, x0.xyz);
            float3 l = 1 - g;
            float3 i1 = min(g.xyz, l.zxy);
            float3 i2 = max(g.xyz, l.zxy);
            
            float3 x1 = x0 - i1 + C.xxx;
            float3 x2 = x0 - i2 + C.yyy; // 2.0*C.x = 1/3 = C.y
            float3 x3 = x0 - D.yyy;      // -1.0+3.0*C.x = -0.5 = -D.y
            
        // Permutations
            i = mod289(i);
            float4 p = permute(
                permute(
                    permute(
                            i.z + float4(0.0, i1.z, i2.z, 1.0 )
                    ) + i.y + float4(0.0, i1.y, i2.y, 1.0 )
                ) 	+ i.x + float4(0.0, i1.x, i2.x, 1.0 )
            );
            
        // Gradients: 7x7 points over a square, mapped onto an octahedron.
        // The ring size 17*17 = 289 is close to a multiple of 49 (49*6 = 294)
            float n_ = 0.142857142857; // 1/7
            float3 ns = n_ * D.wyz - D.xzx;
            
            float4 j = p - 49.0 * floor(p * ns.z * ns.z); // mod(p,7*7)
            
            float4 x_ = floor(j * ns.z);
            float4 y_ = floor(j - 7.0 * x_ ); // mod(j,N)
            
            float4 x = x_ *ns.x + ns.yyyy;
            float4 y = y_ *ns.x + ns.yyyy;
            float4 h = 1.0 - abs(x) - abs(y);
            
            float4 b0 = float4( x.xy, y.xy );
            float4 b1 = float4( x.zw, y.zw );
            
            //float4 s0 = float4(lessThan(b0,0.0))*2.0 - 1.0;
            //float4 s1 = float4(lessThan(b1,0.0))*2.0 - 1.0;
            float4 s0 = floor(b0)*2.0 + 1.0;
            float4 s1 = floor(b1)*2.0 + 1.0;
            float4 sh = -step(h, 0.0);
            
            float4 a0 = b0.xzyw + s0.xzyw*sh.xxyy ;
            float4 a1 = b1.xzyw + s1.xzyw*sh.zzww ;
            
            float3 p0 = float3(a0.xy,h.x);
            float3 p1 = float3(a0.zw,h.y);
            float3 p2 = float3(a1.xy,h.z);
            float3 p3 = float3(a1.zw,h.w);
            
        //Normalise gradients
            float4 norm = rsqrt(float4(
                dot(p0, p0),
                dot(p1, p1),
                dot(p2, p2),
                dot(p3, p3)
            ));
            p0 *= norm.x;
            p1 *= norm.y;
            p2 *= norm.z;
            p3 *= norm.w;
            
        // Mix final noise value
            float4 m = max(
                0.6 - float4(
                    dot(x0, x0),
                    dot(x1, x1),
                    dot(x2, x2),
                    dot(x3, x3)
                ),
                0.0
            );
            m = m * m;
            return 42.0 * dot(
                m*m,
                float4(
                    dot(p0, x0),
                    dot(p1, x1),
                    dot(p2, x2),
                    dot(p3, x3)
                )
            );
        }
        //End of noise function  
        
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
            float fAtt = 1;
            float Kd = 1;
            float3 L = normalize(_PointLightPosition - worldVertex.xyz);
            float LdotN = dot(L, worldNormal.xyz);
            float3 dif = fAtt * _PointLightColor.rgb * Kd * v.color.rgb * saturate(LdotN);
            float Ks = 1;
            float specN = 10; // Values>>1 give tighter highlights
            float3 V = normalize(_WorldSpaceCameraPos - worldVertex.xyz);
            float3 H = normalize(V + L);
            float3 spe = fAtt * _PointLightColor.rgb * Ks * pow(saturate(dot(worldNormal, H)), specN);
            o.customColor.rgb = attenuation * (MatD+amb.rgb + dif.rgb + spe.rgb);
        }

        // Reference to Tutorial https://www.febucci.com/2018/09/world-reveal-shader/
       
        
        void surf (Input IN, inout SurfaceOutput o)
        {
             float distan = distance(_PlayerPos, IN.worldPos);
             half disslov = abs(snoise(IN.worldPos));
             
             float clip1 = (disslov - (distan - _Radius) /  _Radius) * step(  _Radius , distan ) ;
             clip(clip1);
             
             o.Emission = float3(1, 1, 1) * step( clip1 , 0.05f ) * step( _Radius, distan);
             
             fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
             o.Albedo = c.rgb + IN.customColor;
            
        }
        //End of reveald shader 
        
    
       
        ENDCG
    }
    FallBack "Diffuse"
}
