using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MojaBron : MonoBehaviour
{
    public int damage;
    public int pojemnosc_magazynka;
    public int zasieg_broni=100;

    public Transform SpawnBroni;

    public Camera celownik;
    public Text amunicja_T;
    public ZaradzanieBotami boty;

    public float czas;
    public float zmiana_magazynka=2f;// dodac pozniej
    public int amunicja;

    [Header("GłownaBron")]
    public GameObject AktualnaBron;
    public GameObject SzkieletBroni;
    public GameObject MagazynekBroni;
    public GameObject LufaBroni;
    public ObslugaBroni obsluga_broni;
    public ObslugaSzkieletu obsluga_szkieletu;
    public Obslugamagazynka obsluga_magazynka;
    public ObslugaLufy obsluga_lufy;


    string nazwabroni;
    ZapisaywanieBroni Pamiec = new ZapisaywanieBroni();

    void Start()
    {
        nazwabroni = PlayerPrefs.GetString("AktualnaBron");
        PobierzBron();

        amunicja = PlayerPrefs.GetInt("MojeAmmo");

        amunicja_T.text = "Amunicja: " + amunicja;

    }


    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= czas && amunicja > 0)
        {  
            czas = Time.time + zmiana_magazynka / 10;
            Strzal();
        }
    }

    void Strzal()
    {
        amunicja = amunicja - 1;
        PlayerPrefs.SetInt("MojeAmmo", amunicja);
        amunicja_T.text = "Amunicja: " + amunicja;
        RaycastHit hit;
        if (Physics.Raycast(celownik.transform.position, celownik.transform.forward, out hit, zasieg_broni)) 
        {
            if (hit.transform.name == "Start")
            {
                boty.Rozpocznij();
            }
            Bot jaki = hit.transform.GetComponent<Bot>();
            if (jaki != null)
            {
                jaki.Zycie(damage);
            }
        }
    }
    void PobierzBron()
    {
        GameObject tymczasowabron = Instantiate(Resources.Load("Bronie/" + nazwabroni)) as GameObject;


        AktualnaBron = new GameObject(nazwabroni);
        AktualnaBron.transform.position = SpawnBroni.position;
        AktualnaBron.transform.rotation = SpawnBroni.rotation;
        AktualnaBron.transform.parent = SpawnBroni.transform;

        AktualnaBron.AddComponent<ObslugaBroni>();
        obsluga_broni = AktualnaBron.GetComponent<ObslugaBroni>();

        obsluga_broni.Szkielet = Instantiate(tymczasowabron.GetComponent<ObslugaBroni>().Szkielet, AktualnaBron.transform.position, AktualnaBron.transform.rotation);

        SzkieletBroni = obsluga_broni.Szkielet;
        SzkieletBroni.transform.parent = AktualnaBron.transform;
        obsluga_szkieletu = SzkieletBroni.GetComponent<ObslugaSzkieletu>();

        Pamiec.WczytajKolor(nazwabroni, "Szkielet");
        obsluga_szkieletu.kolorszkieltu = Pamiec.kolorbroni;
        obsluga_szkieletu.MojKolorSzkieletu();

        if (tymczasowabron.GetComponent<ObslugaBroni>().Magazynek != null)
        {
            MagazynekBroni = Instantiate(tymczasowabron.GetComponent<ObslugaBroni>().Magazynek, obsluga_szkieletu.Miejsce_Na_Magazynek.transform.position, obsluga_szkieletu.Miejsce_Na_Magazynek.transform.rotation);
            obsluga_broni.Magazynek = MagazynekBroni;
            MagazynekBroni.transform.parent = AktualnaBron.transform;
            obsluga_magazynka = MagazynekBroni.GetComponent<Obslugamagazynka>();
            Pamiec.WczytajKolor(nazwabroni, "Magazynek");
            obsluga_magazynka.kolormagazynka = Pamiec.kolorbroni;
            obsluga_magazynka.MojKolorMagazynka();
        }
        else
        {
            Debug.Log("Nie ma magazynka");
        }
        if(tymczasowabron.GetComponent<ObslugaBroni>().Lufa !=null)
        {
            LufaBroni = Instantiate(tymczasowabron.GetComponent<ObslugaBroni>().Lufa, obsluga_szkieletu.Miejsce_Na_Lufe.transform.position, obsluga_szkieletu.Miejsce_Na_Lufe.transform.rotation);
            obsluga_broni.Lufa = LufaBroni;
            LufaBroni.transform.parent = AktualnaBron.transform;
            obsluga_lufy = LufaBroni.GetComponent<ObslugaLufy>();

            //Pamiec.WczytajKolor(nazwabroni, "Magazynek");
            //obsluga_magazynka.kolormagazynka = Pamiec.kolorbroni;
            //obsluga_magazynka.MojKolorMagazynka();
        }
        else
        {
            Debug.Log("Nie ma lufy");
        }



        Destroy(tymczasowabron);
    }
}