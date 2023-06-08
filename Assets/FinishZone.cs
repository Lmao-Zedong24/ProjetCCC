using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishZone : MonoBehaviour
{
    public GameObject player;
    public CanvasJay Canva;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("MainBody"))
        {
            Canva.isRunning = false;
            Canva.Score.SetActive(true);
            Canva.Thanks.SetActive(true);
        }
    }
}
