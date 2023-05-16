using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR;
using static UnityEditor.PlayerSettings;

public class Arm : MonoBehaviour
{
    private float maxLenght = 10f;

    private float minSpeedExtend = 10f;
    private float maxSpeedExtend = 40f;
    private float accelerationExtend = 10f;

    private float minSpeedRetract = 20f;
    private float maxSpeedRetract = 20f;
    private float accelerationRetract = 40f;

    private float currentMinSpeed;
    private float currentMaxSpeed;
    private Vector2 currentVelocity;
    private float currentAcceleration;
    private EArmState armState;
    private Vector2 directionVec;


    Transform hand;
    Rigidbody rbHand;
    FixedJoint joint;
    //Rigidbody rbCylindre;

    private Vector2 desiredVelocity;


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
        //SetupArmInfo();
    }

    // Update is called once per frame
    void Update()
    {


    }

    private void FixedUpdate()
    {
        if (armState != EArmState.Inactive)
        {
            MoveHand();

        }

        hand.localPosition = Vector2.Dot(hand.localPosition, directionVec) * directionVec; //dirVec already 

        if (armState != EArmState.Inactive)
            joint.connectedAnchor = hand.localPosition;




        float dot = Vector2.Dot(directionVec, hand.localPosition - transform.localPosition);

        if ((armState == EArmState.Retract && dot >= 0f) ||
            (armState == EArmState.Extend && dot >= maxLenght)) //check if need to be inactive
        {
            armState = EArmState.Inactive;
            return;
        }
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
                break;
            }
        }

        //Physics.IgnoreCollision(this.GetComponentInParent<Collider>(), rbHand.GetComponent<Collider>());
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
        return true;
    }

    //Both kinda same
    public void ExtendArm()
    {
        if (!SetupArmState(EArmState.Extend))
            return;

        directionVec = transform.localPosition.normalized;
        currentVelocity = new Vector2(0f, 0f);

        SetDisiredVelocity();
    }

    public void RetractArm()
    {
        if (!SetupArmState(EArmState.Retract))
            return;

        directionVec = -(transform.localPosition.normalized);
        currentVelocity = new Vector2(0f, 0f);

        SetDisiredVelocity();
    }

    private void SetDisiredVelocity()
    {
        desiredVelocity = directionVec * currentMaxSpeed;
        //desiredVelocity = dirForce * Mathf.Max(maxSpeed, 0f);
    }

    private void MoveHand()
    {
        if (currentVelocity.sqrMagnitude < currentMinSpeed * currentMinSpeed) //if slower then min speed, set to min speed
            currentVelocity = desiredVelocity.normalized * currentMinSpeed;
        
        if (currentAcceleration != 0)
        {
            float maxSpeedChange = currentAcceleration * Time.deltaTime;
            currentVelocity = MyMoveTowards2D(currentVelocity, desiredVelocity, maxSpeedChange);
        }

        Vector2 pos = (Vector2)rbHand.transform.localPosition;
        pos = MyLerp2D(pos, currentVelocity, Time.deltaTime);

        rbHand.transform.localPosition = (Vector3)pos;
        //rbHand.MovePosition(pos);
    }

    // TODO : make MyMath script
    private Vector2 MyMoveTowards2D(Vector2 current, Vector2 target, float maxDelta)
    {
        if ((target - current).sqrMagnitude <= (maxDelta * maxDelta))
            return target;

        return current + (target - current).normalized * maxDelta;
    }

    private Vector2 MyLerp2D(Vector2 current, Vector2 direction, float t)
    {
        return current + (direction * t);
    }


    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision == null) { return; }
    //}
}
