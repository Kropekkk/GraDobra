using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UstawieniaBroni : MonoBehaviour
{
    public GameObject magazynek_tejbroni;
    public GameObject szkielet_tejbroni;
    public GameObject lufa_tejbroni;

    public ObslugaSzkieletu obsluga_szkieletu;
    public Obslugamagazynka obsluga_magazynka;
    public ObslugaLufy obsluga_lufy;

    public float R, G, B;

    public Slider kolorR, kolorG, kolorB;
    public Text Cozmieniam;
    int ktora_czesc = 0;

    string aktualnabron;

    public GameObject[] listabroni;
    public Transform[] spawnybroni;
    public List<GameObject> wlasciwalista;

    int jakas;
    int i = 0;

    ZapisaywanieBroni Pamiec;

    string nazwa_broni;

    void Start()
    {
        Pamiec = new ZapisaywanieBroni();
        listabroni = Resources.LoadAll<GameObject>("Bronie");
        nazwa_broni = PlayerPrefs.GetString("AktualnaBron");
        aktualnabron = "Bronie/" + nazwa_broni;

        jakas = listabroni.Length;
       while (jakas>0)
        {
            wlasciwalista.Add(Instantiate(listabroni[i], spawnybroni[i].transform.position, listabroni[i].transform.rotation) as GameObject);
            i += 1;
            jakas = jakas - 1;
            
        }


        Pobierz();
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
                Pamiec.ZapiszKolor(R,G,B,nazwa_broni,"Szkielet");
                break;
            case 0:
                obsluga_magazynka.kolormagazynka = new Color(R, G, B);
                obsluga_magazynka.MojKolorMagazynka();
                Pamiec.ZapiszKolor(R,G,B,nazwa_broni,"Magazynek");
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
    public void Pobierz()
    {

        if(nazwa_broni != "M16")
        {
            transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        }
        GameObject tymczasowabron = Instantiate(Resources.Load(aktualnabron), transform.position, transform.rotation) as GameObject;



        szkielet_tejbroni = Instantiate(tymczasowabron.GetComponent<ObslugaBroni>().Szkielet, transform.position, transform.rotation);
        magazynek_tejbroni = Instantiate(tymczasowabron.GetComponent<ObslugaBroni>().Magazynek, szkielet_tejbroni.GetComponent<ObslugaSzkieletu>().Miejsce_Na_Magazynek.transform.position, szkielet_tejbroni.GetComponent<ObslugaSzkieletu>().Miejsce_Na_Magazynek.transform.rotation);
        lufa_tejbroni = Instantiate(tymczasowabron.GetComponent<ObslugaBroni>().Lufa, szkielet_tejbroni.GetComponent<ObslugaSzkieletu>().Miejsce_Na_Lufe.transform.position, szkielet_tejbroni.GetComponent<ObslugaSzkieletu>().Miejsce_Na_Lufe.transform.rotation);


        lufa_tejbroni.transform.parent = transform;
        szkielet_tejbroni.transform.parent = transform;
        magazynek_tejbroni.transform.parent = transform;

        obsluga_szkieletu = szkielet_tejbroni.GetComponent<ObslugaSzkieletu>();
        obsluga_magazynka = magazynek_tejbroni.GetComponent<Obslugamagazynka>();
        obsluga_lufy = lufa_tejbroni.GetComponent<ObslugaLufy>();


        Pamiec.WczytajKolor(nazwa_broni, "Szkielet");
        obsluga_szkieletu.kolorszkieltu = Pamiec.kolorbroni;
        obsluga_szkieletu.MojKolorSzkieletu();
        Pamiec.WczytajKolor(nazwa_broni, "Magazynek");
        obsluga_magazynka.kolormagazynka = Pamiec.kolorbroni;
        obsluga_magazynka.MojKolorMagazynka();


        Destroy(tymczasowabron);

    }
}