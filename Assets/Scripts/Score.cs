using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public static int score;
    public Text scoretext;
    public GameObject CreditScreen;
    public GameObject DeathScreen;

    void Start()
    {
        score = 0;
    }

    
    void Update()
    {
        scoretext.text = score.ToString();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadCredit()
    {
        CreditScreen.SetActive(true);
        DeathScreen.SetActive(false);
        
    }
}
