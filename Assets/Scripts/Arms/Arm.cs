using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Arm : MonoBehaviour
{
    const float COLLISION_BUFFER_SEC = 0.25f;

    private float maxLenght = 10f;
    private float minSpeedExtend = 10f;
    private float maxSpeedExtend = 40f;
    private float accelerationExtend = 10f;
    private float minSpeedRetract = 20f;
    private float maxSpeedRetract = 20f;
    private float accelerationRetract = 40f;

    private float currentMinSpeed;
    private float currentMaxSpeed;
    private Vector2 desiredVelocity;
    private Vector2 currentVelocity;
    private float currentAcceleration;
    private Vector2 localDirectionVec;
    private Vector3? staticPosWorld;
    private RigidbodyConstraints mainConstraints;

    HandCollider colHand;
    Transform   hand;
    Rigidbody   mainBody;
    Rigidbody   rbHand;
    FixedJoint  joint;


    public bool hasCollission { get => colHand.hasCollision; }
    public bool isSticky { get; set; }
    public bool isSticking { get => isSticky && hasCollission; }
    public bool isStaticState { get => armState == EArmState.StaticIn || armState == EArmState.StaticOut; }
    public EArmState armState { get; private set; }

    

    public enum EArmState
    {
        StaticIn,
        Extend,
        Retract,
        StaticOut
    }

    // Start is called before the first frame update
    void Awake()
    {
        SetupRigidbodies();
        //SetupArmInfo();
    }

    // Update is called once per frame
    void Update()
    {


    }

    private void FixedUpdate()
    {
        //if (isSticking)
        //    return;

        if (!isStaticState)
        {
            MoveHand();
            hand.localPosition = Vector2.Dot(hand.localPosition, localDirectionVec) * localDirectionVec; //dirVec already 
        }

        hand.localPosition = Vector2.Dot(hand.localPosition, localDirectionVec) * localDirectionVec; //dirVec already 

        if (!isStaticState)
            joint.connectedAnchor = hand.localPosition;


        if (ShouldBeInactive()) //check if need to be inactive
            SetupArmState(EArmState.StaticIn);

        if (ShouldBeFullOut())
            SetupArmState(EArmState.StaticOut);
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
                joint = hand.GetComponent<FixedJoint>();
                colHand = hand.GetComponent<HandCollider>();
                break;
            }
        }

        mainBody = GetComponentInParent<Rigidbody>();
        mainConstraints = mainBody.constraints;
    }

    private bool ShouldBeInactive()
    {
        float dot = ArmLengthDot();

        return StopRetract(dot); //check if need to be inactive
    }

    private bool ShouldBeFullOut()
    {
        float dot = ArmLengthDot();

        return StopExtend(dot); //check if need to be inactive
    }

    private bool StopExtend(float dot)
    {
        return (armState == EArmState.Extend && dot >= maxLenght);
    }

    private bool StopRetract(float dot)
    {
        return (armState == EArmState.Retract && dot >= 0f);
    }

    private float ArmLengthDot()
    {
        return Vector2.Dot(localDirectionVec, hand.localPosition - transform.localPosition);
    }

    public void SetupArmInfo(ArmInfo armInfo)
    {
        if (armInfo == null)
            return;

        maxLenght = armInfo.maxLenght;
        
        minSpeedExtend = armInfo.minSpeedExtend;
        maxSpeedExtend = armInfo.maxSpeedExtend;
        accelerationExtend = armInfo.accelerationExtend;
        
        minSpeedRetract = armInfo.minSpeedRetract;
        maxSpeedRetract = armInfo.maxSpeedRetract;
        accelerationRetract = armInfo.accelerationRetract;
    }

    public void SetSpawnLocalPos(Vector2 localPos)
    {
        transform.localPosition = localPos;
        joint.connectedAnchor = hand.localPosition;
    }


    bool SetupArmState(EArmState state)
    {
        if (armState == state)
            return false;

        staticPosWorld = null;
        mainBody.constraints = mainConstraints;

        switch (state)
        {
            case EArmState.StaticIn: //can do more here
                isSticky = false;
                break;

            case EArmState.StaticOut:
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
                mainBody.constraints = mainConstraints;
                isSticky = false;
                break;

            //case EArmState.Static:
            //    staticPos = hand.transform.localToWorldMatrix * hand.transform.localPosition;
            //    //rbHand.isKinematic = true;
            //    break;
        }

        //if (state != EArmState.Static)
            //rbHand.isKinematic = false;

        armState = state;
        return true;
    }

    //Both kinda same
    public void ExtendArm()
    {
        if (StopExtend(ArmLengthDot()))
            return;

        SetupArmState(EArmState.Extend);

        localDirectionVec = transform.localPosition.normalized;
        currentVelocity = new Vector2(0f, 0f);

        SetDisiredVelocity();
    }

    public void RetractArm()
    {
        if (StopExtend(ArmLengthDot()))
            return;

        SetupArmState(EArmState.Retract);

        localDirectionVec = -(transform.localPosition.normalized);
        currentVelocity = new Vector2(0f, 0f);

        SetDisiredVelocity();
    }

    private void SetDisiredVelocity()
    {
        desiredVelocity = localDirectionVec * currentMaxSpeed;
        //desiredVelocity = dirForce * Mathf.Max(maxSpeed, 0f);
    }

    private void MoveHand()
    {
        if (currentVelocity.sqrMagnitude < currentMinSpeed * currentMinSpeed) //if slower then min speed, set to min speed
            currentVelocity = localDirectionVec.normalized * currentMinSpeed;
        
        if (currentAcceleration != 0)
        {
            float maxSpeedChange = currentAcceleration * Time.deltaTime;
            currentVelocity = MyMoveTowards2D(currentVelocity, desiredVelocity, maxSpeedChange);
        }


        //if (hasCollission)
        //{
        //    mainBody.AddForce(transform.rotation * -currentVelocity, ForceMode.VelocityChange); //world
        //    return;
        //}

        Vector2 posLocal = (Vector2)rbHand.transform.localPosition;
        MyLerp2D(ref posLocal, currentVelocity, Time.deltaTime);


        if (armState == EArmState.Retract)
        {
            rbHand.transform.localPosition = (Vector3)posLocal;
            return;
        }

        if (colHand.hasCollision ||
            (colHand.timeSinceCollisionSec < COLLISION_BUFFER_SEC && staticPosWorld.HasValue))
        {
            if (!staticPosWorld.HasValue)
                staticPosWorld = rbHand.transform.position;

            rbHand.transform.position = staticPosWorld.Value;
            mainBody.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
            mainBody.AddForce(transform.rotation * currentVelocity * -Time.deltaTime, ForceMode.VelocityChange); //world
            return;
        }

        mainBody.constraints = mainConstraints;


        float overshootLenght = MyCheckCollisions2D(    hand.position,
                                                        transform.rotation * localDirectionVec,        //world
                                                        (currentVelocity * Time.deltaTime).sqrMagnitude,
                                                        rbHand.transform.lossyScale.x / 2f);
        //float overshootLenght = MyCheckCollisions2D(    colHand,
        //                                                hand.localPosition,
        //                                                localDirectionVec,        //world
        //                                                (currentVelocity * Time.deltaTime).magnitude);

        if (overshootLenght != 0)
        {
            Vector2 overshootVec = -overshootLenght * localDirectionVec;
            posLocal += overshootVec;
            mainBody.AddForce(transform.rotation * overshootVec, ForceMode.VelocityChange); //world
        }

        rbHand.transform.localPosition = (Vector3)posLocal;
        //rbHand.MovePosition(pos);
    }

    //void MoveBody()
    //{

    //    rbHand.transform.localPosition = (Vector3)pos;
    //}

    // TODO : make MyMath script

    /// <summary>
    /// Cast collider ray to end position 
    /// </summary>
    /// <param name="endPosWorld"></param>
    /// <param name="collider"></param>
    /// <returns> overshoot length (if hit)</returns>
    private float MyCheckCollisions2D(Vector2 posWorld, Vector2 dirWorld, float maxDistance, float radius)
    {
        Ray ray = new Ray(posWorld, dirWorld);
        Debug.DrawLine(posWorld, posWorld + dirWorld * (maxDistance + radius), Color.red);

        //if (Physics.Raycast(ray, out RaycastHit hitInfo, maxDistance))
        //    return maxDistance - hitInfo.distance;

        if (Physics.Raycast(ray, out RaycastHit hitInfo, (maxDistance + radius)))
        {
            //var sph = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            //sph.gameObject.transform.SetPositionAndRotation(posWorld, Quaternion.identity);
            //sph.GetComponent<Collider>().enabled = false;

            return maxDistance - hitInfo.distance;
        }

        //no hit 
        return 0f;
    }


    private Vector2 MyMoveTowards2D(Vector2 current, Vector2 target, float maxDelta)
    {
        if ((target - current).sqrMagnitude <= (maxDelta * maxDelta))
            return target;

        return current + (target - current).normalized * maxDelta;
    }

    private void MyLerp2D(ref Vector2 current, Vector2 directionNormalized, float t)
    {
        current += (directionNormalized * t);
    }

    private void MyLerp2D(ref Vector2 current, Vector2 directionOfLengthT)
    {
        current += directionOfLengthT;
    }
}
