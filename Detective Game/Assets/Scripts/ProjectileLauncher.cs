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
        if (Input.GetMouseButtonDown(1) && alternativePlayerScript.playerStill)
        {
            if (hasThrowable)
            {
                Instantiate(projectile, shotPoint.position, shotPoint.rotation);
                hasThrowable = false;
            }
        }
    }
}
