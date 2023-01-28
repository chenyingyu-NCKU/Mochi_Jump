using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_touch_Coin : MonoBehaviour
{
    public GameObject player;

    public float jumpForce = 50f;
    public float destroyDistance = 20f;
    public Animator animator;
    bool rejump = false;
    private void Start()
    {
        player = GameObject.Find("Player");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (rejump)
            rejump = false;
        else
            rejump = true;

        if (collision.relativeVelocity.y <= 0f)//如果上升通過不會改變速度，下降才會
        {
            Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector2 velocity = rb.velocity;//rb.velocity.y是唯讀，所以必須設定一個變數記憶他
                velocity.y = jumpForce;
                rb.velocity = velocity;

                animator.SetBool("Rejump", rejump);
            }
        }
    }
}
