using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    public Vector3 rotationPerMinute;

    // Update is called once per frame
    void Update()
    {
        transform.rotation *= Quaternion.Euler(Time.deltaTime * 6f * rotationPerMinute);
    }
}
