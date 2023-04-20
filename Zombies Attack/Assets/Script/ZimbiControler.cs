using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ZimbiControler : MonoBehaviour
{


    //��������� ������� ������ � �����
    public GameObject zombi;
    public GameObject player;

    public GameObject blood;

    //������� ��� ������� ���� ����� ���������
    public Vector2 zombitr;
    public Vector2 playertr;

    //��� � ������������ ����������� �� Y
    public float C;
    public int pravka;

  

    //��������� �����
    public float hp; 
    public int score;
    public int speed;

    //������ �� ��������������� � ���������
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "boolet")
        {            
            hp -= 1;
            Destroy(other.gameObject);  
            if (hp <= 0)
            {
                Instantiate(blood, zombi.transform.position, zombi.transform.rotation * Quaternion.Euler(0, 0, 0));
                //���������� ����
                PlayerPrefs.SetInt("score", score);
                Destroy(this.gameObject);                
            }


        }
    }
    
    void Start()
    {
        //������ ��������� ������
        zombitr = Vector2.right;
    }

    
    void Update()
    {        
        Movandrotzombi();
    }

    //������������ ����� � ��������
    public void Movandrotzombi()
    {
        zombi.transform.rotation = Quaternion.Euler(0, 0, Rotati() - 90);
        zombi.transform.Translate(new Vector3(0, 1f, 0) * speed * Time.deltaTime);
    }

    //��������� ���� ����� ��������� �������� � �������� �� ����� �� ������
    public float Rotati()
    {
        //����������� Y ����� ������� ������� � ������������� ��������
        if (zombitr.y > playertr.y)
        {
            pravka = -1;
        }
        else pravka = 1;

        //������ �� ����� �� ������
        playertr = player.transform.position - zombi.transform.position;

        //���������� ����
        C = Mathf.Acos(((zombitr.x * playertr.x) + (zombitr.y * playertr.y)) / (Mathf.Sqrt(Mathf.Pow(zombitr.x, 2) + Mathf.Pow(zombitr.y, 2)) * Mathf.Sqrt(Mathf.Pow(playertr.x, 2) + Mathf.Pow(playertr.y, 2)))) * Mathf.Rad2Deg * pravka;
        return C;
    }
}
