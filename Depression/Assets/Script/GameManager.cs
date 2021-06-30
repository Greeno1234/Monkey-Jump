﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//using UnityEngine.UIElements;


public class GameManager : MonoBehaviour
{
    public GameObject gameOverCanvas;

    public GameObject Back;
    public GameObject HBack;

    public int TotalScore;
    public int bananas;
    public int earnedBananas;

    public Text bananarama;

    public static int skin;
    public GameObject Skin1;
    public GameObject Skin2;
    public GameObject Skin3;
    public GameObject Skin4;
    public GameObject Skin5;
    public GameObject Skin6;
    public GameObject Skin7;
    public GameObject Skin8;
    public GameObject Skin9;
    public GameObject Skin10;
    public GameObject Skin11;
    public GameObject Skin12;

    public int skinAvailability = 0;


    private void Start()
    {
        TotalScore = PlayerPrefs.GetInt("Total Score");
        bananas = PlayerPrefs.GetInt("Bananas");

        monkeyCheck();
        SoundManagerScript.PlaySound("Start");

        gameOverCanvas.SetActive(false);

        Time.timeScale = 1;

        if (MainMenu.hard == true)
        {
            HBack.SetActive(true);
            Back.SetActive(false);
        }
        else
        {
            Back.SetActive(true);
            HBack.SetActive(false);
        }
    }


    public void GameOver()
    {
        PlayerPrefs.SetInt("Total Score", (TotalScore + Score.score));

        //pauses game
        if (MainMenu.hard == true)
        {
            if (PlayerPrefs.GetInt("HighscoreHard") < Score.score)
            {
                PlayerPrefs.SetInt("HighscoreHard", Score.score);
            }
        }
        else
        { 
            if (PlayerPrefs.GetInt("Highscore") < Score.score)
            {
                PlayerPrefs.SetInt("Highscore", Score.score);
            }
        }
        earnedBananas = Score.score;
        if (MainMenu.hard == true)
        {
            earnedBananas *= 2;
        }

        //if (ad played)
        //{
        //    earnedBananas = earnedBananas * 2;
        //}

        //displays bananas earned and how much the player had before that
        bananarama.text = "Bananas: " + PlayerPrefs.GetInt("Bananas") + " + " + earnedBananas;

        //then adds the earned bananas to the total amount
        bananas = bananas + earnedBananas;
        PlayerPrefs.SetInt("Bananas", bananas);

        SoundManagerScript.PlaySound("UH oh");

        gameOverCanvas.SetActive(true);
  
        Time.timeScale = 0;
    }
    

    public void Replay()
    {
        //restarts game      
        gameOverCanvas.SetActive(false);
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }

    public void Mute()
    {     
        AudioListener.pause = !AudioListener.pause;
    }

    public void monkeyCheck()
    {
        skinHide();
        switch (PlayerPrefs.GetInt("Skin", skin))
        {
            case 0:
                Skin1.SetActive(true);               
                break;
            case 1:
                Skin2.SetActive(true);                
                break;
            case 2:                
                Skin3.SetActive(true);               
                break;
            case 3:              
                Skin4.SetActive(true);            
                break;
            case 4:
                Skin5.SetActive(true);
                break;
            case 5:
                Skin6.SetActive(true);
                break;
            case 6:
                Skin7.SetActive(true);
                break;
            case 7:
                Skin8.SetActive(true);
                break;
            case 8:
                Skin9.SetActive(true);
                break;
            case 9:
                Skin10.SetActive(true);
                break;
            case 10:
                Skin11.SetActive(true);
                break;
            case 11:
                Skin12.SetActive(true);
                break;

            default:
                Skin1.SetActive(true);
                break;
        }
    }
    public void skinHide()
    {
        Skin1.SetActive(false);
        Skin2.SetActive(false);
        Skin3.SetActive(false);
        Skin4.SetActive(false);
        Skin5.SetActive(false);
        Skin6.SetActive(false);
        Skin7.SetActive(false);
        Skin8.SetActive(false);
        Skin9.SetActive(false);
        Skin10.SetActive(false);
        Skin11.SetActive(false);
        Skin12.SetActive(false);
    }
}