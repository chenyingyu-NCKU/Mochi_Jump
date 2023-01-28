using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TotalMoney : MonoBehaviour
{
    Text money;
    // Start is called before the first frame update
    public static float totalMoney;
    void Start()
    {
        money = this.GetComponent<Text>();
        totalMoney += Money_Add.localMoney;
        Debug.Log(Money_Add.localMoney);
        Debug.Log(totalMoney);
        money.text = totalMoney.ToString();
    }
    
    
}
