using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    //Поулучения массива положения точек спавна
    public Transform []Spawners;

    //Поулучения массива врагов
    public GameObject []zombii;

    //Переменная вероятности
    public float chansspawn;

    //Индекс спавнера
    public int indexspawn;

    //Индекс зомби
    public int indexzomb;

    
    //Контроль времени увелечения сложности
    public float timeHard;

    //Время через которое сложность увеличится
    public float timehardspeed;

    //Контроль времени спавна
    public float timespawn;

    //Скорость спавна
    public float speedspawn;

    //Минимум времени спавна
    public float minspeedspawn;

    //Время уменьшения спавна
    public float speedhardspawn;
   

    // Update is called once per frame
    void Update()
    {
        Hardup();        
        Spawnzombi();
    }

    //Увеличение сложности игры
    public void Hardup() 
    {
        timeHard += Time.deltaTime;
        if (speedspawn > minspeedspawn)
        {
            if (timeHard > timehardspeed)
            {
                speedspawn -= speedhardspawn;
                timeHard = 0;
            }
        }
    }

    //Время для спавна зомби, определения его позиции и тира
    public void Spawnzombi()
    {        
        timespawn += Time.deltaTime;
        if (timespawn > speedspawn)
        {
            Chans();
            indexspawn = (int)Random.Range(0f, Spawners.Length);
            Instantiate(zombii[indexzomb], Spawners[indexspawn].position, Spawners[indexspawn].rotation * Quaternion.Euler(0, 0, 0));
            timespawn = 0;
        }
    }

    //Функция вероятности
    public void Chans() 
    {
        chansspawn = Random.Range(0f, 100f);
        if (chansspawn <= 60)
        {
            indexzomb = 0;
        }
        if (chansspawn <= 30)
        {
            indexzomb = 1;
        }
        if (chansspawn <= 10)
        {
            indexzomb = 2;
        }
    }

}
