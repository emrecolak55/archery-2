using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowController : MonoBehaviour
{
    [SerializeField] private float rotateSpeed = 0.5f;
    [SerializeField] private Vector2 rotationLimit = new Vector2 ( 45 , 100 ); // according to the rotation of the bow
    private Vector3 targetAngle;
    private Quaternion firstRotation;
    void Start()
    {
        firstRotation = transform.localRotation; // just rotation is also okay // it stores the first rotation

    }

    // Update is called once per frame
    void Update()
    {
        targetAngle.x += Input.GetAxis("Mouse Y") * rotateSpeed; // Returns the mouse Y movement, vertical
        targetAngle.y += Input.GetAxis("Mouse X") * rotateSpeed; // Mouse horizontal
        

        targetAngle.y = Mathf.Clamp(targetAngle.y, -rotationLimit.y, rotationLimit.y); // Limits the rotation by the given min and max values
        targetAngle.x = Mathf.Clamp(targetAngle.x, -rotationLimit.x, rotationLimit.x);

        Quaternion targetRotation = Quaternion.Euler(targetAngle.x, -targetAngle.y, 0); // Creating a rotation quaternion by targetAngle values

        gameObject.transform.localRotation =  firstRotation * targetRotation; // rotation has set to its new values
    }
}
