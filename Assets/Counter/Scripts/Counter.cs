using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    public Text CounterText;
    public Text highscoreText;
    public int score = 1;
    private static int Count = 0;
    public bool bankrupt = false;
    private int highscore;

    private void Start()
    {
        if (PlayerPrefs.HasKey("highscore"))
        {
            highscore = PlayerPrefs.GetInt("highscore");
            highscoreText.text = "Highscore : " + highscore;
        }
        else
        {
            PlayerPrefs.SetInt("highscore", 0) ;
            //Debug.Log("saved");
        }
        Count = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!bankrupt)
        {
            Count += score;
            CounterText.text = "Score : " + Count;
            Destroy(other.gameObject);
            if (Count > highscore)
            {
                Debug.Log(highscore);
                highscore = Count;
                PlayerPrefs.SetInt("highscore", highscore);
                PlayerPrefs.Save();
                highscoreText.text = "Highscore : " + Count;
            }
        }
        else
        {
            Count = 0;
            CounterText.text = "Score : " + Count;
            Destroy(other.gameObject);
        }
    }
    void update()
    {
        if (Count > highscore)
        {
            highscore = Count;
            PlayerPrefs.SetInt("highscore", highscore);
            PlayerPrefs.Save();
            highscoreText.text = "Highscore : " + Count;
        }
    }
}
