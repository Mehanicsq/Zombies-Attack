using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boolet : MonoBehaviour
{
    //Получение патрона
    public GameObject boolet;

    //Параметры времени жизни пули
    public float times;
    public float timelifeboolet;

    public float speedboolet;


    void Update()
    {        
        Timelife();
        Moveboolet();
    }

    //Функция времени жизни пули
    public void Timelife()
    {
        times += Time.deltaTime;
        if (times > timelifeboolet)
        {
            Destroy(this.gameObject);
        }
    }

    //Функция движения пули
    public void Moveboolet() 
    {
        boolet.transform.Translate(new Vector3(0, 1f, 0) * speedboolet * Time.deltaTime);
    } 
}
