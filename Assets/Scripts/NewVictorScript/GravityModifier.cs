using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityModifier : MonoBehaviour
{
    public Vector3 startingGravity;
    public float newYGravity = -3f;
    public float Ylimit;
    private void Start()
    {
        startingGravity = Physics.gravity;
    }


    void Update()
    {
        if (transform.position.y<Ylimit)
        {
            Physics.gravity = new Vector3 (0,newYGravity, 0);
        }

        else
        {
            Physics.gravity = startingGravity;
        }
    }
}
