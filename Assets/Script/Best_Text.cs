using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Best_Text : MonoBehaviour
{
    Text bestScore;
    static public float bestscore=0 ;
    static public float newBest;
    private void Start()
    {
        bestScore = GetComponent<Text>();
        bestScore.text = "Best\n" + bestscore;
    }
    void Update()
    {
        PlayerPrefs.SetFloat("bestscore",bestscore);
        newBest = PlayerPrefs.GetFloat("newBestscore");
        bestScore.text = "Best\n" + newBest;
        bestscore = newBest;
    }
}
