Shader "Custom/Redify" {
 	Properties {
 		_MainTex ("Base (RGB)", 2D) = "white" {}
 	}
 	SubShader {
 		Tags { "RenderType"="Opaque" }
 		LOD 200
 
 		CGPROGRAM
 		#pragma surface surf Lambert
 		#pragma multi_compile REDIFY_ON REDIFY_OFF
 
 		sampler2D _MainTex;
 
 		struct Input {
 			float2 uv_MainTex;
 		};
 
 		void surf (Input IN, inout SurfaceOutput o) {
 			half4 c = tex2D (_MainTex, IN.uv_MainTex);
 			o.Albedo = c.rgb;
 			o.Alpha = c.a;
 
 #if REDIFY_ON
 			o.Albedo.gb = (o.Albedo.g + o.Albedo.b) / 2.0;
 #endif
 		}
 		ENDCG
 	} 
 	FallBack "Diffuse"
 	CustomEditor "CustomMaterialInspector"
 }
 