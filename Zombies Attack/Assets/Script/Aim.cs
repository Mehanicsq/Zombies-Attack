using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
    //��������� �������
    public GameObject aimm;
   
    void Update()
    {
        if (Input.GetMouseButton(0)) 
        {
            Getpositionmouse();
        }               
    }

    //������� ����������� ��������� ����� ������������ ������
    public void Getpositionmouse() 
    {
        aimm.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
