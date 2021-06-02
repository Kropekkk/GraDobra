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

    //
    float x, z;
    float skala;
    float kat;
    float Czas_animacji;

    int odleglosc_niszczenia_moba = 200;    //Wartosc dla kazdego moba
    //
    public Mob Moj_Mob;
    //Wartosci Rozne

    int Predkosc_Moba=20;
    int punkty_zycia;

    int Czas_animacji_jedzenia;
    int Czas_animacji_idle;
    int Czas_animacji_ruchu;

    float Wielkosc_minimalna_moba;
    float Wielkosc_maksymalna_moba;

    bool Mozliwosc_atakowania_innych;

    int Damage_zadawany_innym;

    void Start()
    {
        PobierzDane();
        Gracz = GameObject.Find("Postac");
        Wylosuj_Czynnosc();
    }
    void Update()
    {
        Oblicz_Pozycje();
        CzynnosciMoba();
    }
    void Wylosuj_Czynnosc()
    {
        Czas_animacji = Random.Range(1, Czas_animacji_idle + Czas_animacji_jedzenia + Czas_animacji_ruchu);
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
        Czas_animacji += Time.deltaTime;

        if (Czas_animacji > Czas_animacji_idle && Czas_animacji < Czas_animacji_idle+Czas_animacji_jedzenia)
        {
            Czy_jedzenie = true;
            Czy_ruch = false;
        }
        if (Czas_animacji >= Czas_animacji_idle + Czas_animacji_jedzenia)
        {
            Czy_jedzenie = false;
            Czy_ruch = true;

            Ruch_Moba();

            if (Czas_animacji > Czas_animacji_idle + Czas_animacji_jedzenia+Czas_animacji_ruchu)
            {
                Czy_jedzenie = false;
                Czy_ruch = false;
                Czas_animacji = 0;
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
    void PobierzDane()
    {
        Predkosc_Moba = Moj_Mob.Predkosc_Moba;
        punkty_zycia = Moj_Mob.punkty_zycia;
        Czas_animacji_jedzenia= Moj_Mob.Czas_animacji_jedzenia;
        Czas_animacji_idle = Moj_Mob.Czas_animacji_idle;
        Czas_animacji_ruchu = Moj_Mob.Czas_animacji_ruchu;

        Wielkosc_minimalna_moba = Moj_Mob.Wielkosc_minimalna_moba;
        Wielkosc_maksymalna_moba = Moj_Mob.Wielkosc_maksymalna_moba;

        Mozliwosc_atakowania_innych =Moj_Mob.Mozliwosc_atakowania_innych;

        Damage_zadawany_innym = Moj_Mob.Damage_zadawany_innym;
    }
    public void Damage(int damage)
    {
        punkty_zycia -= damage;
        if(punkty_zycia<=0)
        {
            Umieranie();
        }
    }
    void Umieranie()
    {
        Destroy(gameObject);
    }
}