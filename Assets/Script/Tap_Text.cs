using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Tap_Text : MonoBehaviour
{
    Text tap_text;
    int count;
    int limit=100;
    private void Start()
    {
        tap_text = GetComponent<Text>();
    }
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))//偵測滑鼠點擊/或之後手機按也可以偵測
        {
            Vector2 pos = Input.mousePosition;
            Vector2 wp = Camera.main.ScreenToWorldPoint(pos);
            Collider2D coll = this.GetComponent<Collider2D>();
           
            if (coll.OverlapPoint(wp))
            {
                SceneManager.LoadScene(1);
            }
        }
        count++;
        if (count<limit)
        {
            tap_text.text = "Tap To Play";
        }
        else
        {
            tap_text.text = "";
            if (count == limit*1.5)
                count = 0;
        }
      
        
    }
   

    

}
