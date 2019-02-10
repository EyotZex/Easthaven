using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLauncher : MonoBehaviour
{
    public GameObject projectile;
    public Transform shotPoint;
    public bool hasThrowable = false;
    public GameObject projectileIcon;
    public AlternativePlayerControls alternativePlayerScript;
    public DoubleClickDetect doubleclickDetectScript;

    void Update()
    {

        if (hasThrowable)
        {
            projectileIcon.SetActive(true);
        }
        else
        {
            projectileIcon.SetActive(false);
        }
        if (doubleclickDetectScript.DoubleClicked2)
        {
            if (hasThrowable)
            {
                Instantiate(projectile, shotPoint.position, shotPoint.rotation);
                hasThrowable = false;
            }
        }
    }
}
