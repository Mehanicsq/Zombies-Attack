using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boolet : MonoBehaviour
{
    //��������� �������
    public GameObject boolet;

    //��������� ������� ����� ����
    public float times;
    public float timelifeboolet;

    public float speedboolet;


    void Update()
    {        
        Timelife();
        Moveboolet();
    }

    //������� ������� ����� ����
    public void Timelife()
    {
        times += Time.deltaTime;
        if (times > timelifeboolet)
        {
            Destroy(this.gameObject);
        }
    }

    //������� �������� ����
    public void Moveboolet() 
    {
        boolet.transform.Translate(new Vector3(0, 1f, 0) * speedboolet * Time.deltaTime);
    } 
}
