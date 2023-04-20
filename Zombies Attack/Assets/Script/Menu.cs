using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // ������
    public AudioSource audioS;

    // ������� ����
    public GameObject start;
    public GameObject game;
    public GameObject scoregame;


    //������ ����
    public void Startgame() 
    {
        audioS.Play();
        scoregame.SetActive(true);
        game.SetActive(true);
        start.SetActive(false);
    }

    //��������� � ������� ����
    public void Exitatmenu()
    {
        Time.timeScale = 1f;
        audioS.Play();                
        SceneManager.LoadScene(0);
    }
}
