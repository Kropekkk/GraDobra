using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Sklep : MonoBehaviour
{
    public List<GameObject> nowaLista;

    public GameObject zaznaczony;

    public Transform MiejsceBroni;
    public GameObject TaBron;

    public GameObject SzkieletBroni;
    public GameObject MagazyekBroni;
    public GameObject LufaBroni;

    public ObslugaSzkieletu obsluga_szkieletu;
    public Obslugamagazynka mag;
    public ObslugaLufy lufa;

    public ObslugaBroni mojabron;

    public KupionaBron zapisanabron = new KupionaBron();
    public List<Text> mojebronie;

    string nazwa_szkieletu, nazwa_magazynka, nazwa_lufy;

    public Text T_cena;
    int cena;
    int mojepieniadze;
    public Text T_mojepieniadze;
    string nazwa_spawnu;

    public void Start()
    {
        Policz();
        mojepieniadze = PlayerPrefs.GetInt("Pieniadze");
        T_mojepieniadze.text = "" + mojepieniadze;
    }
    void Update()   
    {
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray,out hit))
            {
                BoxCollider bc = hit.collider as BoxCollider;
                if(bc!=null)
                {
                    if(Resources.Load(bc.name) !=null)
                    {
                        nazwa_spawnu = bc.name;
                        zaznaczony = Instantiate(Resources.Load(bc.name)) as GameObject;                   
                        Wykonaj();
                        Nowa_Cena();
                    }
                }
            }
        }
    }
    void Wykonaj()
    {
        cena = 0;
        if (SzkieletBroni==null)
        {
            if(zaznaczony.GetComponent<ObslugaSzkieletu>())
            {
                SzkieletBroni = Instantiate(zaznaczony, MiejsceBroni.position, MiejsceBroni.rotation);
                TworzenieSzkieletu();   
            }
        }
        else
        {
            if(zaznaczony.GetComponent<ObslugaSzkieletu>())
            {
                if(nazwa_spawnu != obsluga_szkieletu.mojszkielet.Nazwa_szkieltu)
                {
                    UsunTaBron();
                    SzkieletBroni = Instantiate(zaznaczony, MiejsceBroni.position, MiejsceBroni.rotation);
                    TworzenieSzkieletu();
                }
            }
            if (zaznaczony.GetComponent<Obslugamagazynka>())
            {
                if (MagazyekBroni != null)
                {
                    Destroy(MagazyekBroni);
                }      
                MagazyekBroni = Instantiate(zaznaczony, obsluga_szkieletu.Miejsce_Na_Magazynek.position, obsluga_szkieletu.Miejsce_Na_Magazynek.rotation);
                TworzenieMagazynka();
            }

            if (zaznaczony.GetComponent<ObslugaLufy>())
            {
                if(LufaBroni==null)
                {
                    LufaBroni = Instantiate(zaznaczony, obsluga_szkieletu.Miejsce_Na_Lufe.position, obsluga_szkieletu.Miejsce_Na_Lufe.rotation);
                }
                else
                {
                    Destroy(LufaBroni);
                    LufaBroni = Instantiate(zaznaczony, obsluga_szkieletu.Miejsce_Na_Lufe.position, obsluga_szkieletu.Miejsce_Na_Lufe.rotation);  
                }
                TworzenieLufy();
            }
        }   
        Destroy(zaznaczony);
    }
    public void Zapisz()
    {
        if (SzkieletBroni != null)
        {
            mojepieniadze -= cena;
            PlayerPrefs.SetInt("Pieniadze", mojepieniadze);
            T_mojepieniadze.text = "" + mojepieniadze;
            zapisanabron.Zapisz(zapisanabron.zajety, "NowaBron", nazwa_szkieletu, nazwa_magazynka, nazwa_lufy);
        }
    }
    void Policz()
    {
        int k = 0;
        while (k<4)
        {
            zapisanabron.Wczytaj(k);
            if(zapisanabron.nazwabroni=="")
            {
                mojebronie[k].text = "Pusty Slot";
            }
            else
            {
                mojebronie[k].text = zapisanabron.nazwabroni;
            }
            k = k + 1;
        }
    }
    public void Slot1()
    {
        zapisanabron.zajety = 0;
        WczytajBron(zapisanabron.zajety);
    }
    public void Slot2()
    {
        zapisanabron.zajety = 1;
        WczytajBron(zapisanabron.zajety);
    }
    public void Slot3()
    {
        zapisanabron.zajety = 2;
        WczytajBron(zapisanabron.zajety);
    }
    public void Slot4()
    {
        zapisanabron.zajety = 3;
        WczytajBron(zapisanabron.zajety);
    }
    public void Wyjdz()
    {
        SceneManager.LoadScene(0);
    }
    void Nowa_Cena()
    {
        cena += obsluga_szkieletu.mojszkielet.cena_szkieletu;
        if (mag!=null)
        {
            cena += mag.mojmagazynek.cena_magazynka;
        }
        if(lufa!=null)
        {
            cena += lufa.mojalufa.cena_lufy;
        }
        T_cena.text = "Cena " + cena;
    }
    public void Usun()
    {
        zapisanabron.UsunDane(zapisanabron.zajety);
    }
    void WczytajBron(int id)
    {
        if(mojebronie[id].text != "Pusty Slot")
        {
            cena = 0;
            T_cena.text = "Cena " + cena;
            UsunTaBron();
            zapisanabron.Wczytaj(id);

            Debug.Log(zapisanabron.szkielet);
            SzkieletBroni = Instantiate(Resources.Load(zapisanabron.szkielet),MiejsceBroni.position,MiejsceBroni.rotation) as GameObject;
            TworzenieSzkieletu();         

            if(zapisanabron.magazynek!="")
            {
                MagazyekBroni = Instantiate(Resources.Load(zapisanabron.magazynek), obsluga_szkieletu.Miejsce_Na_Magazynek.position, obsluga_szkieletu.Miejsce_Na_Magazynek.rotation) as GameObject;
                TworzenieMagazynka();
            }
            if(zapisanabron.lufa!="")
            {
                LufaBroni = Instantiate(Resources.Load(zapisanabron.lufa), obsluga_szkieletu.Miejsce_Na_Lufe.position, obsluga_szkieletu.Miejsce_Na_Lufe.rotation) as GameObject;
                TworzenieLufy();
            }
        }
    }
    void UsunTaBron()
    {
        Destroy(SzkieletBroni);
        Destroy(MagazyekBroni);
        Destroy(LufaBroni);
        Destroy(obsluga_szkieletu);
        DestroyImmediate(mag);
        DestroyImmediate(lufa);
    }
    void TworzenieSzkieletu()
    {
        SzkieletBroni.transform.parent = MiejsceBroni.transform;
        obsluga_szkieletu = SzkieletBroni.GetComponent<ObslugaSzkieletu>();
        mojabron.Szkielet = SzkieletBroni;
        nazwa_szkieletu = obsluga_szkieletu.mojszkielet.Nazwa_szkieltu;
    }
    void TworzenieMagazynka()
    {
        MagazyekBroni.transform.parent = MiejsceBroni.transform;
        mag = MagazyekBroni.GetComponent<Obslugamagazynka>();
        mojabron.Magazynek = MagazyekBroni;
        nazwa_magazynka = mag.mojmagazynek.Nazwa_magazynka;
    }
    void TworzenieLufy()
    {
        LufaBroni.transform.parent = MiejsceBroni.transform;
        lufa = LufaBroni.GetComponent<ObslugaLufy>();
        mojabron.Lufa = LufaBroni;
        nazwa_lufy = lufa.mojalufa.Nazwa_Lufy;
    }
}