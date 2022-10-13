using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideCursor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Hides the mouse cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // TODO (Improvement) : Do not leave unused Update() methods.
    // Unity tries to "update" them !!! It waste CPU source.
    // Update is called once per frame
    void Update()
    {
        
    }
}
