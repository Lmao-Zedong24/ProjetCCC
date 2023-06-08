using UnityEngine;
using UnityEngine.InputSystem;

public class Spawners : MonoBehaviour
{
    // L'objet que le joueur va spawn dessus
    public GameObject spawn1;
    public GameObject spawn2;
    public GameObject spawn3;
    public GameObject spawn4;
    public GameObject spawn5;
    public GameObject spawn6;

    public GameObject   playerGameObject;
    public Rigidbody    rb;

    private RigidbodyConstraints oldConst;

    public void Start()
    {
        if (spawn1 == null)
            return;

        playerGameObject.transform.position = spawn1.transform.position;
        Quaternion newRotation = Quaternion.Euler(180f, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
        playerGameObject.transform.rotation = newRotation;
    }

    void OnSpawn1(InputValue value)
    {
        SpawnPlayer(spawn1.transform.position);
    }
    void OnSpawn2(InputValue value)
    {
        SpawnPlayer(spawn2.transform.position);
    }
    void OnSpawn3(InputValue value)
    {
        SpawnPlayer(spawn3.transform.position);
    }
    void OnSpawn4(InputValue value)
    {
        SpawnPlayer(spawn4.transform.position);
    }
    void OnSpawn5(InputValue value)
    {
        SpawnPlayer(spawn5.transform.position);
    }

    void OnSpawn6(InputValue value)
    {
        SpawnPlayer(spawn6.transform.position);
    }


    private void UnfreezeRotation()
    {
        // On réactive la rotation de l'objet
        rb.constraints = oldConst;
    }

    void SpawnPlayer(Vector3 spawnPos)
    {
        playerGameObject.transform.position = spawnPos;
        Quaternion newRotation = Quaternion.Euler(0, 0, 180f);
        playerGameObject.transform.rotation = newRotation;
        oldConst = rb.constraints;
        rb.velocity = new Vector3(0, 0, 0);
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        Invoke("UnfreezeRotation", 0.01f);
    }

}
