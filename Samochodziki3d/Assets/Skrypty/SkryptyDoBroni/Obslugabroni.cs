using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class Obslugabroni : MonoBehaviour
{
    public Camera mojwidok;
    public Text amunicja_T;
    public ZaradzanieBotami boty;
    int zasieg = 100;

    string nazwabroni = "BronM16";

    public WygladBroni wyglad_broni;

    public Transform spawn_broni;
    int amunicja;

    float czas = 0f;

    public float coile = 2f;

    public Bron mojabron;

    void Start()
    {
        GameObject bron = Instantiate(Resources.Load(nazwabroni), spawn_broni.transform.position,spawn_broni.transform.rotation) as GameObject;
        bron.transform.parent = GameObject.Find("Slot1").transform;

        wyglad_broni = bron.GetComponent<WygladBroni>();


        Debug.Log(wyglad_broni.damage);

        amunicja = PlayerPrefs.GetInt("MojeAmmo");

        amunicja_T.text = "Amunicja: " + amunicja;

        

        //PrefabUtility.SaveAsPrefabAsset(brontera, "Assets/Resources/Gracz.prefab");
        //GameObject aktualnabron = Instantiate(Resources.Load("Gracz.prefab"),transform.position,transform.rotation) as GameObject;

    }
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= czas && amunicja > 0)
        {
            czas = Time.time + coile / 10;
            Strzal();
            Debug.Log(wyglad_broni.damage);
        }
        if(Input.GetKey("r"))
        {
            Zmiana_magazynka();
        }
    }
    void Strzal()
    {
        amunicja = amunicja - 1;
        PlayerPrefs.SetInt("MojeAmmo", amunicja);
        amunicja_T.text = "Amunicja: " + amunicja;
        RaycastHit hit;
        if (Physics.Raycast(mojwidok.transform.position, mojwidok.transform.forward, out hit, zasieg));
        {
            if (hit.transform.name == "Start")
            {
                boty.Rozpocznij();
            }
            Bot jaki = hit.transform.GetComponent<Bot>();
            if (jaki != null)
            {
                jaki.Zycie(wyglad_broni.damage);
            }
        }

    }
    void Zmiana_magazynka()
    {

    }
}