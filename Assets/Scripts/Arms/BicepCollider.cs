using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BicepCollider : MonoBehaviour
{
    Transform   _bottom;
    Transform   _top;
    HandCollider _hand;


    // Start is called before the first frame update
    void Awake()
    {
        _bottom =   transform.parent.parent; //arm
        _top =      transform.parent;        //hand
        _hand =     GetComponentInParent<HandCollider>();
        //Vector3 upwards = transform.parent.position - transform.parent.parent.position;
        //Vector3 forward = Quaternion.Euler(0, 0, -90f) * upwards;
        //transform.rotation = Quaternion.LookRotation(upwards);
    }

    // Update is called once per frame
    void Update()
    {
        var vec = (_top.position - _bottom.position);
        transform.position = _bottom.position + 0.5f * vec;
        float val = vec.magnitude * 2.1f;
        var newScale = transform.localScale;
        newScale.y = val;
        transform.localScale = newScale;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer != LayerMask.NameToLayer("Player"))
            _hand.DebugHand();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer != LayerMask.NameToLayer("Player"))
            _hand.DebugHand();
    }
}
