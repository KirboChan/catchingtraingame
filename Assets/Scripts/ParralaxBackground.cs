using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParralaxBackground : MonoBehaviour
{
    Material mat;
    float distance;

    [Range(0f, 0.5f)]
    public float speed;

    private void Start()
    {
        mat = GetComponent<Material>();
    }

    private void Update()
    {
        distance += Time.deltaTime * speed;
        mat.SetTextureOffset("MainTex", Vector2.right * distance);
    }
}
