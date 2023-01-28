using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Change_Icon : MonoBehaviour
{
    public GameObject start;
    public GameObject grade;
    static int count = 0;
    void Start()
    {
        if(count == 0)
            grade.SetActive(false);
        if (count != 0)
        {
            grade.SetActive(true);
            //Destroy(start);
        }
    }
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            count++;
        }
            
    }


}
