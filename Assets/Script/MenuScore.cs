using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScore : MonoBehaviour
{
    // Start is called before the first frame update
    float score;
    Text showScoreInMenu;
    void Start()
    {
        score = 0;
        //PlayerPrefs.SetFloat("score",score);
        
    }
    private void Update()
    {
        score = PlayerPrefs.GetFloat("score");
        showScoreInMenu = this.GetComponent<Text>();
        showScoreInMenu.text = "Your Score\n" + score;
    }


}
