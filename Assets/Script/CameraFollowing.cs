using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowing : MonoBehaviour
{
    public Transform player;
    public Transform platform;

    // Update is called once per frame
    void LateUpdate()
    {
        if (player.position.y - platform.position.y > 10)
        {
            if (transform.position.y != player.position.y)
            {
                Vector3 newPos = new Vector3(transform.position.x, player.position.y, transform.position.z);
                transform.position = newPos;
            }
        }
        
        
    }

}
