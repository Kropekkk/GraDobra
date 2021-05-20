using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnpointy : MonoBehaviour
{
    //Odleglosc od postaci do spawnpointa w ktorej spawnuja sie moby
    public float spawnradar = 100f;
    //Odleglosc od postaci do spawnpointa w w ktorej zespawnowane moby znikaja
    public float niszczradar = 180f;

    //Pozycja spawnpointa
    public Transform Pozycja_spawnpointa;
    //Pozycja gracza
    public Transform Pozycja_gracza;
    //Odleglosc gracza od spawnpointa oraz odleglosci gracza od spawnpointa we wspolrzednych x i z
    public float odl_x,odl_z,odlegosc;
    //Czy na aktualnym spawnpoincie zespawnowano juz moba
    bool czyuzyty=false;

    //Rodzaj Potwora
    public GameObject Potwor;


    
    void Update()
    {
        odl_x = Pozycja_spawnpointa.transform.position.x - Pozycja_gracza.transform.position.x;
        odl_z = Pozycja_spawnpointa.transform.position.z - Pozycja_gracza.transform.position.z;
        odlegosc = Mathf.Sqrt((odl_x * odl_x) + (odl_z * odl_z));
        //Jesli odleglosc jest odpowiadnia i nie zespawnowano jeszcze moba to
;        if (odlegosc < spawnradar && czyuzyty == false)
        {
            czyuzyty = true;
            //Spawn moba
            StworzMoba();
            Debug.Log("Spawnuje");
        }
        //Jesli odleglosc jest odpowiednia dla znisczenia To Bot automatyczna sie niszczy
        if(odlegosc>niszczradar && czyuzyty)
        {
            czyuzyty = false;
            Debug.Log("Odblokowany");
        }
    }
    void StworzMoba()
    {
        Instantiate(Potwor,Pozycja_spawnpointa.position,transform.rotation);
    }
}
