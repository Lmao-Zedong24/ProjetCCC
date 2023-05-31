using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using TMPro.EditorUtilities;
using UnityEngine;

public class Arm : MonoBehaviour
{
    const float COLLISION_BUFFER_SEC = 0.25f;

    private float currentMinSpeed;
    private float currentMaxSpeed;
    private Vector2 desiredVelocity;
    private Vector2 currentVelocity;
    private float currentAcceleration;
    private Vector2 localDirectionVec;
    private Vector3? staticPosWorld;
    private RigidbodyConstraints mainConstraints;

    HandCollider    _colHand;
    Transform       _hand;
    Rigidbody       _mainBody;
    Rigidbody       _rbHand;
    FixedJoint      _joint;

    ArmInfo _armInfo;

    public bool hasCollission { get => _colHand.hasCollision; }
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
        SetupHandTagCollisions();
        SetupArmState(EArmState.StaticIn);

        //SetupArmInfo();
    }

    // Update is called once per frame
    void Update()
    {


    }

    private void FixedUpdate()
    {
        if (isSticking)
            _mainBody.velocity = new Vector3(0, 0, 0);

        if (!isStaticState && !isSticking)
        {
            MoveHand();
            _hand.localPosition = Vector2.Dot(_hand.localPosition, localDirectionVec) * localDirectionVec; //dirVec already 
        }

        _hand.localPosition = Vector2.Dot(_hand.localPosition, localDirectionVec) * localDirectionVec; //dirVec already 

        if (!isStaticState)
            _joint.connectedAnchor = _hand.localPosition;


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
                _rbHand = rb;
                _hand = rb.gameObject.transform;
                _joint = _hand.GetComponent<FixedJoint>();
                _colHand = _hand.GetComponent<HandCollider>();
                break;
            }
        }

        _mainBody = GetComponentInParent<Rigidbody>();
        mainConstraints = _mainBody.constraints;
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
        return (armState == EArmState.Extend && dot >= _armInfo.maxLenght);
    }

    private bool StopRetract(float dot)
    {
        return (armState == EArmState.Retract && dot >= 0f);
    }

    private float ArmLengthDot()
    {
        return Vector2.Dot(localDirectionVec, _hand.localPosition - transform.localPosition);
    }

    public void SetupArmInfo(ArmInfo armInfo)
    {
        _armInfo = armInfo;
    }

    public void SetSpawnLocalPos(Vector2 localPos)
    {
        transform.localPosition = localPos;
        _joint.connectedAnchor = _hand.localPosition;
    }


    bool SetupArmState(EArmState state)
    {
        if (armState == state)
            return false;

        staticPosWorld = null;
        _mainBody.constraints = mainConstraints;

        switch (state)
        {
            case EArmState.StaticIn: //can do more here
                isSticky = false;
                float dot = Vector2.Dot(_mainBody.rotation * localDirectionVec, new Vector2(1f, 0f));
                _mainBody.AddRelativeTorque(0f, 0f, (dot > 0 ? 1 : -1) * _armInfo.rotationMultiplier, ForceMode.VelocityChange);
                break;

            case EArmState.StaticOut:
                break;

            case EArmState.Extend:
                currentMinSpeed = _armInfo.minSpeedExtend;
                currentMaxSpeed = _armInfo.maxSpeedExtend;
                currentAcceleration = _armInfo.accelerationExtend;
                break;

            case EArmState.Retract:
                currentMinSpeed = _armInfo.minSpeedRetract;
                currentMaxSpeed = _armInfo.maxSpeedRetract;
                currentAcceleration = _armInfo.accelerationRetract;
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

        localDirectionVec = -transform.localPosition.normalized;
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

        Vector2 posLocal = (Vector2)_rbHand.transform.localPosition;
        MyLerp2D(ref posLocal, currentVelocity, Time.deltaTime);


        if (armState == EArmState.Retract)
        {
            _rbHand.transform.localPosition = (Vector3)posLocal;
            return;
        }

        if (_colHand.hasCollision ||
            (_colHand.timeSinceCollisionSec < COLLISION_BUFFER_SEC && staticPosWorld.HasValue))
        {
            staticPosWorld ??= _rbHand.transform.position;
            _rbHand.transform.position = staticPosWorld.Value;
            _mainBody.constraints |= RigidbodyConstraints.FreezeRotation;

            Vector2 force = new Vector2();
            switch (_armInfo.impactMode)
            {
                case ArmInfo.ImpactMode.ArmVelocity:
                    force = transform.rotation * currentVelocity * -_armInfo.forceMultiplier * Time.deltaTime;
                    break;

                case ArmInfo.ImpactMode.SetValue:
                    force = transform.rotation * currentVelocity.normalized * -_armInfo.forceMultiplier;
                    break;

                case ArmInfo.ImpactMode.ArmExtendLength:
                    force = transform.rotation * currentVelocity.normalized * -_armInfo.forceMultiplier * (_armInfo.maxLenght - ArmLengthDot()); //world
                    SetupArmState(EArmState.Retract);
                    break;
            }
            _mainBody.AddForce((Vector3)force, ForceMode.VelocityChange);
            _armInfo.lastImpactForce = force;

            return;
        }

        staticPosWorld = null;
        _mainBody.constraints = mainConstraints;


        float overshootLenght = MyCheckCollisions2D(    _hand.position,
                                                        transform.rotation * localDirectionVec,        //world
                                                        (currentVelocity * Time.deltaTime).sqrMagnitude,
                                                        _rbHand.transform.lossyScale.x / 2f);
        //float overshootLenght = MyCheckCollisions2D(    colHand,
        //                                                hand.localPosition,
        //                                                localDirectionVec,        //world
        //                                                (currentVelocity * Time.deltaTime).magnitude);

        if (overshootLenght != 0)
        {
            Vector2 overshootVec = -overshootLenght * localDirectionVec;
            posLocal += overshootVec;
            _mainBody.AddForce(transform.rotation * overshootVec, ForceMode.VelocityChange); //world
        }

        _rbHand.transform.localPosition = (Vector3)posLocal;
        //rbHand.MovePosition(pos);
    }

    private void SetupHandTagCollisions()
    {
        var manager = HandTagCollisionManager.Instance;

        manager.AddTagCollisionFunc("MovingCollider", new HandTagCollisionManager.TagCollisionCallback(StickToMovingCollider));
    }

    void StickToMovingCollider(Collision collision)
    {
        _mainBody.transform.parent = collision.transform;
        return;
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
