using UnityEngine;

public class WarningSign : MonoBehaviour
{

    public Transform enemy;
    public Transform warning;
    [SerializeField] float distance = 15f;

    bool enemy_in;
    RaycastHit2D ray_up;
    RaycastHit2D ray_down;

    void Start()
    {
        enemy_in = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 down = this.transform.position;
        Vector3 up = new Vector3(down.x, down.y + distance, down.z);

        ray_up = Physics2D.Raycast(up, Vector2.right, 50);
        ray_down = Physics2D.Raycast(down, Vector2.right, 50);

        Debug.DrawRay(up, Vector2.right * 50, Color.red);
        Debug.DrawRay(down, Vector2.right * 50, Color.blue);

        if (ray_up.collider != null && ray_up.collider.tag == "Enemy")
        {
            Debug.DrawRay(up, Vector2.right * 50, Color.white);
            enemy_in = true;
        }
        if (ray_down.collider != null && ray_down.collider.tag == "Enemy")
        {
            Debug.DrawRay(down, Vector2.right * 50, Color.white);
            enemy_in = false;
        }


        Vector3 pos_now = warning.localPosition;

        // Debug.Log(enemy_in);
        if (enemy_in)
        {
            //Debug.Log(enemy.position);
            Vector3 pos = new Vector3(enemy.position.x, warning.position.y, warning.position.z);
            warning.position = pos;
        }
        else
        {
            Vector3 standBy = new Vector3(-30, warning.position.y, warning.position.z);
            warning.position = standBy;
        }
    }

}
