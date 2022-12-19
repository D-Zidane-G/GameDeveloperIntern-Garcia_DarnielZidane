using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapBounds : MonoBehaviour
{
    public PlayerStats PlayerStatsScript;

    [Header("Score SFX")]
    public AudioClip PlayerScores;

    private void OnTriggerEnter(Collider other)
    {
        //Increase points, size up if necessary, and destroy obstacles
        if(other.gameObject.layer == LayerMask.NameToLayer("Obstacles"))
        {
            SoundManager.Instance.PlaySound(PlayerScores);
            PlayerStatsScript.Points++;
            PlayerStatsScript.SizeProgress();
            Destroy(other.gameObject);
        }
    }
}
