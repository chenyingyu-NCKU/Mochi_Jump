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

        if (collision.relativeVelocity.y <= 0f)//�p�G�W�ɳq�L���|���ܳt�סA�U���~�|
        {
            Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector2 velocity = rb.velocity;//rb.velocity.y�O��Ū�A�ҥH�����]�w�@���ܼưO�ХL
                velocity.y = jumpForce;
                rb.velocity = velocity;

                animator.SetBool("Rejump", rejump);
            }
        }
    }
}
