using Cinemachine.Utility;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class FallingPlatform : MonoBehaviour
{
    [SerializeField] public float distaceBeforeStop = 5;
    [SerializeField] public float speedUp = 5;
    [SerializeField] public float speedDown = 2;
    [SerializeField] public float timerBackUpSeconds = 3;

    int         _layerPlayer;
    Vector3     _startPos;
    Vector3     _endPos;
    float       _timer;

    EMovingState    _movingState;
    bool            _isCollisionPlayer;
    bool            _isWaiting;
    bool            _hasOtherCollision;

    enum EMovingState
    {
        NONE,
        GOING_UP,
        GOING_DOWN,
    }


    private void Awake()
    {
        _startPos = transform.position;
        _endPos = _startPos - new Vector3(0, distaceBeforeStop, 0);
        _layerPlayer = LayerMask.NameToLayer("Player");
        _movingState = EMovingState.NONE;
        _timer = timerBackUpSeconds;
    }

    private void FixedUpdate()
    {
        if ((_movingState == EMovingState.GOING_DOWN)
            && transform.position.y <= _endPos.y)
        {
            _isWaiting = true;
            _movingState = EMovingState.NONE;
        }

        if (_isWaiting)
        {
            _timer -= Time.deltaTime;

            if (_timer <= 0f)
                TryMoveUp();
        }

        if (_hasOtherCollision)
            return;

        if ((_movingState == EMovingState.GOING_UP &&   transform.position.y <= _startPos.y) ||
            (_movingState == EMovingState.GOING_DOWN && transform.position.y >= _endPos.y))
        {
            float speed = _movingState == EMovingState.GOING_UP ? speedUp : -speedDown;
            transform.position += new Vector3(0, Time.deltaTime * speed, 0);
        }
    }
    
    void TryMoveUp()
    {
        if (_movingState == EMovingState.GOING_UP)
            return;

        _isWaiting = false;

        if (_isCollisionPlayer)
        {
            _movingState = EMovingState.GOING_DOWN;
            return;
        }

        _hasOtherCollision = false;
        _timer = timerBackUpSeconds;
        _movingState = EMovingState.GOING_UP;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.layer != _layerPlayer)
            _hasOtherCollision = true;
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.layer != _layerPlayer)
            _hasOtherCollision = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == _layerPlayer)
        {
            if (collision.transform.position.y < transform.position.y)
                return;

            _isCollisionPlayer = true;
            _isWaiting = false;
            _movingState = EMovingState.GOING_DOWN;
            return;
        }

        _movingState = EMovingState.NONE;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.layer == _layerPlayer &&
            collision.transform.position.y > transform.position.y)
        {
            _isCollisionPlayer = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer == _layerPlayer)
        {
            _isCollisionPlayer = false;
            _isWaiting = true;
            _timer = timerBackUpSeconds;

            //_movingState = EMovingState.NONE;
        }
    }
}
