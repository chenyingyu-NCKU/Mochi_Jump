using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_once : MonoBehaviour
{
    public float jumpForce = 10f; // 跳躍的力度
    public GameObject player; // 玩家
    public float destroyDistance = 20f; // 距離多少就摧毀
    private void Start()
    {
        player = GameObject.FindWithTag("Player");  // 找尋玩家的物件
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.y <= 0f) // 相對速度小於等於0:在下面
        {
            Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector2 velocity = rb.velocity;
                velocity.y = jumpForce;
                rb.velocity = velocity;
                Destroy(gameObject); // 碰到一下就消失
            }
        }
    }
    private void Update()
    {
        if (transform.position.y <= player.transform.position.y - destroyDistance)
            Destroy(gameObject); //如果距離小於等於某個距離，就把物件刪除
    }

}
