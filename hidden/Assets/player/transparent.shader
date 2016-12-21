Shader "Custom/TransparentSingleColorShader" {
	Properties{
		_Color("Color", Color) = (1.0, 0, 0, 0)
		_TransparentRate("Transparency", Range(0,1)) = 0
	}
		SubShader{
		Tags{ "RenderType" = "Transparent" "Queue" = "Transparent" }
		Blend SrcAlpha OneMinusSrcAlpha
		Cull Off
		LOD 200

		CGPROGRAM
		#pragma surface surf Lambert alpha

		fixed4 _Color;
		float _TransparentRate;

	// Note: pointless texture coordinate. I couldn't get Unity (or Cg)
	//       to accept an empty Input structure or omit the inputs.
	struct Input {
		float2 uv_MainTex;
	};

	void surf(Input IN, inout SurfaceOutput o) {
		o.Albedo = _Color.rgb;
		o.Emission = _Color.rgb; // * _Color.a;
		o.Alpha = _TransparentRate;
	}
	ENDCG
	}
		FallBack "Diffuse"
}