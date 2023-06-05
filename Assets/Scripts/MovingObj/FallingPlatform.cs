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

    enum EMovingState
    {
        NONE,
        WAITING,
        GOING_UP,
        GOING_DOWN
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
        if ((_movingState == EMovingState.GOING_DOWN || _movingState == EMovingState.WAITING)
            && transform.position.y < _endPos.y)
        {
            _movingState = EMovingState.WAITING;
        }

        if (_movingState == EMovingState.GOING_DOWN)
        {
            transform.position -= new Vector3(0, Time.deltaTime * speedDown, 0);
        }

        if (_movingState == EMovingState.WAITING)
        {
            _timer -= Time.deltaTime;

            if (_timer <= 0f)
                TryMoveUp();
        }
    }
    
    void TryMoveUp()
    {
        if (_movingState == EMovingState.GOING_UP)
            return;

        if (_isCollisionPlayer)
        {
            _movingState = EMovingState.WAITING;
            return;
        }

        _timer = timerBackUpSeconds;
        _movingState = EMovingState.GOING_UP;
        StartCoroutine(MoveUpRoutine());
    }

    IEnumerator MoveUpRoutine()
    {
        while (transform.position.y <= _startPos.y && _movingState == EMovingState.GOING_UP)
        {
            transform.position += new Vector3(0, Time.deltaTime * speedUp, 0);
            yield return null;
        }

        _movingState = EMovingState.NONE;
        yield return null;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == _layerPlayer)
        {
            if (collision.transform.position.y < transform.position.y)
                return;

            _isCollisionPlayer = true;
            _movingState = EMovingState.GOING_DOWN;
            _timer = timerBackUpSeconds;
            return;
        }

        _movingState = EMovingState.WAITING;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.layer == _layerPlayer &&
            collision.transform.position.y > transform.position.y)
            _isCollisionPlayer = true;
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer == _layerPlayer &&
            collision.transform.position.y > transform.position.y)
        {
            _isCollisionPlayer = false;
            _movingState = EMovingState.WAITING;
        }
    }
}
