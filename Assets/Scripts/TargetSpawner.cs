using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    
    [SerializeField] private Vector3 spawnArea = new Vector3(3, 3, 3);
    [SerializeField] private int targetsToSpawn = 3;
    [SerializeField] private GameObject targetPrefab;
    public static int totalTargets = 0;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(totalTargets == 0 && GameManager.gameStarted)
        {
            SpawnTargets();
        }
        if(!GameManager.gameStarted && totalTargets > 0)
        {
            DestoryTargets();
        }
    }

    void SpawnTargets()
    {
        if(totalTargets == 0)
        {
            float xMin = transform.position.x - spawnArea.x / 2;    // Calculates min and max values of spawnarea
            float yMin = transform.position.y - spawnArea.y / 2;
            float zMin = transform.position.z - spawnArea.z / 2;
            float xMax = transform.position.x + spawnArea.x / 2;
            float yMax = transform.position.y + spawnArea.y / 2;
            float zMax = transform.position.z + spawnArea.z / 2;

            for( int i = 0; i < targetsToSpawn; i++) // Instantiate until reaching the max number of targets we want
            {
                float xRandom = Random.Range(xMin, xMax);
                float yRandom = Random.Range(yMin, yMax);
                float zRandom = Random.Range(zMin, zMax);
                Vector3 randomPos = new Vector3(xRandom, yRandom, zRandom);
                // TODO (Improvement) : Do not Instantiate an Target !
                // You can use Object Pool Pattern for reusable items like Targets.
                // Check out this video -> https://www.youtube.com/watch?v=tdSmKaJvCoA
                Instantiate(targetPrefab, randomPos, targetPrefab.transform.rotation);
                totalTargets++;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(transform.position, spawnArea);
    }

    void DestoryTargets()
    {
        totalTargets = 0;

        GameObject[] targets = GameObject.FindGameObjectsWithTag("Target");
        for( int i = 0; i < targets.Length; i++)
        {
            Rigidbody targetRigidBody = targets[i].GetComponent<Rigidbody>(); // Set rigibody to dynamic so they fall
            targetRigidBody.isKinematic = false;

            Collider targetCollider = targets[i].GetComponent<Collider>(); // To prevent unnecessary collisions after arrow hit
            targetCollider.enabled = false;

            // TODO (Improvement) : Do not Destroy an Target !
            // You can use Object Pool Pattern for reusable items like Targets.
            // Check out this video -> https://www.youtube.com/watch?v=tdSmKaJvCoA
            Destroy(targets[i], 1f); 
        }
            
    }
}
