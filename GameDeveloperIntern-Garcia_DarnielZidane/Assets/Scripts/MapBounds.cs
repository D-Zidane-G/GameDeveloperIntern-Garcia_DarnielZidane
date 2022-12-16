using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapBounds : MonoBehaviour
{
    public PlayerStats PlayerStatsScript;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Obstacles"))
        {
            PlayerStatsScript.Points++;
            PlayerStatsScript.SizeProgress();
            Destroy(other.gameObject);
        }
    }
}
