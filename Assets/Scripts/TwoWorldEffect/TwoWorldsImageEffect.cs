using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TwoWorldsImageEffect : MonoBehaviour {

    public Material material;
    public RenderTexture portalRenderTexture;

    private void Awake()
    {
        portalRenderTexture.width = Screen.width;
        portalRenderTexture.height = Screen.height;
    }

    private void Update()
    {
        Vector2 mousePos = Input.mousePosition;
        mousePos.x /= Screen.width;
        mousePos.y /= Screen.height;
        material.SetFloat("_mouseX", mousePos.x);
        material.SetFloat("_mouseY", mousePos.y);


    }

    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        // Copy the source Render Texture to the destination,
        // applying the material along the way.
        Graphics.Blit(source, destination, material);
    }
}
