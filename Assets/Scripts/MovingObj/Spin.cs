using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    public float rotationPerMinute;

    // Update is called once per frame
    void Update()
    {
        transform.rotation *= Quaternion.Euler(0, 0, Time.deltaTime * 6f * rotationPerMinute);
    }
}
