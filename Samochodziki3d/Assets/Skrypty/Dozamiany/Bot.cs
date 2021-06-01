using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot : MonoBehaviour
{
    public float zycie;
    public float radar = 100f;
    public Transform Bot_pozycja;
    private Transform Gracz_pozycja;
    private float odl_x, odl_y;
    private float predkosc;
    private float odleglosc;
    private float skala, wektor_x, wektor_y;
    public Rigidbody bocik;
    bool widze;
    int PoziomZdenerwowania = 0;     //0=spokojny 1=zdenerwowany 2 = bardzozdenerowawany
    float stalaZdenerwowania = 50f;
    private GameObject szukanygracz;
    public MeshRenderer wyglad_bota;
    public ZaradzanieBotami mojprzywodca;
    private GameObject szukanyprzywodca;

    private void Start()
    {
        szukanyprzywodca = GameObject.Find("ZaradzanieBotem") ;
        mojprzywodca = szukanyprzywodca.GetComponent<ZaradzanieBotami>();
        InformacjeOBocie();
    }
    private void FixedUpdate()
    {
        Szukaj();
    }
    public void Zycie(float damage)
    {
        zycie -= damage;
        PoziomZdenerwowania = 1;
        Czujnosc();
        if (zycie <= 0f)
        {
            Niezyje();
        }
    }
    void Niezyje()
    {
        mojprzywodca.Jedenniezyje();
        Destroy(gameObject);
    }
    void Czujnosc()
    {
        radar = 100f + PoziomZdenerwowania * stalaZdenerwowania;
        Szukaj();
        if (widze)
        {
        }
        else
        {
            radar = 100f;
        }
    }
    void Szukaj()
    {
        szukanygracz = GameObject.Find("Gracz");
        Gracz_pozycja = szukanygracz.transform;
        odl_x = Bot_pozycja.transform.position.x - Gracz_pozycja.transform.position.x;
        odl_y = Bot_pozycja.transform.position.z - Gracz_pozycja.transform.position.z;
        odleglosc = Mathf.Sqrt((odl_x * odl_x) + (odl_y * odl_y));
        if (odleglosc < radar)
        {
            skala = odleglosc / predkosc;
            wektor_x = -odl_x / skala;
            wektor_y = -odl_y / skala;
            bocik.velocity = new Vector3(wektor_x, bocik.velocity.y, wektor_y);
            widze = true;
        }
        else
        {
            widze = false;
        }
    }
    void InformacjeOBocie()
    {
        TworzenieBota mojbot = new TworzenieBota();
        mojbot.NowyBot();
        predkosc = mojbot.szybkosc;
        Bot_pozycja.transform.localScale = mojbot.rozmiarybota;
        zycie = mojbot.zycie;
        wyglad_bota.material.color = new Color(mojbot.kolor_R, mojbot.kolor_G, mojbot.kolor_B, 1f);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.name == "KoniecGry")
        {
            mojprzywodca.Przegrana();
        }
    }
}
