using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }

        instance = this;
    }

    private int score;

    private void Update()
    {
        TurnOnExitPanel();
    }

    private void TurnOnExitPanel()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !UIManager.instance.PlayAgainPanel.activeSelf)
        {
            UIManager.instance.ExitPanel.SetActive(true);
            UIManager.instance.SetButtonsInteractive(false);
        }
    }

    public void ResetScore()
    {
        score = 0;
        UIManager.instance.PointsDisplay.text = score.ToString();
    }

    public void AddScore()
    {
        score ++;
        UIManager.instance.PointsDisplay.text = score.ToString();
        UIManager.instance.PointsAnimation.SetBool("addPoint",true);
        AudioManager.instance.Play("gainPoint");
    }

    public void TurnOnPlayAgainPanel()
    {
        UIManager.instance.PlayAgainPanel.SetActive(true);
        UIManager.instance.SetButtonsInteractive(false);
    }

    public void CloseApplication()
    {
        Application.Quit();
    }
}
