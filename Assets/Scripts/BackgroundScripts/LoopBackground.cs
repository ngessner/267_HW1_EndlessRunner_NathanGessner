using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopBackground : MonoBehaviour
{
    public float backgroundSpeed;
    public Renderer backgroundRenderer;


    void Update()
    {
        moveBackground();
    }


    private void moveBackground()
    {
        backgroundRenderer.material.mainTextureOffset += new Vector2(0, backgroundSpeed * Time.deltaTime);
    }
}
