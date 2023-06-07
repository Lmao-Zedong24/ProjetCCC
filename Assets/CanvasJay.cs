using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CanvasJay : MonoBehaviour
{
    public List<GameObject> _isPressedUI;
    public List<GameObject> _notPressedUI;
    private void Awake()
    {
        _isPressedUI = new List<GameObject>();
        _notPressedUI = new List<GameObject>();

        foreach (Transform transform in GetComponentInChildren<Transform>())
        {
            if (transform.CompareTag("IsPressedUI"))
            {
                _isPressedUI.Add(transform.gameObject);
            }

            if (transform.CompareTag("NotPressedUI"))
            {
                _notPressedUI.Add(transform.gameObject);
            }
        }
    }

    void OnOnArm1(InputValue value)
    {
        _isPressedUI[0].SetActive(true);
        _notPressedUI[0].SetActive(false);
    }

    void OnOffArm1(InputValue value)
    {
        _isPressedUI[0].SetActive(false);
        _notPressedUI[0].SetActive(true);
    }

    void OnOnArm2(InputValue value)
    {
        _isPressedUI[1].SetActive(true);
        _notPressedUI[1].SetActive(false);
    }

    void OnOffArm2(InputValue value)
    {
        _isPressedUI[1].SetActive(false);
        _notPressedUI[1].SetActive(true);
    }

    void OnOnArm3(InputValue value)
    {
        _isPressedUI[2].SetActive(true);
        _notPressedUI[2].SetActive(false);
    }

    void OnOffArm3(InputValue value)
    {
        _isPressedUI[2].SetActive(false);
        _notPressedUI[2].SetActive(true);
    }
}
