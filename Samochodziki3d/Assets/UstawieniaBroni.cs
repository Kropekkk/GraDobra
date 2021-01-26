using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UstawieniaBroni : MonoBehaviour
{

    public GameObject tabron;

    public ObslugaBroni obsluga_broni;

    public GameObject magazynek_tejbroni;
    public GameObject szkielet_tejbroni;
    public GameObject lufa_tejbroni;

    public ObslugaSzkieletu obsluga_szkieletu;
    public Obslugamagazynka obsluga_magazynka;


    public float R, G, B;


    public Slider kolorR, kolorG, kolorB;
    public Text Cozmieniam;
    int ktora_czesc = 0;

    void Start()
    {
        tabron = Instantiate(Resources.Load("M16"), transform.position, transform.rotation) as GameObject;
        tabron.transform.parent = transform;

        obsluga_broni = tabron.GetComponent<ObslugaBroni>();

        szkielet_tejbroni = obsluga_broni.Szkielet;
        magazynek_tejbroni = obsluga_broni.Magazynek;
        lufa_tejbroni = obsluga_broni.Lufa;

        obsluga_szkieletu = szkielet_tejbroni.GetComponent<ObslugaSzkieletu>();
        obsluga_szkieletu.kolorszkieltu = new Color(0f, 0f, 1f);
        obsluga_szkieletu.MojKolorSzkieletu();

        obsluga_magazynka = magazynek_tejbroni.GetComponent<Obslugamagazynka>();
        obsluga_magazynka.kolormagazynka = new Color(0.5f, 1f, 0f);
        obsluga_magazynka.MojKolorMagazynka();


       Zmien_Kolor();

    }

    public void Zmien_Kolor()
    {
        ktora_czesc += 1;
        switch (ktora_czesc)
        {
            case 1:
                Cozmieniam.text = "Bron";
                R = obsluga_szkieletu.kolorszkieltu.r;
                G = obsluga_szkieletu.kolorszkieltu.g;
                B = obsluga_szkieletu.kolorszkieltu.b;
                kolorR.value = R;
                kolorG.value = G;
                kolorB.value = B;
                break;
            case 2:
                Cozmieniam.text = "Magazynek";
                R = obsluga_magazynka.kolormagazynka.r;
                G = obsluga_magazynka.kolormagazynka.g;
                B = obsluga_magazynka.kolormagazynka.b;
                kolorR.value = R;
                kolorG.value = G;
                kolorB.value = B;
                ktora_czesc = 0;
                break;
        }
    }
    void WlasciwyKolor()
    {
        switch (ktora_czesc)
        {
            case 1:
                
                obsluga_szkieletu.kolorszkieltu = new Color(R, G, B);
                obsluga_szkieletu.MojKolorSzkieletu();
                break;
            case 0:
                obsluga_magazynka.kolormagazynka = new Color(R, G, B);
                obsluga_magazynka.MojKolorMagazynka();
                break;
        }
    }

    public void Kolor_R(float k)
    {
        R = k;
        WlasciwyKolor();
    }
    public void Kolor_G(float k)
    {
        G = k;
        WlasciwyKolor();
    }
    public void Kolor_B(float k)
    {
        B = k;
        WlasciwyKolor();
    }
}