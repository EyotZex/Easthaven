using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLauncher : MonoBehaviour
{
    public GameObject projectile;
    public Transform shotPoint;
    public bool hasThrowable = false;
    public GameObject projectileIcon;
    public GameObject projectileReadyIcon;
    public AlternativePlayerControls alternativePlayerScript;
    public DoubleClickDetect doubleclickDetectScript;
    public float holdRightClick;
    public float holdRequired;
    public bool readyToThrow = false;

    void Update()
    {

        if (hasThrowable)
        {
            if (holdRightClick >= holdRequired)
            {
                projectileReadyIcon.SetActive(true);
                projectileIcon.SetActive(false);
            }
            else
            {
                projectileReadyIcon.SetActive(false);
                projectileIcon.SetActive(true);
            }
        }
        else
        {
            projectileReadyIcon.SetActive(false);
            projectileIcon.SetActive(false);
        }

        if (Input.GetMouseButtonDown(1))
        {
            readyToThrow = true;
        }
        if (Input.GetMouseButton(1))
        {
            if (readyToThrow)
            {
                holdRightClick += Time.deltaTime;
            }
        }

        if (Input.GetMouseButtonUp(1))
        {
            if (holdRightClick >= holdRequired && hasThrowable)
            {
                Instantiate(projectile, shotPoint.position, shotPoint.rotation);
                hasThrowable = false;
            }
            holdRightClick = 0;
            readyToThrow = false;
        }
        if (Input.GetMouseButtonDown(0))
        {
            holdRightClick = 0;
            readyToThrow = false;
        }
    }
}