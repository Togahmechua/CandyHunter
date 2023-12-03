using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Jobs;

public class BackGround : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    public float aniamtionSpeed = 1f; 

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
       
        meshRenderer.material.mainTextureOffset += new Vector2(aniamtionSpeed * Time.deltaTime, 0);
    }
}
