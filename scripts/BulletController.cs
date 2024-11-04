using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public Vector3 targetPosition;
    private Vector3 dir;
    private SpriteRenderer spriteRenderer;
    [SerializeField] private float bulletSpeed = 20.0f;
    [SerializeField] private GameObject player;
    [SerializeField] private int timesHit = 3;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("PlayerCharacter");
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        dir = player.transform.position - transform.position;  

        if (dir.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (dir.x > 0)
        {
            spriteRenderer.flipX = false;
        }      

        transform.position += dir.normalized * bulletSpeed * Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlayerCharacter")
        {
            if (timesHit > 1)
            {
                gameObject.SetActive(false);
                timesHit -= 1;
            }
            else
            {
                ObjectPooling.pool.DestroyPooledObject(gameObject);
            }
        }
        else
        {
        gameObject.SetActive(false);
        }
    }
}
