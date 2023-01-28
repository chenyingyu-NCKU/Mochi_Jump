using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    float movementSpeed = 100f;
    public float movement = 0f;
    Rigidbody2D rb;
    float startPosition;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movement = Input.acceleration.x * movementSpeed;
        if (transform.position.x <= -13.5)
        {
            float nowPosition = transform.position.y;
            Vector2 rightSide = new Vector2(16f, nowPosition);
            transform.position = rightSide;
        }
        else if (transform.position.x >= 18.5)
        {
            float nowPosition = transform.position.y;
            Vector2 leftSide = new Vector2(-11f, nowPosition);
            transform.position = leftSide;
        }

    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(movement, 0f);
    }

}
