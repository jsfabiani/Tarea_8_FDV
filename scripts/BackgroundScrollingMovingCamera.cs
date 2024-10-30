using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScrollingMovingCamera : MonoBehaviour
{
    public GameObject _camera;
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
        if (transform.position.x + backgroundWidth < _camera.transform.position.x) {

            transform.position += 2 * backgroundWidth * Vector3.right;
        }
    }
}
