using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public GameObject player;
    public GameObject testing;
    public AudioSource jumpSoundEffect;

    public float jumpForce =50f ;
    public float destroyDistance = 20f;
    public Animator animator;
    bool rejump = false;
    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        animator = player.GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        rejump = animator.GetBool("Rejump");
        if(collision.relativeVelocity.y <= 0f)//如果上升通過不會改變速度，下降才會
        {
            Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                if (rejump)
                    rejump = false;
                else
                    rejump = true;
                Vector2 velocity = rb.velocity;//rb.velocity.y是唯讀，所以必須設定一個變數記憶他
                velocity.y = jumpForce;
                rb.velocity = velocity;

                animator.SetBool("Rejump", rejump);
                jumpSoundEffect.Play();
            }
        }
        
    }
    private void Update()
    {
        if (transform.position.y <= player.transform.position.y - destroyDistance)
            Destroy(gameObject);
    }

}
