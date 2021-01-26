using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obslugamagazynka : MonoBehaviour
{
    public Color kolormagazynka;
    public MeshRenderer wygladmagazynka;
    public Magazynek mojmagazynek;

    public int pojemnosc_magazynka;

    public void Awake()
    {
        pojemnosc_magazynka = mojmagazynek.pojemnosc_magazynka;
    }
    public void MojKolorMagazynka()
    {
        //wygladmagazynka.material.color = kolormagazynka;
        wygladmagazynka.sharedMaterial.color = kolormagazynka;
    }
}