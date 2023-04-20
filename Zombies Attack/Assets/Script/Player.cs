using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // ������
    public AudioSource audioSource;

    //���� ���������
    public GameObject gameover;

    //������ � ��������� ������ �������
    public GameObject boolet;
    public Transform shotpos;

    //��������� ������� ������ � �������
    public GameObject Players;
    public GameObject Pricel;

    //������� ��� ������� ���� ����� ���������
    public Vector2 Playersv3_1;
    public Vector2 Playersv3_2;

    //�������� ���������������� ������
    public float sec = 0;
    public float timeshot;
    public float shotintimeshot;   
        
    //��� � ������������ ����������� �� Y
    public float C;
    public int pravka;


    //������ ��������������� � ����� 
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "zombi")
        {          
            gameover.SetActive(true);
            Time.timeScale = 0f;
            Destroy(this.gameObject);
        }
    }

    
    void Start()
    {
        //������ ��������� ������
        Playersv3_1 = Vector2.right;
    }

    
    void Update()
    {
        //����������� ���������
        Players.transform.rotation = Quaternion.Euler(0, 0, Rotati() - 90);


        

        //�������
        Shot();

    }

    //��������� ���� ����� ��������� �������� � �������� �� ������ �� �������
    public float Rotati() 
    {
        //����������� Y ����� ������� ������� � ������������� ��������
        if (Playersv3_1.y > Playersv3_2.y)
        {
            pravka = -1;
        } else pravka = 1;

        //������ �� ������ �� �������
        Playersv3_2 = Pricel.transform.position - Players.transform.position;

        //���������� ����
        C = Mathf.Acos(((Playersv3_1.x * Playersv3_2.x) + (Playersv3_1.y * Playersv3_2.y)) / (Mathf.Sqrt(Mathf.Pow(Playersv3_1.x, 2) + Mathf.Pow(Playersv3_1.y, 2)) * Mathf.Sqrt(Mathf.Pow(Playersv3_2.x, 2) + Mathf.Pow(Playersv3_2.y, 2)))) * Mathf.Rad2Deg * pravka;
        return C;
    }

    //������� ������ ������� � �������� 
    public void Shot() 
    {
        sec += Time.deltaTime;
        if (sec > timeshot / shotintimeshot)
        {            
            audioSource.Play();
            Instantiate(boolet, shotpos.position, shotpos.rotation * Quaternion.Euler(0, 0, 0));
            sec = 0;
        }        
    }
}
