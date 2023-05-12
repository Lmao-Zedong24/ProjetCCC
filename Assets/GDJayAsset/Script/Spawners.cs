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

    public GameObject playerGameObject;
    public Rigidbody rb;

    private RigidbodyConstraints oldConst;

    public void Start()
    {
        playerGameObject.transform.position = spawn1.transform.position;
        Quaternion newRotation = Quaternion.Euler(180f, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
        playerGameObject.transform.rotation = newRotation;
    }

    void OnSpawn1(InputValue value)
    {
        playerGameObject.transform.position = spawn1.transform.position;
        Quaternion newRotation = Quaternion.Euler(180f, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
        playerGameObject.transform.rotation = newRotation;
        oldConst = rb.constraints;
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        Invoke("UnfreezeRotation", 0.01f);
    }
    void OnSpawn2(InputValue value)
    {
        playerGameObject.transform.position = spawn2.transform.position;
        Quaternion newRotation = Quaternion.Euler(180f, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
        playerGameObject.transform.rotation = newRotation;
        oldConst = rb.constraints;
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        Invoke("UnfreezeRotation", 0.01f);
    }
    void OnSpawn3(InputValue value)
    {
        playerGameObject.transform.position = spawn3.transform.position;
        Quaternion newRotation = Quaternion.Euler(180f, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
        playerGameObject.transform.rotation = newRotation;
        oldConst = rb.constraints;
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        Invoke("UnfreezeRotation", 0.01f);
    }
    void OnSpawn4(InputValue value)
    {
        playerGameObject.transform.position = spawn4.transform.position;
        Quaternion newRotation = Quaternion.Euler(180f, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
        playerGameObject.transform.rotation = newRotation;
        oldConst = rb.constraints;
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        Invoke("UnfreezeRotation", 0.01f);
    }
    void OnSpawn5(InputValue value)
    {
        playerGameObject.transform.position = spawn5.transform.position;
        Quaternion newRotation = Quaternion.Euler(180f, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
        playerGameObject.transform.rotation = newRotation;
        oldConst = rb.constraints;
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        Invoke("UnfreezeRotation", 0.01f);
    }

    void OnSpawn6(InputValue value)
    {
        playerGameObject.transform.position = spawn6.transform.position;
        Quaternion newRotation = Quaternion.Euler(180f, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
        playerGameObject.transform.rotation = newRotation;
        oldConst = rb.constraints;
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        Invoke("UnfreezeRotation", 0.01f);
    }


    private void UnfreezeRotation()
    {
        // On réactive la rotation de l'objet
        rb.constraints = oldConst;
    }

}
