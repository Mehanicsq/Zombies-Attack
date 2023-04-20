using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameLogic : MonoBehaviour
{
    

    //���� � ����
    public TextMeshProUGUI scoreatgame;

    //������
    public TextMeshProUGUI scorerecord;

    //���� �� ����
    public TextMeshProUGUI scoreatgameGO;

    //���������� �����
    public int scoretxt = 0;

    void Update()
    {
        
        Setscoreinform();
        Maxscore();
    }

    //���������� �������� �����
    public void Maxscore() 
    {
        PlayerPrefs.SetInt("score", 0);
        PlayerPrefs.SetInt("scorAtGame", scoretxt);
        if (PlayerPrefs.GetInt("scorAtGame") > PlayerPrefs.GetInt("maxscor"))
        {
            PlayerPrefs.SetInt("maxscor", scoretxt);
        }
    }

    //������ ����� � �����
    public void Setscoreinform() 
    {
        scoretxt += PlayerPrefs.GetInt("score");
        scoreatgame.text = scoretxt.ToString();
        scoreatgameGO.text = PlayerPrefs.GetInt("scorAtGame").ToString();
        scorerecord.text = PlayerPrefs.GetInt("maxscor").ToString();
    }



}
