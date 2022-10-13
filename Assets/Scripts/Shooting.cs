using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] GameObject arrowPrefab;
    [SerializeField] Transform arrowTransform;
    [SerializeField] float maxArrowForce = 200f;
    float currentArrowForce;
    float maxLerpTime = 1.0f;
    float currentLerpTime;
    Animator bowAnimator;
    void Start()
    {
        bowAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.gameStarted)
        {
            if (Input.GetMouseButtonDown(0)) // 0 for left mouse button // It checks if it's pressed once
            {
                DrawBow();
            }
            if (Input.GetMouseButton(0)) // Longer it's pressed greater force we apply
            {
                PowerUpBow();
            }
            if (Input.GetMouseButtonUp(0)) // Longer it's pressed greater force we apply
            {
                ReleaseBow();
            }
            else if(!GameManager.gameStarted)
            {
                bowAnimator.SetBool("drawing", false);
                currentArrowForce = 0;
            }
        }
        
    }

    private void ReleaseBow()
    {
        bowAnimator.SetBool("drawing", false);

        GameObject arrow = Instantiate(arrowPrefab, arrowTransform.position,arrowTransform.rotation) as GameObject;
        arrow.GetComponent<Rigidbody>().AddForce(arrowTransform.forward * currentArrowForce, ForceMode.Impulse);
    }

    private void PowerUpBow()
    {
        currentLerpTime = Time.deltaTime; // calculates the time 

        if (currentLerpTime > maxLerpTime)
            currentLerpTime = maxLerpTime;

        float percentage = currentLerpTime / maxLerpTime;
        currentArrowForce = Mathf.Lerp(0, maxArrowForce, percentage); // gives a value produced by percentage

    }

    private void DrawBow()
    {
        bowAnimator.SetBool("drawing", true);
    }
}
