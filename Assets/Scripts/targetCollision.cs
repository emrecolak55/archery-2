using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetCollision : MonoBehaviour
{
    // TODO (2+ Responsibilities)
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Arrow"))
        {
            // TODO (Logic) : You try to execute a "FallWith" logic which is fine.
            // However thing is, you should split responsibilities of "Actors"
            // "Actor-Target" should be responsible for its fall
            // "Actor-Arrow" should fall with "Actor-Target" while execute its own logic !!!
            // Solution -> Rename "CloneDestroyer" to "Arrow"
            //          -> Add "Fall" logic to that class
            //          -> Call : other.GetComponent<Arrow>().Fall()
            other.transform.parent = transform; // To let it fall with the target
            other.gameObject.GetComponent<Rigidbody>().isKinematic = true; // to stuck to the target

            GetComponent<Rigidbody>().isKinematic = false; // to let the target fall

            GameManager.score++; // Adds 1 to the scoreboard

            TargetSpawner.totalTargets--;
            Destroy(gameObject, 1f); // add couroutine here, when multiple arrows collides it still decreases totalTargets
            

        }
    }
   
}

