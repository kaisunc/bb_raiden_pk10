Shader "Custom/TeamColor" {
    Properties {
        _TeamColor("TeamColor", Color) = (0.5, 0.5, 0.5, 1)
        _MainTex ("Texture", 2D) = "white" {}
        _DecalAlpha ("Team Alpha Map", 2D) = "white" {}
        _BumpMap ("Bumpmap", 2D) = "bump" {}
        _NormalStrength ("Normal Strength", Range(1,2)) = 1
        _Glossiness ("Smoothness Tex", 2D) = "white" {}
        _Metallic1 ("Metallic Tex", 2D) = "white" {}
    }
    SubShader {
        Tags { "RenderType"="Opaque" }
        LOD 200
        
        CGPROGRAM
        #pragma surface surf Standard fullforwardshadows
        #pragma target 3.0
 
        sampler2D _MainTex;
 
        struct Input {
            float2 uv_MainTex;
        };
 
        sampler2D _DecalAlpha;
        fixed4 _TeamColor;

        sampler2D _Glossiness;
        sampler2D _Metallic1;
        fixed4 _Color;
         sampler2D _BumpMap;
        float _NormalStrength;
        void surf (Input IN, inout SurfaceOutputStandard o) {
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex);
            o.Albedo = (tex2D(_MainTex, IN.uv_MainTex).rgb) + (tex2D(_DecalAlpha, IN.uv_MainTex).rgb) * _TeamColor.rgb;

            // Metallic and smoothness come from slider variables
            o.Normal = UnpackNormal (tex2D (_BumpMap, IN.uv_MainTex) * _NormalStrength) ;

            o.Metallic = tex2D(_Metallic1, IN.uv_MainTex);
            o.Smoothness = tex2D(_Glossiness, IN.uv_MainTex);;
            o.Alpha = c.a;
        }
        ENDCG
    } 
    FallBack "Diffuse"
}