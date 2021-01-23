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

    string nazwa_broni = "BronM16";
    //string nazwa_broni = "BronAk47";

    [Header("Lista Broni")]
    public List<Transform> halo1;
    [Header("Bronie")]
    public List<GameObject> bronie;
    [Header("Inne")]
    public int co1;
    public int co2;

    void Start()
    {
        bronwidok = Instantiate(Resources.Load(nazwa_broni), transform.position, transform.rotation) as GameObject;
        bronwidok.transform.parent = transform;
        bronwyglad = bronwidok.GetComponent<WygladBroni>();


        Zmien_Kolor();

        Moja_Lista_Broni();
    }
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray,out hit))
            {
                Sprawdz(hit.transform.name);
            }
        }
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
    void Moja_Lista_Broni()
    {
        /*int i = 2;
        while (i>0)
        {
            Instantiate(Resources.Load(nazwa_broni), halo1[i-1].transform.position, halo1[i-1].transform.rotation);
            
            i = i - 1;
        }*/

        bronie[0] = Instantiate(Resources.Load(nazwa_broni), halo1[0].transform.position, halo1[0].transform.rotation) as GameObject;
        bronie[1] = Instantiate(Resources.Load("BronAk47"), halo1[1].transform.position, halo1[1].transform.rotation) as GameObject;

        bronie[0].transform.parent = halo1[0].transform;
        bronie[1].transform.parent = halo1[1].transform;

        BoxCollider halocol = bronie[0].AddComponent<BoxCollider>();
        halocol.size = new Vector3(10,5,1);

        BoxCollider halocol1 = bronie[1].AddComponent<BoxCollider>();
        halocol1.size = new Vector3(10, 5, 1);
    }

    /*void Zapisz_Liste_Moich_Broni()
    {
        PlayerPrefs.SetInt("IleMamBroni", 1);

    }*/
    void Sprawdz(string nazwa)
    {
        if(nazwa=="BronAk47(Clone)")
        {
            Destroy(bronwidok);
            bronwidok = Instantiate(Resources.Load("BronAk47"), transform.position, transform.rotation) as GameObject;
            bronwidok.transform.parent = transform;
            bronwyglad = bronwidok.GetComponent<WygladBroni>();
        }
    }
}