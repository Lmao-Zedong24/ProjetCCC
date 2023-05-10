using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR;

public class Arm : MonoBehaviour
{
    [SerializeField] private float maxLenght = 10f;

    [Header("Extend")]
    [SerializeField] private float minSpeedExtend = 10f;
    [SerializeField] private float maxSpeedExtend = 40f;
    [SerializeField] private float accelerationExtend = 10f;

    [Header("Extend")]
    [SerializeField] private float minSpeedRetract = 20f;
    [SerializeField] private float maxSpeedRetract = 20f;
    [SerializeField] private float accelerationRetract = 40f;

    private float currentMinSpeed;
    private float currentMaxSpeed;
    private float currentAcceleration;

    Transform hand;
    Rigidbody rbHand;
    //Rigidbody rbCylindre;

    private Vector2 desiredVelocity;
    EArmState armState;


    private enum EArmState
    {
        Inactive,
        Extend,
        Retract
    }

    // Start is called before the first frame update
    void Awake()
    {
        SetupRigidbodies();
    }

    // Update is called once per frame
    void Update()
    {


    }

    private void FixedUpdate()
    {
        if (armState == EArmState.Inactive)
            return;

        Vector2 distanceVec = hand.position - transform.position;
        if (distanceVec.sqrMagnitude <= 0 || distanceVec.sqrMagnitude >= maxLenght) //check if need to be inactive
        {
            armState = EArmState.Inactive;
            return;
        }

        //arm is active
        if (desiredVelocity.sqrMagnitude != 0)
            MoveHand();
    }

    private void SetupRigidbodies()
    {
        var rigidbodies = GetComponentsInChildren<Rigidbody>();

        foreach (Rigidbody rb in rigidbodies)
        {
            if (rb.gameObject.tag == "Hand")
            {
                rbHand = rb;
                hand = rb.gameObject.transform;
                break;
            }
        }
    }

    private void SetupArmState(EArmState state)
    {
        if (armState == state)
            return;

        //if (armState == EArmState.Inactive) //activate deactivate rb

        switch(state)
        {
            case EArmState.Inactive: //can do more here
                break;
            case EArmState.Extend:
                currentMinSpeed = minSpeedExtend;
                currentMaxSpeed = maxSpeedExtend;
                currentAcceleration = accelerationExtend;
                break;
            case EArmState.Retract:
                currentMinSpeed = minSpeedRetract;
                currentMaxSpeed = maxSpeedRetract;
                currentAcceleration = accelerationRetract; 
                break;
        }

        armState = state;
    }

    //Both kinda same
    public void ExtendArm()
    {
        SetupArmState(EArmState.Extend);

        Vector2 parentPos = gameObject.GetComponentInParent<Transform>().position;
        Vector2 awayParent = (Vector2)transform.position - parentPos;

        SetDisiredVelocity(awayParent);
    }

    public void RetractArm()
    {
        SetupArmState(EArmState.Retract);

        Vector2 parentPos = gameObject.GetComponentInParent<Transform>().position;
        Vector2 towoardsParent = parentPos - (Vector2)transform.position;

        SetDisiredVelocity(towoardsParent);
    }

    /// <summary>
    /// Cant invert dirForce direction based on maxSpeed
    /// </summary>
    private void SetDisiredVelocity(Vector2 dirForce)
    {
        desiredVelocity = dirForce * currentMaxSpeed;
        //desiredVelocity = dirForce * Mathf.Max(maxSpeed, 0f);
    }

    private void MoveHand()
    {
        Vector2 velocity = (Vector2)rbHand.velocity;

        if (velocity.sqrMagnitude < currentMinSpeed * currentMinSpeed) //if slower then min speed, set to min speed
            velocity = velocity.normalized * currentMinSpeed;

        float maxSpeedChange = currentAcceleration * Time.deltaTime;
        velocity = MyMoveTowards2D(velocity, desiredVelocity, maxSpeedChange);
        rbHand.velocity = (Vector3)velocity;
    }

    //// TODO : make MyMath script
    //private Vector2 ToVector2(Vector3 vec3)
    //{
    //    return new Vector2(vec3.x, vec3.y);
    //}
    //private Vector3 ToVector3(Vector2 vec2, float z = 0f)
    //{
    //    return new Vector3(vec2.x, vec2.y, z);
    //}

    // TODO : make MyMath script
    private Vector2 MyMoveTowards2D(Vector2 current, Vector2 target, float maxDelta)
    {
        if ((target - current).sqrMagnitude <= (maxDelta * maxDelta))
            return target;

        return current + (target - current).normalized * maxDelta;
    }



    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision == null) { return; }


    //}
}
