using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameLogic : MonoBehaviour
{
    

    //Очки в игре
    public TextMeshProUGUI scoreatgame;

    //Рекорд
    public TextMeshProUGUI scorerecord;

    //Очки за игру
    public TextMeshProUGUI scoreatgameGO;

    //Переменная очков
    public int scoretxt = 0;

    void Update()
    {
        
        Setscoreinform();
        Maxscore();
    }

    //Определяем максимум очков
    public void Maxscore() 
    {
        PlayerPrefs.SetInt("score", 0);
        PlayerPrefs.SetInt("scorAtGame", scoretxt);
        if (PlayerPrefs.GetInt("scorAtGame") > PlayerPrefs.GetInt("maxscor"))
        {
            PlayerPrefs.SetInt("maxscor", scoretxt);
        }
    }

    //Запись очков в формы
    public void Setscoreinform() 
    {
        scoretxt += PlayerPrefs.GetInt("score");
        scoreatgame.text = scoretxt.ToString();
        scoreatgameGO.text = PlayerPrefs.GetInt("scorAtGame").ToString();
        scorerecord.text = PlayerPrefs.GetInt("maxscor").ToString();
    }



}
