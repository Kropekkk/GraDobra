using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magazynek
{
    public int PojemnoscMagazynka;
    public int Jakienaboje;
    public string Przeznaczeniemagazynka;
    public int nabojewmagazynku;

    public void PodstawowyMagazynek()
    {
        PojemnoscMagazynka = 10;
        //WygladMagazynka
        Jakienaboje = 5;
        Przeznaczeniemagazynka = "Pistolet";
    }
    public void ZaladujKule(float JakaKula, int ilekul)
    {
        if(JakaKula==Jakienaboje)
        {
            Debug.Log("LADUJE");
            nabojewmagazynku += ilekul;
        }
        else
        {
            Debug.Log("Kule nie do tej tego bagazynka");
        }
    }
}
