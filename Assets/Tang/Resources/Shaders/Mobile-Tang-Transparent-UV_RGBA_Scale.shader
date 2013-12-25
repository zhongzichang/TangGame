// Specular, Normal Maps with Main Texture for highlight
// Fragment based
// Date: 2013/10/30
// Author: zzc
Shader "Mobile/Tang/Transparent/UV_RGBA_Scale"
{
  Properties 
  {
    _MainTex ("Texture", 2D) = "white" {}
    _tangUV("UV Offset u1 v1", Vector )		= ( 0, 0, 0, 0 )
    _tangRGBA ( "RGB Multiply", Vector )		= ( 1, 1, 1, 1 )    
    _tangScale ("Scale XYZ", Vector )		= ( 1.0, 1.0, 1.0, 1.0 )
  }

  //=========================================================================
  SubShader 
  {
    Tags { "Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent" }

    Pass 
    {    
      ZWrite Off
      Blend SrcAlpha OneMinusSrcAlpha
      Cull Back

      CGPROGRAM

      #pragma vertex vert
      #pragma fragment frag
      #pragma fragmentoption ARB_precision_hint_fastest

      #include "UnityCG.cginc"

      sampler2D	_MainTex;
      float4		_MainTex_ST;
      float4		_MainTex_TexelSize;
      float4      _tangUV;
      float4		_tangRGBA;
      float4      _tangScale;

      struct VertInput
      {
        float4 vertex	: POSITION;
        float2 texcoord	: TEXCOORD0;
        float4 color	: COLOR;
      };

      struct Varys
      {
        half4 pos		: SV_POSITION;
        half2 tc1		: TEXCOORD0;
        fixed4 vcolor	: TEXCOORD1;
      };

      //=============================================
      Varys vert ( VertInput ad )
      {
        Varys v;

        v.vcolor	= ad.color * _tangRGBA;
        v.pos 		= mul ( UNITY_MATRIX_MVP, ad.vertex * _tangScale );
        v.tc1 		= _MainTex_ST.xy * ( ad.texcoord.xy + _tangUV.xy + _MainTex_ST.zw );

#if UNITY_UV_STARTS_AT_TOP
        if ( _MainTex_TexelSize.y < 0 )
          v.tc1.y = 1.0-v.tc1.y;
#endif
        return v;
      }

      //=============================================
      fixed4 frag ( Varys v ):COLOR
      {
        return tex2D ( _MainTex, v.tc1 ) * v.vcolor;
      }

      ENDCG
      }
   } // eo Properties

} // eo Shader