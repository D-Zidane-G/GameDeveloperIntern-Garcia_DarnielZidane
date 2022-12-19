using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float TimeLeft;
    public float TimePlayed;
    public GameObject GameOver;

    [Header("Game Over Cue")]
    public AudioClip GameOverClip;

    [Header("References")]
    public PlayerStats PlayerStatsScript;

    bool gameOverClipFlag;

    private void Start()
    {
        gameOverClipFlag = false;
    }

    private void Update()
    {
        TimePlayed = PlayerStatsScript.TimePlayed;

        if (PlayerStatsScript.Alive && TimeLeft > 0)
            TimeLeft -= 1 * Time.deltaTime;
        else
            TimePlayed = 0;

        if(TimeLeft <= 0)
        {
            if (!gameOverClipFlag)
            {
                SoundManager.Instance.PlaySound(GameOverClip);
                gameOverClipFlag = true;
            }
            PlayerStatsScript.Alive = false;
            GameOver.SetActive(true);
        }
        else
            GameOver.SetActive(false);
    }
}
