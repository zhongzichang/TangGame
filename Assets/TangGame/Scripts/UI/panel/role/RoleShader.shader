Shader "Custom/RoleShader" {
	Properties 
   	{
    	_MainTex ("Texture", 2D )				= "black" {} 
       	_echoUV("UV Offset u1 v1", Vector )		= ( 0, 0, 0, 0 )
  	}
   
	SubShader 
	{
		Tags { "Queue"="Transparent+500" "IgnoreProjector"="True"  }

    	Pass 
		{    
      	 	ZWrite Off
      	 	Blend SrcAlpha One
     		
			CGPROGRAM
			
 			#pragma vertex vert
			#pragma fragment frag
			#pragma fragmentoption ARB_precision_hint_fastest

			#include "UnityCG.cginc"

			sampler2D	_MainTex;
			float4		_MainTex_ST;
			float4 		_MainTex_TexelSize;
			float4      _echoUV;

           	struct VertInput
            {
                float4 vertex	: POSITION;
                float2 texcoord	: TEXCOORD0;
            };

           	struct Varys
            {
                half4 pos		: SV_POSITION;
                half2 tc1		: TEXCOORD0;
            };
	
			Varys vert ( VertInput ad )
			{
				Varys v;

    			v.pos			= mul ( UNITY_MATRIX_MVP, ad.vertex );
   				v.tc1 	  		= _MainTex_ST.xy * ( ad.texcoord.xy + _echoUV.xy + _MainTex_ST.zw );

	#if UNITY_UV_STARTS_AT_TOP
				if ( _MainTex_TexelSize.y < 0 )
					v.tc1.y = 1.0-v.tc1.y;
	#endif
				return v;
			}
 	
			fixed4 frag ( Varys v ):COLOR
			{
    			return tex2D ( _MainTex, v.tc1 );
			}

			ENDCG
		}
 	}
}



