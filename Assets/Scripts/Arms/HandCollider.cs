using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HandCollider : MonoBehaviour
{
    Arm _arm;

    HashSet<GameObject> _collisions = new HashSet<GameObject>();
    public float timeSinceCollisionSec { get; private set; } = 0f;
    public bool hasCollision { get => _collisions.Count != 0; }

    private void Awake()
    {
        _arm = GetComponentInParent<Arm>();
    }

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

        _collisions.Add(collision.gameObject);
        _arm.TryStick(collision);
    }

    void OnCollisionExit(Collision collision)
    {
        _collisions.Remove(collision.gameObject);
    }
}
