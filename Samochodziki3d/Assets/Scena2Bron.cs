using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class Scena2Bron : MonoBehaviour
{
    public WygladBroni bronwyglad;
    public Slider kolorR, kolorG, kolorB;
    public GameObject bronwidok;
    public Text Cozmieniam;

    public float R, G, B;
    int ktora_czesc = 0;

    string nazwa_broni = "BronPodstawowa";

    void Start()
    {
        bronwidok = Instantiate(Resources.Load(nazwa_broni), transform.position, transform.rotation) as GameObject;
        bronwidok.transform.parent = transform;
        bronwyglad = bronwidok.GetComponent<WygladBroni>();


        Zmien_Kolor();


    }

    void WlasciwyKolor()
    {
        switch(ktora_czesc)
        {
            case 1:
                bronwyglad.KolorBroni(R, G, B);
                break;
            case 0:
                bronwyglad.KolorMagazynka(R, G, B);
                break;
        }
    }

    public void Zmien_Kolor()
    {
        ktora_czesc += 1;
        switch(ktora_czesc)
        {
            case 1:
                Cozmieniam.text = "Bron";
                R= bronwyglad.kolorbroni.r;
                G = bronwyglad.kolorbroni.g;
                B = bronwyglad.kolorbroni.b;
                kolorR.value = R;
                kolorG.value = G;
                kolorB.value = B;
                break;
            case 2:
                Cozmieniam.text = "Magazynek";
                R = bronwyglad.kolormagazynka.r;
                G = bronwyglad.kolormagazynka.g;
                B = bronwyglad.kolormagazynka.b;
                kolorR.value = R;
                kolorG.value = G;
                kolorB.value = B;
                ktora_czesc = 0;
                break;
        }
        PrefabUtility.SaveAsPrefabAsset(bronwidok, "Assets/Resources/"+ nazwa_broni+".prefab");
    }
    public void Bron_R(float k)
    {
        R = k;
        WlasciwyKolor();
    }
    public void Bron_G(float k)
    {
        G = k;
        WlasciwyKolor();
    }
    public void Bron_B(float k)
    {
        B = k;
        WlasciwyKolor();
    }
}