using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Музыка
    public AudioSource audioS;

    // Объекты меню
    public GameObject start;
    public GameObject game;
    public GameObject scoregame;


    //Начать игру
    public void Startgame() 
    {
        audioS.Play();
        scoregame.SetActive(true);
        game.SetActive(true);
        start.SetActive(false);
    }

    //Вернуться в главное меню
    public void Exitatmenu()
    {
        Time.timeScale = 1f;
        audioS.Play();                
        SceneManager.LoadScene(0);
    }
}
