﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WygladBroni : MonoBehaviour
{
    public MeshRenderer magazynek;
    public MeshRenderer bron;

    [SerializeField]
    public Color kolorbroni;
    public Color kolormagazynka;

    public GameObject Wyglad_broni;
    public GameObject Wyglad_magazynka;

    public Bron mojabron;

    public int damage;
    public int pojemnoscmagazynka;

    public GameObject Miejsce_Na_Magazynek;


    public Obslugamagazynka testmag;


    void Start()
    {
        //kolor_R = 1f;
        //PrefabUtility.SaveAsPrefabAsset(gameObject,"Assets/Resources/Gracz23.prefab");
        //Instantiate(Resources.Load("Gracz23"), transform.position, transform.rotation)

        //Tworzenie materialu???
        KolorBroni(kolorbroni.r,kolorbroni.g,kolorbroni.b);
        KolorMagazynka(kolormagazynka.r, kolormagazynka.g, kolormagazynka.b);

        damage = mojabron.damage;
        pojemnoscmagazynka = mojabron.aktualny_magazynek.pojemnosc_magazynka;


        Miejsce_Na_Magazynek = Instantiate(Resources.Load(mojabron.aktualny_magazynek.Nazwa_magazynka),Miejsce_Na_Magazynek.transform.position, Miejsce_Na_Magazynek.transform.rotation) as GameObject;
        Miejsce_Na_Magazynek.transform.parent = transform;

        testmag = Miejsce_Na_Magazynek.GetComponent<Obslugamagazynka>();
        
    }
    public void KolorBroni(float r, float g, float b)
    {
        kolorbroni = new Color(r, g, b);
        bron.material.color = kolorbroni;
    }
    public void KolorMagazynka(float r, float g, float b)
    {
        kolormagazynka = new Color(r, g, b);
        magazynek.material.color = kolormagazynka;
    }




    public void WyjmijMagazynek()
    {
        Wyglad_magazynka.SetActive(false);
    }




    void Update()
    {
        if (Input.GetKey("k"))
        {
            Debug.Log("dziala");
        }
    }
    public void Strzalanim()
    {
        Debug.Log("gahahflo0");


    }
}
 