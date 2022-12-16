using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHoleTrigger : MonoBehaviour
{
    public Collider GroundCollider;
    PlayerEssentials PlayerEssentialsScript;

    private void Start()
    {
        PlayerEssentialsScript = this.gameObject.GetComponent<PlayerEssentials>();

        //Optimization (turn off all collisions)
        GameObject[] SceneGameObjects = FindObjectsOfType(typeof(GameObject)) as GameObject[];

        foreach (GameObject gameObject in SceneGameObjects) 
        {
            if (gameObject.layer == LayerMask.NameToLayer("Obstacles"))
                Physics.IgnoreCollision(gameObject.GetComponent<Collider>(), PlayerEssentialsScript.GeneratedMeshCollider, true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Other is obstacles.
        Physics.IgnoreCollision(other, GroundCollider, true);
        Physics.IgnoreCollision(other, PlayerEssentialsScript.GeneratedMeshCollider, false);
    }

    private void OnTriggerExit(Collider other)
    {
        Physics.IgnoreCollision(other, GroundCollider, false);
        Physics.IgnoreCollision(other, PlayerEssentialsScript.GeneratedMeshCollider, true);
    }
}
