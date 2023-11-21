using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundScroll : MonoBehaviour
{
    [SerializeField] private float speedBackground;
    public Renderer rendererBackground;
    void Update()
    {
        rendererBackground.material.mainTextureOffset+=new Vector2(-speedBackground*Time.deltaTime,0f);
    }
}
