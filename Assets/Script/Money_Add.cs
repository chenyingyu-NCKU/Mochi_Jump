using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money_Add : MonoBehaviour
{
    public Text PointText;
    public static float localMoney = 0;

    // Start is called before the first frame update
    void Start()
    {
        localMoney = 0;
        PointText.text = localMoney.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        PointText.text = localMoney.ToString();
    }

}
