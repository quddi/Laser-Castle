Shader "Dunno/Circle"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _Radius ("Radius", Range(0, 0.25)) = 0
        _CentreX ("Centre X", Range(0, 1.0)) = 0
        _CentreY ("Centre Y", Range(0, 1.0)) = 0
        _Feather ("Feather", Range(0, 1)) = 0.05
    }
    SubShader
    {
        Tags { "Queue" = "Transparent" "IgnoreProjector" = "True" "RenderType"="Transparent" }

        Pass
        {
            Blend SrcAlpha OneMinusSrcAlpha
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct vertexInput
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct vertexOutput
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };
            
            float _Radius;
            float _CentreX;
            float _CentreY;
            float _Feather;
            half4 _Color;

            vertexOutput vert (vertexInput v)
            {
                vertexOutput o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            float drawCircle(float2 uv)
            {
                float distance = pow(uv.x - _CentreX, 2) + pow(uv.y - _CentreY, 2);
                
                return smoothstep(_Radius, _Radius - _Feather, distance);
            }
            
            half4 frag (vertexOutput i) : SV_Target
            {
                half4 color = _Color;
                color.a = drawCircle(i.uv);
                
                return color;
            }
            ENDCG
        }
    }
}