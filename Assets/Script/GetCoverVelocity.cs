using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class GetCoverVelocity : MonoBehaviour
{
    public float startPositionX;
    public Rigidbody2D rb = new Rigidbody2D();
    void Start()
    {
        rb = transform.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        startPositionX = rb.position.x;
        PlayerPrefs.SetFloat("startPosition",startPositionX);
    }
}
