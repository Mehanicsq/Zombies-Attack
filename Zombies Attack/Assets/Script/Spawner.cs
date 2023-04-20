using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    //���������� ������� ��������� ����� ������
    public Transform []Spawners;

    //���������� ������� ������
    public GameObject []zombii;

    //���������� �����������
    public float chansspawn;

    //������ ��������
    public int indexspawn;

    //������ �����
    public int indexzomb;

    
    //�������� ������� ���������� ���������
    public float timeHard;

    //����� ����� ������� ��������� ����������
    public float timehardspeed;

    //�������� ������� ������
    public float timespawn;

    //�������� ������
    public float speedspawn;

    //������� ������� ������
    public float minspeedspawn;

    //����� ���������� ������
    public float speedhardspawn;
   

    // Update is called once per frame
    void Update()
    {
        Hardup();        
        Spawnzombi();
    }

    //���������� ��������� ����
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

    //����� ��� ������ �����, ����������� ��� ������� � ����
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

    //������� �����������
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
