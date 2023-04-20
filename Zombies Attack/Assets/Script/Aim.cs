using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
    //Поулчение прицела
    public GameObject aimm;
   
    void Update()
    {
        if (Input.GetMouseButton(0)) 
        {
            Getpositionmouse();
        }               
    }

    //Функция определения положения мышки относительно экрана
    public void Getpositionmouse() 
    {
        aimm.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
