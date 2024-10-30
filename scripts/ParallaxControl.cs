using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ParallaxControl : MonoBehaviour
{
    public GameObject[] LayerGameObjects;
    // Start is called before the first frame update
    public Vector2 movement = new Vector2 (1f, 0f);
    public float speedOffset = 1.0f;
    private Material[] LayerMaterials;
    void Start()
    {
        LayerMaterials = new Material[LayerGameObjects.Length];
        int i = 0;
        foreach (GameObject obj in LayerGameObjects)
        {
            LayerMaterials[i] = obj.GetComponent<Renderer>().material;
            i++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        int i = 0;
        foreach (Material m in LayerMaterials)
        {
            m.SetTextureOffset("_MainTex", m.GetTextureOffset("_MainTex") + speedOffset * movement / (i+1.0f)) ;
            i++;
        }         
    }
}