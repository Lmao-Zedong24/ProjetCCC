using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearScript : MonoBehaviour
{
    public float rotationSpeed = 5f; // Vitesse de rotation

    void Update()
    {

        // Effectue la rotation en fonction des valeurs des axes X et Y
        transform.Rotate(0,0, rotationSpeed);
    }
}
