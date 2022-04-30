using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField] private GameObject exitPanel;
    [SerializeField] private GameObject playAgainPanel;
    [SerializeField] private Text pointsDisplay;
    [SerializeField] private Animator pointsAnimation;
    [SerializeField] private GameObject descriptions;
    [SerializeField] private Button[] moodButtons;

    public Animator PointsAnimation => pointsAnimation;

    public Text PointsDisplay => pointsDisplay;

    public GameObject PlayAgainPanel => playAgainPanel;

    public GameObject ExitPanel => exitPanel;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }

        instance = this;
        
        pointsDisplay.text = "0";
        playAgainPanel.SetActive(false);
        exitPanel.SetActive(false);
        descriptions.SetActive(false);
    }

    public void SetButtonsInteractive(bool value)
    {
        foreach (Button button in moodButtons)
        {
            button.interactable = value;
            button.transform.GetChild(0).GetComponent<Button>().interactable = value;
        }
    }

    public void ChangeDescriptionVisibility()
    {
        descriptions.SetActive(!descriptions.activeSelf);
    }
}
