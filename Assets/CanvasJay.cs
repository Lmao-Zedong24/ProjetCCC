using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class CanvasJay : MonoBehaviour
{
    public List<GameObject> _isPressedUI;
    public List<GameObject> _notPressedUI;
    public GameObject GameNoun;
    public GameObject ToplayPress;
    public GameObject Score;
    public GameObject Thanks;

    public TextMeshProUGUI textMesh;

    private bool IsalreadyStarted = false;
    private bool ChronoCanStart = false;
    private float startTime;
    public bool isRunning;
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

    public void Update()
    {
        if(ChronoCanStart == true && IsalreadyStarted == false)
        {
            StartChronometer();
            IsalreadyStarted = true;
            ChronoCanStart = false;
        }
    }

    public void SetArmInputKey(int index, string message)
    {
        _isPressedUI[index].GetComponentInChildren<TMP_Text>().text = message;
        _notPressedUI[index].GetComponentInChildren<TMP_Text>().text = message;
    }

    void OnOnArm1(InputValue value)
    {
        _isPressedUI[0].SetActive(true);
        _notPressedUI[0].SetActive(false);
        ChronoCanStart = true;
    }

    void OnOffArm1(InputValue value)
    {
        _isPressedUI[0].SetActive(false);
        _notPressedUI[0].SetActive(true);
        ToplayPress.SetActive(false);
        GameNoun.SetActive(false);
    }

    void OnOnArm2(InputValue value)
    {
        _isPressedUI[1].SetActive(true);
        _notPressedUI[1].SetActive(false);
        ChronoCanStart = true;
    }

    void OnOffArm2(InputValue value)
    {
        _isPressedUI[1].SetActive(false);
        _notPressedUI[1].SetActive(true);
        ToplayPress.SetActive(false);
        GameNoun.SetActive(false);
    }

    void OnOnArm3(InputValue value)
    {
        _isPressedUI[2].SetActive(true);
        _notPressedUI[2].SetActive(false);
        ChronoCanStart = true;
    }

    void OnOffArm3(InputValue value)
    {
        _isPressedUI[2].SetActive(false);
        _notPressedUI[2].SetActive(true);
        ToplayPress.SetActive(false);
        GameNoun.SetActive(false);
    }

    private void StartChronometer()
    {
        startTime = Time.time;
        isRunning = true;
        Debug.Log("Chronometer started!");
    }

    private void UpdateTextMesh()
    {
        if (isRunning)
        {
            float currentTime = Time.time - startTime;
            string formattedTime = FormatTime(currentTime);
            textMesh.text = "Time: " + formattedTime;
        }
    }

    private string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60f);
        int seconds = Mathf.FloorToInt(time % 60f);
        int milliseconds = Mathf.FloorToInt((time * 1000f) % 1000f);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private void LateUpdate()
    {
        UpdateTextMesh();
    }
}
