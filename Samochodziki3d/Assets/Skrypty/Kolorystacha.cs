using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kolorystacha : MonoBehaviour
{
    public MeshRenderer stachu;
    public GameObject banany;
    float czas;
    public Transform spawn;

    void Start()
    {
        stachu.material.color = new Color(1f, 1f, 0f, 1f);
    }
    private void FixedUpdate()
    {
        if(Input.GetKey("n") && czas>1)
        {
            Instantiate(banany, spawn.position, spawn.rotation);
            czas = 0;
        }
        czas += Time.deltaTime;
    }

}
