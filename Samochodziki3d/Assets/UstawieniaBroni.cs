using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UstawieniaBroni : MonoBehaviour
{   
    [Header("Miejsce Na Bronie")]
    public Transform[] wieszakinabronie;
    [Header("Bronie")]
    public GameObject[] listamoichbroni;

    public List<string> wszystkienazwy;


    int tymczasowyindex;
    public GameObject MojaReka;
    public GameObject BronWRece;

    ZapisaywanieBroni Pamiec = new ZapisaywanieBroni();

    public ObslugaSzkieletu obsluga_szkieletu;
    public Obslugamagazynka obsluga_magazynka;
    public ObslugaLufy obsluga_lufy;

    public float R, G, B;

    int ktora_czesc = 0;
    int liczba_broni;

    public Slider kolorR, kolorG, kolorB;
    public Text Cozmieniam;

    string aktualnabron;
    string nazwa_broni;
    public GameObject AkutalnaBron;
    public Text Takutalnabron;

    public KupionaBron mojebronie = new KupionaBron();

    void Start()
    {

        mojebronie.ZapisaneBronie();
        liczba_broni = mojebronie.lista.Count;
        Debug.Log(mojebronie.lista[0] + " " +mojebronie.lista[1]);
        ZamienListeBroni();     
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                BoxCollider bc = hit.collider as BoxCollider;
                if (bc != null)
                {
                    if(wszystkienazwy.Contains(bc.name))
                    {
                        tymczasowyindex = wszystkienazwy.IndexOf(bc.name);
                        DoRekiBron();
                    }
                }
            }
        }
    }
    public void Zmien_Kolor()
    {
        if(ktora_czesc==2)
        {
            ktora_czesc = 0;
        }
        ktora_czesc += 1;
        Ktoraczesc();
    }
    void WlasciwyKolor()
    {
        switch (ktora_czesc)
        {
            case 1:
                obsluga_szkieletu.kolorszkieltu = new Color(R, G, B);
                obsluga_szkieletu.MojKolorSzkieletu();
                Pamiec.ZapiszKolor(R,G,B,listamoichbroni[tymczasowyindex].name,"Szkielet");
                listamoichbroni[tymczasowyindex].GetComponent<ObslugaBroni>().Szkielet.GetComponent<ObslugaSzkieletu>().kolorszkieltu = new Color(R, G, B);
                listamoichbroni[tymczasowyindex].GetComponent<ObslugaBroni>().Szkielet.GetComponent<ObslugaSzkieletu>().MojKolorSzkieletu();
                break;
            case 2:
                obsluga_magazynka.kolormagazynka = new Color(R, G, B);
                obsluga_magazynka.MojKolorMagazynka();
                Pamiec.ZapiszKolor(R, G, B, listamoichbroni[tymczasowyindex].name, "Magazynek");
                listamoichbroni[tymczasowyindex].GetComponent<ObslugaBroni>().Magazynek.GetComponent<Obslugamagazynka>().kolormagazynka = new Color(R, G, B);
                listamoichbroni[tymczasowyindex].GetComponent<ObslugaBroni>().Magazynek.GetComponent<Obslugamagazynka>().MojKolorMagazynka();
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
    public void DoRekiBron()
    {
        if (MojaReka == null)
        {
            MojaReka = Instantiate(listamoichbroni[tymczasowyindex],transform.position,transform.rotation);
            MojaReka.transform.parent = transform;
            KoloryTejBroni();
            if(Cozmieniam.text=="")
            {
                Zmien_Kolor();
            }
        }
        else
        {
            Destroy(MojaReka);
            MojaReka = Instantiate(listamoichbroni[tymczasowyindex], transform.position, transform.rotation);
            MojaReka.transform.parent = transform;
            KoloryTejBroni();
            Ktoraczesc();
            WlasciwyKolor();
        }
        GlownaBron();
    }
    void GlownaBron()
    {
        AkutalnaBron.SetActive(true);
        nazwa_broni = PlayerPrefs.GetString("AktualnaBron");
        if(nazwa_broni == listamoichbroni[tymczasowyindex].name)
        {
            Takutalnabron.text = "Główna Broń";
        }
        else
        {
            Takutalnabron.text = "Ustaw Broń";
        }
    }
    public void UstawGłownaBron()
    {
        PlayerPrefs.SetString("AktualnaBron",listamoichbroni[tymczasowyindex].name);
        GlownaBron();
    }
    void Ktoraczesc()
    {
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
                break;
        }
    }
    void KoloryTejBroni()
    {
        obsluga_szkieletu = MojaReka.GetComponent<ObslugaBroni>().Szkielet.GetComponent<ObslugaSzkieletu>();
        obsluga_magazynka = MojaReka.GetComponent<ObslugaBroni>().Magazynek.GetComponent<Obslugamagazynka>();
    }
    void ZamienListeBroni()
    {
        int liczba_broni_do_pobrania = mojebronie.lista.Count;
        int i = 0;

        while (liczba_broni_do_pobrania > 0)
        {
            listamoichbroni[i] = new GameObject(mojebronie.lista[i]);
            listamoichbroni[i].transform.position = wieszakinabronie[i].transform.position;
            listamoichbroni[i].transform.rotation = wieszakinabronie[i].transform.rotation;
            listamoichbroni[i].transform.parent = wieszakinabronie[i].transform;

           

            mojebronie.Wczytaj(i);


            listamoichbroni[i].AddComponent<ObslugaBroni>();

            
            listamoichbroni[i].GetComponent<ObslugaBroni>().Szkielet = Instantiate(Resources.Load(mojebronie.szkielet), wieszakinabronie[i].transform.position, wieszakinabronie[i].transform.rotation) as GameObject;
            GameObject mojszkielet = listamoichbroni[i].GetComponent<ObslugaBroni>().Szkielet;
            mojszkielet.transform.parent = listamoichbroni[i].transform;

            ObslugaSzkieletu obsluga_szkieletu = mojszkielet.GetComponent<ObslugaSzkieletu>();

            Pamiec.WczytajKolor(mojebronie.lista[i], "Szkielet");
            obsluga_szkieletu.kolorszkieltu = Pamiec.kolorbroni;
            obsluga_szkieletu.MojKolorSzkieletu();

            if (mojebronie.magazynek != null)
            {
                GameObject mojmagazynek = Instantiate(Resources.Load(mojebronie.magazynek), obsluga_szkieletu.Miejsce_Na_Magazynek.transform.position, obsluga_szkieletu.Miejsce_Na_Magazynek.transform.rotation) as GameObject;
                mojmagazynek.transform.parent = listamoichbroni[i].transform;
                listamoichbroni[i].GetComponent<ObslugaBroni>().Magazynek = mojmagazynek;

                Obslugamagazynka obsluga_magazynka = mojmagazynek.GetComponent<Obslugamagazynka>();

                Pamiec.WczytajKolor(mojebronie.lista[i], "Magazynek");
                obsluga_magazynka.kolormagazynka = Pamiec.kolorbroni;
                obsluga_magazynka.MojKolorMagazynka();
            }
            else
            {
                Debug.Log("Nie ma Magazynka");
            }
            if (mojebronie.lufa != null)
            {
                GameObject mojalufa = Instantiate(Resources.Load(mojebronie.lufa), obsluga_szkieletu.Miejsce_Na_Lufe.transform.position, obsluga_szkieletu.Miejsce_Na_Lufe.transform.rotation) as GameObject;
                mojalufa.transform.parent = listamoichbroni[i].transform;
                listamoichbroni[i].GetComponent<ObslugaBroni>().Lufa = mojalufa;
            }
            else
            {
                Debug.Log("Nie ma Lufy");
            }
            listamoichbroni[i].AddComponent<BoxCollider>();
            wszystkienazwy.Add(listamoichbroni[i].name);

            //muszka i celownik do roboty

            i = i + 1;
            liczba_broni_do_pobrania = liczba_broni_do_pobrania - 1;
        }
    }
}