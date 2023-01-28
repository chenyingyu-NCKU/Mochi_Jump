
using System.Collections;   
using System.Collections.Generic;
using UnityEngine;

public class Platform_Moving : MonoBehaviour
{
    public GameObject player; // Player object

    [SerializeField] private float jumpForce = 50f; // Player跳的高度
    [SerializeField] private float moveSpeed = 10f; // 地板移動的速度
    [SerializeField] private float destroyDistance = 40f; // 地板消失的距離
    public AudioSource jumpSoundEffect;
    public Animator animator;

    int moveRange = 5; // 地板移動的範圍
    bool rejump = false;


    Vector3 move = new Vector3(); // 地板移動
    Vector3 location = new Vector3(); // 紀錄生成平台的位置

    bool RightSide = false; // 向左走or向右走

    private void Start()
    {
        player = GameObject.FindWithTag("Player"); // 找Tag是Player的物件
        move.x = moveSpeed; // 將移動的速度轉成Vector3的單元
        location = transform.position; // 紀錄物件的位置
        animator = player.GetComponent<Animator>();
    }
    private void OnCollisionEnter2D(Collision2D collision) // 彈跳
    {
        rejump = animator.GetBool("Rejump");
        if (collision.relativeVelocity.y <= 0f)//如果上升通過不會改變速度，下降才會
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
        if (transform.position.y <= player.transform.position.y - destroyDistance) // 如果Player跟物件的距離太遠，就會刪除物件
            Destroy(gameObject);

        if (RightSide) // True的話往右走，False的話往左走
        {
            transform.position += move * Time.deltaTime;
            if (transform.position.x >= location.x + moveRange) // 如果走超過距離，就會改變方向
            {
                RightSide = false;
            }
        }
        else
        {
            transform.position -= move * Time.deltaTime;
            if (transform.position.x <= location.x - moveRange) // 如果走超過距離，就會改變方向
            {
                RightSide = true;
            }
        }
    }

}

