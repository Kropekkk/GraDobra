using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kamera : MonoBehaviour
{
    public float sensivity = 100f;
    public Transform postac;
    float xRot = 0f;
    public Transform MojaBron;


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        float mX = Input.GetAxis("Mouse X") * sensivity * Time.deltaTime;
        float mY = Input.GetAxis("Mouse Y") * sensivity * Time.deltaTime;
        xRot -= mY;
        xRot = Mathf.Clamp(xRot, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);
        postac.Rotate(Vector3.up * mX);
        MojaBron.localRotation = Quaternion.Euler(xRot, 0f, 0f);      
    }
}