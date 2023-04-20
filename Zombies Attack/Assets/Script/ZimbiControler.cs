using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ZimbiControler : MonoBehaviour
{


    //Получение объекта игрока и зомби
    public GameObject zombi;
    public GameObject player;

    public GameObject blood;

    //Вектора для расчета угла между объектами
    public Vector2 zombitr;
    public Vector2 playertr;

    //Угл и коректировка направления по Y
    public float C;
    public int pravka;

  

    //Параметры зомби
    public float hp; 
    public int score;
    public int speed;

    //Тригер на соприкосновение с патронами
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "boolet")
        {            
            hp -= 1;
            Destroy(other.gameObject);  
            if (hp <= 0)
            {
                Instantiate(blood, zombi.transform.position, zombi.transform.rotation * Quaternion.Euler(0, 0, 0));
                //Записываем очки
                PlayerPrefs.SetInt("score", score);
                Destroy(this.gameObject);                
            }


        }
    }
    
    void Start()
    {
        //Задаем начальный вектор
        zombitr = Vector2.right;
    }

    
    void Update()
    {        
        Movandrotzombi();
    }

    //Передвижение зимби и вращение
    public void Movandrotzombi()
    {
        zombi.transform.rotation = Quaternion.Euler(0, 0, Rotati() - 90);
        zombi.transform.Translate(new Vector3(0, 1f, 0) * speed * Time.deltaTime);
    }

    //Вычисляем угол между начальным вектором и вектором от зомби до игрока
    public float Rotati()
    {
        //Определение Y чтобы поворот работал в отрицательные значения
        if (zombitr.y > playertr.y)
        {
            pravka = -1;
        }
        else pravka = 1;

        //Вектор от зомби до игрока
        playertr = player.transform.position - zombi.transform.position;

        //вычесление угла
        C = Mathf.Acos(((zombitr.x * playertr.x) + (zombitr.y * playertr.y)) / (Mathf.Sqrt(Mathf.Pow(zombitr.x, 2) + Mathf.Pow(zombitr.y, 2)) * Mathf.Sqrt(Mathf.Pow(playertr.x, 2) + Mathf.Pow(playertr.y, 2)))) * Mathf.Rad2Deg * pravka;
        return C;
    }
}
