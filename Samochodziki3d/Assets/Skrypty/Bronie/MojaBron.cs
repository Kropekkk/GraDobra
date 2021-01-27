using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MojaBron : MonoBehaviour
{
    public int damage;
    public int pojemnosc_magazynka;
    public int zasieg_broni=100;

    public Lufa mojalufa;
    public Magazynek mojmagazynek;
    public SzkieletBroni mojszkielet;

    public ObslugaLufy lufa;
    public Obslugamagazynka magazynek;
    public ObslugaSzkieletu szkielet;


    public Transform spawnlufy;
    public Transform spawnmagazynka;
    

    public Transform SpawnBroni;
    public GameObject AktualnaBron;
    public GameObject AktualnySzkielet;
    public GameObject AktualnyMagazynek;
    public GameObject AktualnaLufa;

    public GameObject Bron;


    public Camera celownik;
    public Text amunicja_T;
    public ZaradzanieBotami boty;

    public float czas;
    public float zmiana_magazynka=2f;// dodac pozniej
    public int amunicja;

    public Bron mojabron;

    public ObslugaBroni tabron;

    string aktualnabron;

    void Start()
    {
        /*AktualnySzkielet = Instantiate(Resources.Load(mojabron.szkieletbroni), SpawnBroni.transform.position, SpawnBroni.transform.rotation) as GameObject;


        szkielet = AktualnySzkielet.GetComponent<ObslugaSzkieletu>();

        spawnmagazynka = szkielet.Miejsce_Na_Magazynek;

        spawnlufy = szkielet.Miejsce_Na_Lufe;

        AktualnyMagazynek = Instantiate(Resources.Load(mojabron.magazynek), spawnmagazynka.position, spawnmagazynka.rotation) as GameObject;

        AktualnaLufa = Instantiate(Resources.Load(mojabron.lufa), spawnlufy.position, spawnlufy.rotation) as GameObject;
        */

        aktualnabron = "Bronie/" + (PlayerPrefs.GetString("AktualnaBron"));

        AktualnaBron = Instantiate(Resources.Load(aktualnabron), SpawnBroni.transform.position, SpawnBroni.transform.rotation) as GameObject;
        tabron = AktualnaBron.GetComponent<ObslugaBroni>();

        tabron.transform.parent = transform;

        //AktualnySzkielet.transform.parent = transform;
        //AktualnyMagazynek.transform.parent = transform;
        //AktualnaLufa.transform.parent = transform;



            //mojszkielet = szkielet.GetComponent<SzkieletBroni>();
            //mojmagazynek = magazynek.GetComponent<Magazynek>();


        //magazynek = AktualnyMagazynek.GetComponent<Obslugamagazynka>();

        //damage = szkielet.damage_szkieletu;
        //pojemnosc_magazynka = magazynek.pojemnosc_magazynka;

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
}
