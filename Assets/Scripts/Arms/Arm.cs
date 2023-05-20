using System.Collections;
using System.Collections.Generic;
using System.Data;
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
    private Vector2 localDirectionVec;
    private Vector3 staticPos;

    bool hasCollission;
    RigidbodyConstraints mainConstraints;


    public EArmState armState { get; private set; }

    public Collider colHand { get; private set; }
    Transform   hand;
    Rigidbody mainBody;
    Rigidbody   rbHand;
    FixedJoint  joint;
    //Rigidbody rbCylindre;

    private Vector2 desiredVelocity;


    public enum EArmState
    {
        Inactive,
        Extend,
        Retract,
        Static
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

        if (armState == EArmState.Static)
        {
            //hand.position = staticPos;
        }
        else if (armState != EArmState.Inactive)
        {
            //if (hasCollission)
                //MoveBody();
            //else
                MoveHand();
            //projection
            hand.localPosition = Vector2.Dot(hand.localPosition, localDirectionVec) * localDirectionVec; //dirVec already 
            //if (armState != EArmState.Inactive)
            //    joint.connectedAnchor = hand.localPosition;
        }

        hand.localPosition = Vector2.Dot(hand.localPosition, localDirectionVec) * localDirectionVec; //dirVec already 

        if (armState != EArmState.Inactive && armState != EArmState.Static)
            joint.connectedAnchor = hand.localPosition;

        //float dot = Vector2.Dot(directionVec, hand.localPosition - transform.localPosition);

        //if (ShouldBeStatic())
        //{
        //    //SetupArmState(EArmState.Static);
        //}

        if (ShouldBeInactive()) //check if need to be inactive
            SetupArmState(EArmState.Inactive);
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
                colHand = hand.GetComponent<Collider>();
                break;
            }
        }

        mainBody = GetComponentInParent<Rigidbody>();
        mainConstraints = mainBody.constraints;

        //Physics.IgnoreCollision(this.GetComponentInParent<Collider>(), rbHand.GetComponent<Collider>());
    }

    private bool ShouldBeInactive()
    {
        float dot = ArmLengthDot();

        return StopExtend(dot) || StopRetract(dot); //check if need to be inactive
    }

    private bool ShouldBeStatic()
    {
        float dot = ArmLengthDot();

        return StopExtend(dot);
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

        //if (armState == EArmState.Inactive) //activate deactivate rb

        switch(state)
        {
            case EArmState.Inactive: //can do more here
                mainBody.constraints = mainConstraints;
                break;

            case EArmState.Extend:
                currentMinSpeed = minSpeedExtend;
                currentMaxSpeed = maxSpeedExtend;
                currentAcceleration = accelerationExtend;
                mainBody.constraints = RigidbodyConstraints.FreezeRotation;
                break;

            case EArmState.Retract:
                currentMinSpeed = minSpeedRetract;
                currentMaxSpeed = maxSpeedRetract;
                currentAcceleration = accelerationRetract;
                mainBody.constraints = mainConstraints;
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

        Vector2 posLocal = (Vector2)rbHand.transform.localPosition;
        MyLerp2D(ref posLocal, currentVelocity, Time.deltaTime);


        if (armState == EArmState.Retract)
        {
            rbHand.transform.localPosition = (Vector3)posLocal;
            return;
        }

        float overshootLenght = MyCheckCollisions2D(    colHand,
                                                        hand.position,
                                                        transform.rotation * localDirectionVec,        //world
                                                        (currentVelocity * Time.deltaTime).magnitude);
        //float overshootLenght = MyCheckCollisions2D(    colHand,
        //                                                hand.localPosition,
        //                                                localDirectionVec,        //world
        //                                                (currentVelocity * Time.deltaTime).magnitude);

        if (overshootLenght != 0)
        {
            Vector2 overshootVec = -overshootLenght * localDirectionVec;
            posLocal += overshootVec;
            Debug.DrawLine(mainBody.position, mainBody.position + transform.rotation * overshootVec, Color.magenta);
            mainBody.AddForce(transform.rotation * overshootVec, ForceMode.VelocityChange); //world
        }

        rbHand.transform.localPosition = (Vector3)posLocal;
        //rbHand.MovePosition(pos);
    }

    void MoveBody()
    {

    }

    // TODO : make MyMath script

    /// <summary>
    /// Cast collider ray to end position 
    /// </summary>
    /// <param name="endPosWorld"></param>
    /// <param name="collider"></param>
    /// <returns> overshoot length (if hit)</returns>
    private float MyCheckCollisions2D(Collider collider, Vector2 posWorld, Vector2 dirWorld, float maxDistance)
    {
        Ray ray = new Ray(posWorld, dirWorld);
        Debug.DrawLine(posWorld, posWorld + dirWorld * maxDistance, Color.red);

        if (Physics.Raycast(ray, out RaycastHit hitInfo, maxDistance))
            return maxDistance - hitInfo.distance;

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


    private void OnCollisionEnter(Collision collision)
    {
        hasCollission |= true;
    }

    private void OnCollisionExit(Collision collision)
    {
        hasCollission = false;
    }
}
