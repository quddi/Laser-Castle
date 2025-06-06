Shader "Custom/SlimeSpriteShader"
{
    Properties
    {
        _BaseMap ("Base Map", 2D) = "white" {}
        _TileX ("Tile Count X", Float) = 1
        _TileY ("Tile Count Y", Float) = 1
        _IndexX ("Tile Index X", Float) = 0
        _IndexY ("Tile Index Y", Float) = 0
        _Width ("Width", Float) = 1
        _Height ("Height", Float) = 1
    }
    SubShader
    {
        Tags { "RenderType"="Transparent" "Queue"="Transparent" }
        LOD 100
        
        Pass
        {
            Cull Off
            ZWrite Off
            Blend SrcAlpha OneMinusSrcAlpha
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata_t
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _BaseMap;
            float4 _BaseMap_ST;
            float _TileX;
            float _TileY;
            int _IndexX;
            int _IndexY;
            float _Width;
            float _Height;

            v2f vert (appdata_t v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                float2 tileSize = float2(1.0 / _TileX, (1 / _TileY));
                float2 tileOffset = float2(_IndexX, _IndexY) * tileSize;
                float2 tiledUV = frac(i.uv) * tileSize + tileOffset;                
                fixed4 result = tex2D(_BaseMap, tiledUV);
                
                return result;
            }
            ENDCG
        }
    }
}
