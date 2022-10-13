using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneDestroyer : MonoBehaviour
{
    [SerializeField] private float destroyTime;
    void Start()
    {
        // TODO (Improvement) : Do not Destroy an Arrow !
        // You can use Object Pool Pattern for reusable items like Arrows.
        // Check out this video -> https://www.youtube.com/watch?v=tdSmKaJvCoA
        Destroy(gameObject, destroyTime);
    }  
}
