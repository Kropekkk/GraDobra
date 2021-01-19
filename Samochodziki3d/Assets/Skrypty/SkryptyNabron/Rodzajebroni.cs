using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rodzajebroni
{
    public string nazwa;
    public float damage;
    public float zasieg;
    public int pojemnoscmagazynka;
    public int amunicja;

    public Rodzajebroni(string N)
    {
        nazwa = N;
        damage = 5;
        zasieg = 100f;
        pojemnoscmagazynka = 30;
        amunicja = PlayerPrefs.GetInt("MojeAmmo");
    }
}
