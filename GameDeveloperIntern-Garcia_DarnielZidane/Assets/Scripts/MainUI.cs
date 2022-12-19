using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainUI : MonoBehaviour
{
    [Header("Menu UI")]
    public GameObject Menu_UI;
    public bool MenuPlayChecker;

    [Header("In Game UI")]
    public GameObject InGame_UI;
    public bool InGamePlayChecker;
    public TextMeshProUGUI Points;
    public TextMeshProUGUI PointsShadow;
    public TextMeshProUGUI TimeLeftText;
    public TextMeshProUGUI TimeLeftTextShadow;

    [Header("References")]
    public PlayerStats PlayerStatsScript;
    public Timer TimerScript;

    [Header("Player Sounds")]
    public AudioClip PlayerSpawn;

    CanvasGroup mainMenuCanvasGroup;
    CanvasGroup inGameCanvasGroup;

    private void Start()
    {
        mainMenuCanvasGroup = Menu_UI.gameObject.GetComponent<CanvasGroup>();
        MenuPlayChecker = false;

        inGameCanvasGroup = InGame_UI.gameObject.GetComponent<CanvasGroup>();
        InGamePlayChecker = false;
    }

    private void Update()
    {
        DisplayPlayerUI();
        UITransition();
    }

    public void MainMenu_PlayButton()
    {
        MenuPlayChecker = true;
        InGamePlayChecker = true;
        PlayerStatsScript.Alive = true;
        SoundManager.Instance.PlaySound(PlayerSpawn);
        SoundManager.Instance.StartCoroutine("StartIGMusicTransition");
    }

    public void MainMenu_ReturnMenu()
    {
        SceneManager.LoadScene(0);
        SoundManager.Instance.StartCoroutine("StartMenuMusicTransition");
    }

    public void MainMenu_QuitButton()
    {
        Application.Quit();
    }

    public void DisplayPlayerUI()
    {
        int timeLeft = (int)TimerScript.TimeLeft;

        Points.text = "Score: " + PlayerStatsScript.Points.ToString();
        TimeLeftText.text = timeLeft.ToString();

        PointsShadow.text = "Score: " + PlayerStatsScript.Points.ToString();
        TimeLeftTextShadow.text = timeLeft.ToString();

        if (timeLeft <= 10)
            TimeLeftText.color = Color.red;
    }

    public void UITransition()
    {
        //Main Menu
        if (!MenuPlayChecker && mainMenuCanvasGroup.alpha < 1)
            mainMenuCanvasGroup.alpha += Time.deltaTime;

        if (MenuPlayChecker && mainMenuCanvasGroup.alpha > 0)
            mainMenuCanvasGroup.alpha -= Time.deltaTime;

        //In Game
        if (!InGamePlayChecker && inGameCanvasGroup.alpha > 0)
            inGameCanvasGroup.alpha -= Time.deltaTime;

        if (InGamePlayChecker && inGameCanvasGroup.alpha < 1)
            inGameCanvasGroup.alpha += Time.deltaTime;
    }
}
