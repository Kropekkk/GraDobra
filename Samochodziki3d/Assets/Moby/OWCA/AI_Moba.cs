using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Moba : MonoBehaviour
{
    public float odl_x, odl_y, odleglosc;
    public Transform Pozycja_Moba;
    public Transform Pozycja_Gracza;
    public GameObject Gracz;
    public Rigidbody Mob;

    public Animator Animacje_moba;

    bool Czy_jedzenie = false, Czy_ruch = false;

    bool Czy_wylosowane = false;
    int licznik;

    float x, z, Predkosc_Moba;
    float skala;
    float kat;

    int odleglosc_niszczenia_moba = 200;

    void Start()
    {
        Predkosc_Moba = 20;
        Gracz = GameObject.Find("Postac");
    }
    void Update()
    {
        Oblicz_Pozycje();
        CzynnosciMoba();
    }
    void Oblicz_Pozycje()
    {
        Pozycja_Gracza = Gracz.transform;
        odl_x = Pozycja_Moba.transform.position.x - Pozycja_Gracza.transform.position.x;
        odl_y = Pozycja_Moba.transform.position.z - Pozycja_Gracza.transform.position.z;
        odleglosc = Mathf.Sqrt((odl_x * odl_x) + (odl_y * odl_y));
        if (odleglosc > odleglosc_niszczenia_moba)
        {
            Destroy(gameObject);
        }
    }
    void CzynnosciMoba()
    {
        licznik += 1;

        if (licznik > 500 && licznik < 1000)
        {
            Czy_jedzenie = true;
            Czy_ruch = false;
        }
        if (licznik >= 1000)
        {
            Czy_jedzenie = false;
            Czy_ruch = true;

            Ruch_Moba();

            if (licznik > 3000)
            {
                Czy_jedzenie = false;
                Czy_ruch = false;
                licznik = 0;
                Czy_wylosowane = false;
            }
        }

        Animacje_moba.SetBool("Jedzenie", Czy_jedzenie);
        Animacje_moba.SetBool("Ruch", Czy_ruch);
    }
    void Ruch_Moba()
    {
        if (!Czy_wylosowane)
        {
            Wylosuj_Kierunek_Moba();
        }
        Mob.velocity = new Vector3(x / skala, Mob.velocity.y, z / skala);
    }
    void Wylosuj_Kierunek_Moba()
    {
        x = Random.Range(-10, 10);
        z = Random.Range(-10, 10);

        if (x == 0 && z == 0)
        {
            Wylosuj_Kierunek_Moba();
        }
        else
        {
            skala = (x * x + z * z) / Predkosc_Moba;

            Czy_wylosowane = true;

            Obroc_Moba();

        }
    }
    void Obroc_Moba()
    {
        kat = Mathf.Atan(Mathf.Abs(z / x)) * (180 / Mathf.PI);
        if (x <= 0)
        {
            if (z <= 0)
            {
                transform.rotation = Quaternion.Euler(0, 90 - kat, 0);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 90 + kat, 0);
            }
        }
        else
        {
            if (z <= 0)
            {
                transform.rotation = Quaternion.Euler(0, kat - 90, 0);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, -kat - 90, 0);
            }

        }
    }
}