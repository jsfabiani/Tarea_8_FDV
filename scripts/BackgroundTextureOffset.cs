using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundTextureOffset : MonoBehaviour
{
    public float scrollSpeed = 0.05f;
    private Renderer rend;
    private float offset = 0f;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        offset += Time.deltaTime * scrollSpeed;
        rend.material.SetTextureOffset("_MainTex", new Vector2 (offset, 0));
    }
}
