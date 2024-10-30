using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BacgroundScrollingFixedCamera : MonoBehaviour
{
    public float scrollSpeed = 4.0f ;
    private Collider2D backgroundCollider;
    private float backgroundWidth;

    // Start is called before the first frame update
    void Start()
    {
        backgroundCollider = this.GetComponent<Collider2D>();
        backgroundWidth = backgroundCollider.bounds.size.x;
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(- scrollSpeed*Time.deltaTime, 0, 0);

        if (transform.position.x <= - 1 * backgroundWidth)
        {
            
            transform.position = new Vector3 (backgroundWidth , transform.position.y, transform.position.z);
            
        }
    

    }
}
