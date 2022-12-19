using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public bool Alive;
    [HideInInspector] public int Points;
    [HideInInspector] public float TimePlayed;
    public int MovementSpeed;

    PlayerEssentials PlayerEssentialsScript;

    private void Start()
    {
        PlayerEssentialsScript = this.gameObject.GetComponent<PlayerEssentials>();
    }

    private void Update()
    {
        if (Alive)
            TimePlayed += 1 * Time.deltaTime;
        else
            TimePlayed = 0;
    }

    public void SizeProgress()
    {
        if(Points % 20 == 0)
        {
            StartCoroutine(PlayerEssentialsScript.IncreaseSize());
            if (MovementSpeed > 1)
                MovementSpeed--;
        }
    }
}
