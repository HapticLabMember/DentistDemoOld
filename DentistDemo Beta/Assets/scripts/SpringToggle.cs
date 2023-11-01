using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprintToggle : MonoBehaviour

{
    private bool isGrabbed = false;
    private SpringJoint springJoint;

    public HapticPlugin hp;

    void Start()
    {
        springJoint = GetComponent<SpringJoint>();
        // Disable the spring force initially
        springJoint.spring = 0f;
    }

    void Update()
    {
        // Check if the tooth is grabbed
        if (isGrabbed)
        {
            // Enable the spring force when grabbed
            springJoint.spring = 0.1f;
        }
        else
        {
            // Disable the spring force when not grabbed
            springJoint.spring = 0f;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the trigger zone is the stylus or hand
        if (other.CompareTag("Stylus") || other.CompareTag("Hand"))
        {
            isGrabbed = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Check if the object leaving the trigger zone is the stylus or hand
        if (other.CompareTag("Stylus") || other.CompareTag("Hand"))
        {
            isGrabbed = false;
        }
    }
}
