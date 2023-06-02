using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public bool isTriggered { get; private set; } = false;

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        isTriggered |= true;
    }

    private void OnTriggerExit(Collider other)
    {
        isTriggered = false;
    }
}
