using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bananpredkosc : MonoBehaviour
{
    Rigidbody mojapostac;

    void Start()
    {
        mojapostac = GetComponent<Rigidbody>();
    }

    void Update()
    {
        mojapostac.velocity = new Vector3(1, 1, 1);
    }
}
