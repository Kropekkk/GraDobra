using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Owca : MonoBehaviour
{
    public float odl_x,odl_y,odleglosc;
    public Transform Moja_pozycja;
    public Transform Pozycja_gracza;
    public GameObject Gracz;
    public Rigidbody owca;

    public Animator animacjeowcy;

    bool jedzenie = false, ruch = false;

    int licznik;
    float x, z, predkosc;
    bool wylosowane = false;
    float skala;
    float kat;

    void Start()
    {
        predkosc = 20;
        Gracz = GameObject.Find("Postac");
    }

    void Update()
    {
        Pozycja_gracza = Gracz.transform;
        odl_x = Moja_pozycja.transform.position.x - Pozycja_gracza.transform.position.x;
        odl_y = Moja_pozycja.transform.position.z - Pozycja_gracza.transform.position.z;
        odleglosc = Mathf.Sqrt((odl_x * odl_x) + (odl_y * odl_y));
        if (odleglosc>200)
        {
            Destroy(gameObject);     
        }

        //owca.velocity = new Vector3(1, owca.velocity.y,0);
        ZycieOwcy();
    }
    void ZycieOwcy()
    {

        licznik += 1;

        if(licznik>500 && licznik <1000)
        {
            jedzenie = true;
            ruch = false;
        }
        if(licznik>=1000)
        {
            jedzenie = false;
            ruch = true;

            Poruszaj();

            if(licznik>3000)
            {
                jedzenie = false;
                ruch = false;
                licznik = 0;
                wylosowane = false;
            }
        }

        animacjeowcy.SetBool("Jedzenie", jedzenie);
        animacjeowcy.SetBool("Ruch", ruch);

        
    }

    void Poruszaj()
    {
        if(!wylosowane)
        {
            Wylosuj();
        }

        owca.velocity = new Vector3(x/skala, owca.velocity.y, z/skala);
        

        
    }
    void Wylosuj()
    {
        x = Random.Range(-10, 10);
        z = Random.Range(-10, 10);


        skala = (x * x + z * z) / predkosc;
        
        wylosowane = true;

        //Gora z(-1) Dolz(1) Lewo x(1) PRawo x(-1)
        kat = Mathf.Tan(z/x)*180/Mathf.PI;
        transform.rotation = Quaternion.Euler(0, kat, 0);
        Debug.Log(kat + "x " + x + "z " + z);
        
    }
}
