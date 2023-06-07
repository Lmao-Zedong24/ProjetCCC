using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsManager : Singleton<StatsManager>
{
    GameObject _player;
    Rigidbody _mainBody;


    public int[] armExtendNum { get; private set; }
    public float highestFall { get; private set; }
    public float highestPointReached { get; private set; }


    protected override void Awake()
    {
        base.Awake();

        armExtendNum = new int[3];

        _player ??= GameObject.FindGameObjectWithTag("MainBody");
        _mainBody = _player.GetComponent<Rigidbody>();


        StartCoroutine(heightStatsRoutine());

    }
    IEnumerator heightStatsRoutine()
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
                    Debug.Log($"New heighest fall:\t{highestFall}m");
                }
                else
                {
                    Debug.Log($"New fall:\t{newFallHeignt}m");
                }
            }

            yield return null;
            //yield return new WaitForSeconds(0.1f);
        }
    }

    public void IncrementArm(int index)
    {
        if (index < 0 || index >= armExtendNum.Length)
            return;

        armExtendNum[index]++;
        Debug.Log($"Arm ({index + 1}) Extend Number:\t{armExtendNum[index]}");
    }
}
