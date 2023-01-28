
using System.Collections;   
using System.Collections.Generic;
using UnityEngine;

public class Platform_Moving : MonoBehaviour
{
    public GameObject player; // Player object

    [SerializeField] private float jumpForce = 50f; // Player��������
    [SerializeField] private float moveSpeed = 10f; // �a�O���ʪ��t��
    [SerializeField] private float destroyDistance = 40f; // �a�O�������Z��
    public AudioSource jumpSoundEffect;
    public Animator animator;

    int moveRange = 5; // �a�O���ʪ��d��
    bool rejump = false;


    Vector3 move = new Vector3(); // �a�O����
    Vector3 location = new Vector3(); // �����ͦ����x����m

    bool RightSide = false; // �V����or�V�k��

    private void Start()
    {
        player = GameObject.FindWithTag("Player"); // ��Tag�OPlayer������
        move.x = moveSpeed; // �N���ʪ��t���নVector3���椸
        location = transform.position; // �������󪺦�m
        animator = player.GetComponent<Animator>();
    }
    private void OnCollisionEnter2D(Collision2D collision) // �u��
    {
        rejump = animator.GetBool("Rejump");
        if (collision.relativeVelocity.y <= 0f)//�p�G�W�ɳq�L���|���ܳt�סA�U���~�|
        {
            Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                if (rejump)
                    rejump = false;
                else
                    rejump = true;
                Vector2 velocity = rb.velocity;//rb.velocity.y�O��Ū�A�ҥH�����]�w�@���ܼưO�ХL
                velocity.y = jumpForce;
                rb.velocity = velocity;

                animator.SetBool("Rejump", rejump);
                jumpSoundEffect.Play();
            }
        }
    }

    private void Update()
    {
        if (transform.position.y <= player.transform.position.y - destroyDistance) // �p�GPlayer�򪫥󪺶Z���ӻ��A�N�|�R������
            Destroy(gameObject);

        if (RightSide) // True���ܩ��k���AFalse���ܩ�����
        {
            transform.position += move * Time.deltaTime;
            if (transform.position.x >= location.x + moveRange) // �p�G���W�L�Z���A�N�|���ܤ�V
            {
                RightSide = false;
            }
        }
        else
        {
            transform.position -= move * Time.deltaTime;
            if (transform.position.x <= location.x - moveRange) // �p�G���W�L�Z���A�N�|���ܤ�V
            {
                RightSide = true;
            }
        }
    }

}

