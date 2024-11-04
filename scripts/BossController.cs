using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossController : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    Animator animator;
    Rigidbody2D rb2D;
    [SerializeField] private GameObject player;
    private Vector3 directionToPlayer;
    private GameObject missile;
    

    // Start is called before the first frame update
    void Start()
    {
        // Initializing Components
        rb2D = this.GetComponent<Rigidbody2D>();
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        animator = this.GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("PlayerCharacter");


        rb2D.freezeRotation = true;
        spriteRenderer.flipX = true;

        InvokeRepeating("Fire", 1.0f, 0.2f);

    }

    // Update is called once per frame
    void Update()
    {
        directionToPlayer = player.transform.position - this.transform.position;

        //Animation
        if (directionToPlayer.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (directionToPlayer.x > 0)
        {
            spriteRenderer.flipX = false;
        }
        
    }


    /*IEnumerator StartFiring()
    {       
        animator.SetBool("isFiring", true);
        for (int i = 0; i < 6; i++)
        {
            missile = ObjectPooling.pool.GetPooledObject();
            missile.transform.position = new Vector3 (transform.position.x, transform.position.y + 0.5f, transform.position.z);
            missile.SetActive(true);
            yield return new WaitForSeconds(0.1f);
        }
        animator.SetBool("isFiring", false);
    }*/


    void Fire()
    {
        missile = ObjectPooling.pool.GetPooledObject();
        if (missile != null)
        {
            animator.SetBool("isFiring", true);
            missile.transform.position = new Vector3 (transform.position.x, transform.position.y + 0.5f, transform.position.z);
            missile.SetActive(true);
        }
        else
        {
            animator.SetBool("isFiring", false);
        }
    }
}
