Shader "Other/WorldPortalShader" 
{
    Properties 
    {
        _MainTex ("Render Base", 2D) = "white" {}
        _PortalTex ("Portal RenderTexture", 2D) = "white" {}
        _PortalMask ("Portal Mask", 2D) = "white" {}
        _maskScale ("MaskScale", Range (0, 1)) = 0
        
        _mouseX ("Mouse X", Range (0, 1)) = 0
        _mouseY ("Mouse Y", Range (0, 1)) = 0
    }
    SubShader 
    {
        Pass 
        {
            CGPROGRAM
            #pragma vertex vert_img
            #pragma fragment frag

            #include "UnityCG.cginc"

            uniform sampler2D _MainTex;
            uniform sampler2D _PortalTex;
            uniform sampler2D _PortalMask;
            
            uniform float _maskScale;
            uniform float _mouseX;
            uniform float _mouseY;

            float4 frag(v2f_img i) : COLOR 
            {
                float4 colorWorld = tex2D(_MainTex, i.uv);
                float4 colorPortal = tex2D(_PortalTex, i.uv);
                
                float2 maskUV = i.uv;
                maskUV.x = clamp(maskUV.x - _mouseX + 0.5f,0,1);
                maskUV.y = clamp(maskUV.y - _mouseY + 0.5f,0,1);
                float4 colorMask = tex2D(_PortalMask, maskUV);
                float4 color;
                
                color = colorWorld * (1-colorMask.r) + colorPortal * colorMask.r;
                
                return color;
            }
        ENDCG
        }
    }
}