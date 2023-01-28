using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stop_Button : MonoBehaviour
{
    Button stop;
    bool click=false;
    // Start is called before the first frame update
    void Start()
    {
        stop = this.GetComponent<Button>();
        stop.onClick.AddListener(delegate
        {
            Click();
        });
    }

    // Update is called once per frame
    void Click()
    {
        if (!click)
        {
            click = true;
            Time.timeScale = 0;
        }
        else
        {
            click = false;
            Time.timeScale = 1;
        }
            
    }
}
