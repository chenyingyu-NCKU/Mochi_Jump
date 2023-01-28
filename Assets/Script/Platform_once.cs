using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_once : MonoBehaviour
{
    public float jumpForce = 10f; // ���D���O��
    public GameObject player; // ���a
    public float destroyDistance = 20f; // �Z���h�ִN�R��
    private void Start()
    {
        player = GameObject.FindWithTag("Player");  // ��M���a������
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.y <= 0f) // �۹�t�פp�󵥩�0:�b�U��
        {
            Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector2 velocity = rb.velocity;
                velocity.y = jumpForce;
                rb.velocity = velocity;
                Destroy(gameObject); // �I��@�U�N����
            }
        }
    }
    private void Update()
    {
        if (transform.position.y <= player.transform.position.y - destroyDistance)
            Destroy(gameObject); //�p�G�Z���p�󵥩�Y�ӶZ���A�N�⪫��R��
    }

}
