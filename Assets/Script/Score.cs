using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
    public Text score;
    public GameObject player;
    float height = 0f;
    float maxScore;

    void Start()
    {
        score = GetComponent<Text>();
        score.text = "0";
        PlayerPrefs.SetFloat("score", float.Parse(score.text));
        height = player.transform.position.y;
    }
    
    void Update()
    {
        maxScore= PlayerPrefs.GetFloat("bestscore");
        if (float.Parse(score.text) < (player.transform.position.y - height) * 25)
        {
            score.text = ((int)((player.transform.position.y - height) * 25)).ToString();
            PlayerPrefs.SetFloat("score", float.Parse(score.text));
        }
            
        if (float.Parse(score.text) > maxScore)
        {
            maxScore = float.Parse(score.text);
            PlayerPrefs.SetFloat("newBestscore", maxScore);
        }
            
    }
}
