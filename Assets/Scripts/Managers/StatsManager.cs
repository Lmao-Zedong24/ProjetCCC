using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class StatsManager : Singleton<StatsManager>
{
    @InputController    _inputs;
    GameObject          _player;
    PlayerController    _controller;
    Rigidbody           _mainBody;


    public int[] armExtendNum { get; private set; }
    public float highestFall { get; private set; }
    public float highestPointReached { get; private set; }
    public float startStopwatch { get; private set; }


    protected override void Awake()
    {
        base.Awake();

        armExtendNum = new int[3];

        _player ??= GameObject.FindGameObjectWithTag("MainBody");
        _controller = _player?.GetComponent<PlayerController>();
        _mainBody = _player.GetComponent<Rigidbody>();
        _inputs = new @InputController();



        StartCoroutine(HeightStatsRoutine());
        //StartCoroutine(StartStopwatchRoutine());
    }
    IEnumerator HeightStatsRoutine()
    {
        bool isFalling = false;
        float fallStartHeight = 0;

        while (_player)
        {
            if (_mainBody.velocity.y < -0.1f)
            {
                if (!isFalling)
                {
                    fallStartHeight = _mainBody.transform.position.y;
                    isFalling = true;

                    highestPointReached = fallStartHeight > highestPointReached? fallStartHeight : highestPointReached;

                    if (highestPointReached == fallStartHeight)
                    {
                        Debug.Log($"New heighest Point Reached:\t{highestPointReached}m");
                    }
                }
            }
            else if (isFalling) 
            {
                isFalling = false;
                float newFallHeignt = fallStartHeight - _mainBody.transform.position.y;

                if (newFallHeignt > highestFall)
                {
                    highestFall = newFallHeignt;
                    Debug.Log($"New heighest fall height:\t{highestFall}m");
                }
                else
                {
                    Debug.Log($"New fall height:\t{newFallHeignt}m");
                }
            }

            yield return null;
            //yield return new WaitForSeconds(0.1f);
        }
    }

    //IEnumerator StartStopwatchRoutine()
    //{
        //bool start = false;

        //while (!start)
        //{
        //    foreach (var arm in _controller._arms)
        //    {
        //        if (arm.armState == Arm.EArmState.Extend)
        //            start = true;
        //    }

        //    yield return null;
        //}

        //float waitSeconds = 0.1f;
        //var wait = new WaitForSeconds(waitSeconds);

        //while (start)
        //{
        //    startStopwatch += waitSeconds;

        //    if ((int)startStopwatch % 10 == 0)
        //    {
        //        Debug.Log($"Start stopwatch time :\t{startStopwatch}");
        //    }

        //    yield return wait;
        //}
    //}

    public void IncrementArm(int index)
    {
        if (index < 0 || index >= armExtendNum.Length)
            return;

        armExtendNum[index]++;
        Debug.Log($"Arm ({index + 1}) Extend Number:\t{armExtendNum[index]}");
    }
}
