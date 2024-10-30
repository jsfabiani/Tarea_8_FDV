using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxControllerMoving : MonoBehaviour
{

    public GameObject[] LayersGameObject;
    public float scrollSpeed = 4.0f ;


    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        int i = 0;
        foreach (GameObject layer in LayersGameObject)
        {
            layer.transform.Translate(- scrollSpeed*Time.deltaTime/(1+Mathf.Ceil(i/2)), 0f, 0f);
            float backgroundWidth = layer.GetComponent<Collider2D>().bounds.size.x;

            if (layer.transform.position.x <= - 1 * backgroundWidth)
            {               
            layer.transform.position = new Vector3 (backgroundWidth , layer.transform.position.y, 0f);
            }
            i++;
        } 
    }
}
