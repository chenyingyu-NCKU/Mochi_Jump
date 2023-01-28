using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerControler : MonoBehaviour
{
    public Rigidbody2D rigid2D;
    Vector3 honmove = new Vector3(0.5f, 0, 0);
    private void OnCollisionEnter2D(Collision2D collision)
    {
        rigid2D.AddForce(new Vector2(0, 1800));
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rigid2D.AddForce(new Vector2(-15,0), ForceMode2D.Force);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rigid2D.AddForce(new Vector2(15,0), ForceMode2D.Force);
        }
        
    }
}
