using UnityEngine;

public class Enemy : MonoBehaviour
{
    GameObject player;

    float left_position;
    float right_position;
    public float range = 15f;
    public float speed = 10f;

    Vector3 direction = new Vector3(1, 0);
    Vector3 scale;

    bool moveright = true;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        left_position = transform.localPosition.x;
        right_position = left_position + range;
        scale = transform.localScale;
        // 角色一開始的面向
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 characterScale = transform.localScale;

        if (player.transform.position.y - 30 > transform.position.y)
            Destroy(gameObject);

        if (transform.localPosition.x <= left_position)
        {
            moveright = true;
        }
        if (transform.localPosition.x >= right_position)
        {
            moveright = false;
        }


        if (moveright)
        {
            transform.localPosition += speed * Time.deltaTime * direction;
            characterScale.x = -scale.x; // flip the character
        }
        else
        {
            transform.localPosition -= speed * Time.deltaTime * direction;
            characterScale.x = scale.x;
        }
        transform.localScale = characterScale;
    }
}
