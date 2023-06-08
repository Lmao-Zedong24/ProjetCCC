using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HandCollider : MonoBehaviour
{
    Arm _arm;
    public float timeSinceCollisionSec { get; private set; } = 0f;
    public bool hasCollision { get => _collisionNormals.Count != 0; }
    public Vector2 _averageNormal { get; private set; } = Vector2.zero;

    Dictionary<GameObject, Vector2> _collisionNormals = new Dictionary<GameObject, Vector2>();
    private void Awake()
    {
        _arm = GetComponentInParent<Arm>();
    }

    void Update()
    {
        if (_collisionNormals.Count != 0)
            return;

        timeSinceCollisionSec += Time.deltaTime;
    }
    public void DebugHand()
    {
        _arm.DebugHand();
    }

    private void CalculateNewAverageNormal()
    {
        if (_collisionNormals.Count == 0)
            return;

        Vector2 sumNormals = Vector2.zero;

        foreach (var pair in _collisionNormals)
            sumNormals += pair.Value;

        _averageNormal = sumNormals.normalized;
    }

    private void AddCollisionNormals(Collision collision)
    {
        if (_collisionNormals.ContainsKey(collision.gameObject))
            return;

        Vector2 normal = Vector2.zero;
        foreach (var contact in collision.contacts)
            normal += (Vector2)contact.normal;

        normal = normal.normalized;
        _collisionNormals.Add(collision.gameObject, normal);
        CalculateNewAverageNormal();
    }

    void OnCollisionEnter(Collision collision)
    {
        AddCollisionNormals(collision);

        if (_collisionNormals.Count == 0)
            timeSinceCollisionSec = 0f;

        _arm.TryStick(collision);
    }

    void OnCollisionExit(Collision collision)
    {
        RemoveCollisionNormals(collision);
    }

    void RemoveCollisionNormals(Collision collision)
    {
        if (_collisionNormals.ContainsKey(collision.gameObject))
            _collisionNormals.Remove(collision.gameObject);

        CalculateNewAverageNormal();
    }
}

