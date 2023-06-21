using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteScroller : MonoBehaviour
{

    [SerializeField] Vector2 moveSpeed;

    Vector2 offset;
    Material material;

    void Awake()
    {
        material = GetComponent<SpriteRenderer>().material;
    }

    private void Update()
    {
        //making offset frame rate independent
        offset = moveSpeed * Time.deltaTime;
        //to apply this to the material
        material.mainTextureOffset += offset;

    }
}
