using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Музыка
    public AudioSource audioSource;

    //Окно пройгрыша
    public GameObject gameover;

    //Спрайт и положение спавна патрона
    public GameObject boolet;
    public Transform shotpos;

    //Получение объекта игрока и прицела
    public GameObject Players;
    public GameObject Pricel;

    //Вектора для расчета угла между объектами
    public Vector2 Playersv3_1;
    public Vector2 Playersv3_2;

    //Контроль скорострельности игрока
    public float sec = 0;
    public float timeshot;
    public float shotintimeshot;   
        
    //Угл и коректировка направления по Y
    public float C;
    public int pravka;


    //тригер сопрекосновения с зомби 
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
        //Задаем начальный вектор
        Playersv3_1 = Vector2.right;
    }

    
    void Update()
    {
        //Направление персонажа
        Players.transform.rotation = Quaternion.Euler(0, 0, Rotati() - 90);


        

        //Выстрел
        Shot();

    }

    //Вычисляем угол между начальным вектором и вектором от игрока до прицела
    public float Rotati() 
    {
        //Определение Y чтобы поворот работал в отрицательные значения
        if (Playersv3_1.y > Playersv3_2.y)
        {
            pravka = -1;
        } else pravka = 1;

        //вектор от игрока до прицела
        Playersv3_2 = Pricel.transform.position - Players.transform.position;

        //вычесление угла
        C = Mathf.Acos(((Playersv3_1.x * Playersv3_2.x) + (Playersv3_1.y * Playersv3_2.y)) / (Mathf.Sqrt(Mathf.Pow(Playersv3_1.x, 2) + Mathf.Pow(Playersv3_1.y, 2)) * Mathf.Sqrt(Mathf.Pow(Playersv3_2.x, 2) + Mathf.Pow(Playersv3_2.y, 2)))) * Mathf.Rad2Deg * pravka;
        return C;
    }

    //Функция спавна патрона и скорости 
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
