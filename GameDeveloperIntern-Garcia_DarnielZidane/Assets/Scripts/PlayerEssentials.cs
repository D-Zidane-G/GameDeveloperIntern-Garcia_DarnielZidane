using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEssentials : MonoBehaviour
{
    public PolygonCollider2D Hole2DCollider;
    public PolygonCollider2D Ground2DCollider;
    public MeshCollider GeneratedMeshCollider;
    public float PlayerInitialScale = 0.5f;
    PlayerStats PlayerStatsScript;
    Mesh generatedMesh;

    private void Start()
    {
        PlayerStatsScript = this.gameObject.GetComponent<PlayerStats>();
    }

    private void FixedUpdate()
    {
        if(PlayerStatsScript.Alive)
            PlayerMovement();

        // Checks if this object moves. If yes, 2D collider version also moves.
        if (transform.hasChanged == true) 
        {
            transform.hasChanged = false;
            Hole2DCollider.transform.position = new Vector2(transform.position.x, transform.position.z);
            Hole2DCollider.transform.localScale = transform.localScale * PlayerInitialScale;

            MakeHole2D();
            Make3DMeshCollider();
        }
    }

    private void MakeHole2D()
    {
        //Creates a hole in the collider
        Vector2[] PointPositions = Hole2DCollider.GetPath(0);

        for (int i = 0; i < PointPositions.Length; i++)
        {
            PointPositions[i] = Hole2DCollider.transform.TransformPoint(PointPositions[i]);
        }
        
        Ground2DCollider.pathCount = 2;
        Ground2DCollider.SetPath(1, PointPositions);
    }

    private void Make3DMeshCollider()
    {
        //Ensures generatedMesh is null. 
        if (generatedMesh != null)
            Destroy(generatedMesh);

        //Creates Mesh Collider
        generatedMesh = Ground2DCollider.CreateMesh(true, true);
        GeneratedMeshCollider.sharedMesh = generatedMesh;
    }

    public void PlayerMovement()
    {
        Vector3 Movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        transform.position += Movement * PlayerStatsScript.MovementSpeed * Time.deltaTime;
    }

    // Increase size w/ lerp
    public IEnumerator IncreaseSize()
    {
        if(transform.localScale.x < 10)
        {
            Vector3 StartScale = transform.localScale;
            Vector3 EndScale = StartScale * 2;

            float flag = 0;
            while (flag <= 0.4)
            {
                flag += Time.deltaTime;
                transform.localScale = Vector3.Lerp(StartScale, EndScale, flag);
                yield return null;
            }
        }
    }
}
