using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ruch : MonoBehaviour
{
    float x, z;
    public CharacterController gracz;
    
    public Transform Czydotyk;
    float odl = 0.4f;
    public LayerMask dotyk;
    Vector3 predkosc;
    public float skok = 3f;
    int zmien = 1;
    public MeshRenderer KolorPostaci,OkoL_postaci, OkoP_postaci, Broda_postaci;

    public GameObject Slot1, Slot2;

    bool czy;
    bool kursor = true;

    void Start()
    {
        PobierzMojaPostac();
    }

    void Update()
    {
        czy = Physics.CheckSphere(Czydotyk.position, odl, dotyk);

        if(czy && predkosc.y<0 )
        {
           // predkosc.y = -2f;
        }

        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");

        Vector3 ruch = transform.right * x + transform.forward * z;
        gracz.Move(ruch * 10f * Time.deltaTime);

        if(Input.GetButton("Jump") && czy)
        {
            predkosc.y = Mathf.Sqrt(skok * -2f * -9.81f);
        }
        
        predkosc.y += -9.81f * Time.deltaTime;
        gracz.Move(predkosc * Time.deltaTime);

        if(Input.GetKey("i"))
        {
            Cursor.lockState = CursorLockMode.None;
            Wyjdz();
        }
    }
    public void Wyjdz()
    {
        SceneManager.LoadScene(0);
    }
    void PobierzMojaPostac()
    {
        Mojapostac postac = new Mojapostac();
        KolorPostaci.material.color = new Color(postac.kolor_Postaci.R, postac.kolor_Postaci.G, postac.kolor_Postaci.B, postac.kolor_Postaci.A);
        OkoL_postaci.material.color = new Color(postac.kolor_Oczy_L.R, postac.kolor_Oczy_L.G, postac.kolor_Oczy_L.B, postac.kolor_Oczy_L.A);
        OkoP_postaci.material.color = new Color(postac.kolor_Oczy_P.R, postac.kolor_Oczy_P.G, postac.kolor_Oczy_P.B, postac.kolor_Oczy_P.A);
        Broda_postaci.material.color = new Color(postac.kolor_Brody.R,postac.kolor_Brody.G,postac.kolor_Brody.B,postac.kolor_Brody.A);
    }
}