using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touch_Apple : MonoBehaviour
{
    public float jumpForce = 100f;
    public GameObject player;
    public Animator animator;
    bool rejump;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //rejump = animator.GetBool("Rejump");

        Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            if (rejump)
                rejump = false;
            else
                rejump = true;

            Vector2 velocity = rb.velocity;
            velocity.y = jumpForce;
            rb.velocity = velocity;
            //Destroy(gameObject);
            //animator.SetBool("Rejump", rejump);
        }
    }
    private void Update()
    {
        if (player.transform.position.y - 30 > transform.position.y)
            Destroy(gameObject);
    }
}

