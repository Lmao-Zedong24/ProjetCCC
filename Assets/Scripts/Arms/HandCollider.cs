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
    public Vector2 collisionNormal { get; private set; }

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

        var normalSum = Vector2.zero;

        foreach (var point in collision.contacts)
            normalSum += (Vector2)point.normal;

        collisionNormal = (normalSum / (float)collision.contacts.Length).normalized;
        //collisionNormal = ((collisionNormal + (normalSum / (float)collision.contacts.Length).normalized) / 2f).normalized;

        Debug.Log("On: collisionNormal");

        _arm.TryStick(collision);
    }

    void OnCollisionExit(Collision collision)
    {
        _collisions.Remove(collision.gameObject);

        //if (_collisions.Count == 0)
        //    Invoke(nameof(ResetNormal), 3 * Time.fixedDeltaTime);
    }

    void ResetNormal()
    {
        //Debug.Log("Off : " + collisionNormal);
        //collisionNormal = Vector3.zero;
    }
}
