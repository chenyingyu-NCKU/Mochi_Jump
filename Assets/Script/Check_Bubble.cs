using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Check_Bubble : MonoBehaviour
{
    Toggle toggle;
    public static bool check;

    private void Start()
    {
        check = false;
        toggle = this.GetComponent<Toggle>();
        toggle.isOn = false;
        toggle.onValueChanged.AddListener(delegate
        {
            toggleValueChange(toggle);
        });

    }

    void toggleValueChange(Toggle teggle)
    {
        if (!check && TotalMoney.totalMoney >= 100)
        {
            toggle.enabled = true;
            check = true;
            Debug.Log(check);
        }
        else if(check)
        {
            toggle.enabled = false;
            check = false;
        }
    }
    



}
