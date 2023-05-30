using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandCollider : MonoBehaviour
{
    HashSet<GameObject> _collisions = new HashSet<GameObject>();
    public float timeSinceCollisionSec { get; private set; } = 0f;
    public bool hasCollision { get => _collisions.Count != 0; }

    void Update()
    {
        if (_collisions.Count != 0)
            return;

        timeSinceCollisionSec += Time.deltaTime;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (_collisions.Count == 0)
            timeSinceCollisionSec = 0f;

        HandTagCollisionManager.Instance.InvokeTagCollisionFunc(collision);
        _collisions.Add(collision.gameObject);
    }

    void OnCollisionExit(Collision collision)
    {
        _collisions.Remove(collision.gameObject);
    }
}
