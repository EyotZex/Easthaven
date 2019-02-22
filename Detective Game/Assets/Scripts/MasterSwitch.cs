using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterSwitch : MonoBehaviour
{
    public bool interactRange = false;
    public Transform circleOrigin;
    public LayerMask playerLayer;
    public float maskSize;

    public AutomaticDoor automaticDoorScript;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        interactRange = Physics2D.OverlapCircle(circleOrigin.position, maskSize, playerLayer);

        if (interactRange)
        {
            if (Input.GetMouseButtonDown(1))
            {
                if (automaticDoorScript.isOpen == false)
                {
                    automaticDoorScript.instructionRecieved = false;
 //                   automaticDoorScript.isOpen = true;
                }
                else
                {
                    automaticDoorScript.instructionRecieved = false;
 //                   automaticDoorScript.isOpen = false;
                }
            }
        }
    }
}
