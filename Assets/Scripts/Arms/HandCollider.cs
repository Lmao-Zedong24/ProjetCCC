using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandCollider : MonoBehaviour
{
    public float timeSinceCollisionSec { get; private set; } = 0f;
    public bool hasCollision { get => _collisions.Count != 0; }

    HashSet<GameObject> _collisions = new HashSet<GameObject>();


    void Update()
    {
        if (_collisions.Count != 0)
        { return; }

        timeSinceCollisionSec += Time.deltaTime;
    }
    void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (_collisions.Count == 0)
            timeSinceCollisionSec = 0f;
        
        _collisions.Add(collision.gameObject);
    }

    void OnCollisionExit(UnityEngine.Collision collision)
    {
        _collisions.Remove(collision.gameObject);
    }
}
