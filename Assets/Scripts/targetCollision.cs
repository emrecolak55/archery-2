using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Arrow"))
        {
            other.transform.parent = transform; // To let it fall with the target
            other.gameObject.GetComponent<Rigidbody>().isKinematic = true; // to stuck to the target

            GetComponent<Rigidbody>().isKinematic = false; // to let the target fall

            GameManager.score++; // Adds 1 to the scoreboard

            TargetSpawner.totalTargets--;
            Destroy(gameObject, 1f); // add couroutine here, when multiple arrows collides it still decreases totalTargets
            

        }
    }
   
}

