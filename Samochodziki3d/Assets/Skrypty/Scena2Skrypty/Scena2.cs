using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Scena2 : MonoBehaviour
{
    public MeshRenderer kolory_postaci,OkoL_postaci,OkoP_postaci,Broda_postaci,Kapelutek_postaci;
    private float R, G, B,A;
    public Text Wyswietl,MojeMonety,MojeAmmo,MojLevelBroni,ZmiennyLevel;
    int liczba = 0;
    public Kolor kolor_Postaci, kolor_Oczy_L, kolor_Oczy_P, kolor_Brody,kolor_Kapuletek;
    float obrot = 0;
    bool lewo = true;
    public GameObject Panel1, Panel2,Panel3;
    int pieniadze, amunicja, bron_level;
    public Slider Czerwony,Zielony,Niebieski;
    public GameObject ListaBroni;

    private void Start()
    {
        if(PlayerPrefs.GetInt("MojaBron")==0)
        {
            PlayerPrefs.SetInt("MojaBron", 1);
            PlayerPrefs.SetInt("MojeAmmo", 120);
            PlayerPrefs.SetInt("Pieniadze", 10);

        }
        WczytajKoloryPostaci();
        Postac_Zmien();
        Tekty();
    }
    private void FixedUpdate()
    {
        ObrotPostaci();
    }
    void Zmien_Kolor()
    {
        switch (liczba)
        {
            case 1:
                kolory_postaci.material.color = new Color(R, G, B, A);
                kolor_Postaci.R=R;
                kolor_Postaci.G=G;
                kolor_Postaci.B=B;
                PlayerPrefs.SetFloat("Kolor_R", R);
                PlayerPrefs.SetFloat("Kolor_G", G);
                PlayerPrefs.SetFloat("Kolor_B", B);
                break;
            case 2:
                OkoL_postaci.material.color = new Color(R, G, B, A);
                OkoP_postaci.material.color = new Color(R, G, B, A);
                kolor_Oczy_L.R = R;
                kolor_Oczy_L.G = G;
                kolor_Oczy_L.B = B;
                kolor_Oczy_P.R = R;
                kolor_Oczy_P.G = G;
                kolor_Oczy_P.B = B;
                PlayerPrefs.SetFloat("Kolor_R_Oczy", R);
                PlayerPrefs.SetFloat("Kolor_G_Oczy", G);
                PlayerPrefs.SetFloat("Kolor_B_Oczy", B);
                break;
            case 3:
                Broda_postaci.material.color = new Color(R, G, B, A);
                kolor_Brody.R = R;
                kolor_Brody.G = G;
                kolor_Brody.B = B;
                PlayerPrefs.SetFloat("Kolor_R_Broda", R);
                PlayerPrefs.SetFloat("Kolor_G_Broda", G);
                PlayerPrefs.SetFloat("Kolor_B_Broda", B);
                break;
            case 0:
                Kapelutek_postaci.material.color = new Color(R, G, B, A);
                kolor_Kapuletek.R = R;
                kolor_Kapuletek.R = G;
                kolor_Kapuletek.R = B;
                break;
        }
    }
    public void Kolor_R()
    {
        R = R + 0.05f;
        if(R>1)
        {
            R = 0;
        }
        Zmien_Kolor();
    }
    public void Kolor_G()
    {
        G = G + 0.05f;
        if (G > 1)
        {
            G = 0;
        }
        Zmien_Kolor();
    }
    public void Kolor_B()
    {
        B = B + 0.05f;
        if (B > 1)
        {
            B = 0;
        }
        Zmien_Kolor();
    }
    public void Postac_Zmien()
    {
        liczba += 1;
        switch (liczba)
        {
            case 1:
                Wyswietl.text = "Cialo";
                R = kolor_Postaci.R;
                G = kolor_Postaci.G;
                B = kolor_Postaci.B;
                A = kolor_Postaci.A;
                Czerwony.value = R;
                Zielony.value = G;
                Niebieski.value = B;
                break;
            case 2:
                Wyswietl.text = "Oczy";
                R = kolor_Oczy_L.R;
                G = kolor_Oczy_L.G;
                B = kolor_Oczy_L.B;
                A = kolor_Oczy_L.A;
                //R = kolor_Oczy_P.R;
                //G = kolor_Oczy_P.G;
                //B = kolor_Oczy_P.B;
                Czerwony.value = R;
                Zielony.value = G;
                Niebieski.value = B;
                break;
            case 3:
                Wyswietl.text = "Broda";
                R = kolor_Brody.R;
                G = kolor_Brody.G;
                B = kolor_Brody.B;
                A = kolor_Brody.A;
                Czerwony.value = R;
                Zielony.value = G;
                Niebieski.value = B;
                break;
            case 4:
                Wyswietl.text = "Kapelutek";
                R = kolor_Kapuletek.R;
                G = kolor_Kapuletek.R;
                B = kolor_Kapuletek.R;
                Czerwony.value = R;
                Zielony.value = G;
                Niebieski.value = B;
                liczba = 0;
                break;
        }
    }
    public void WczytajKoloryPostaci()
    {
        kolor_Postaci = new Kolor(PlayerPrefs.GetFloat("Kolor_R"), PlayerPrefs.GetFloat("Kolor_G"), PlayerPrefs.GetFloat("Kolor_B"));
        kolor_Oczy_L = new Kolor(PlayerPrefs.GetFloat("Kolor_R_Oczy"), PlayerPrefs.GetFloat("Kolor_G_Oczy"), PlayerPrefs.GetFloat("Kolor_B_Oczy"));
        kolor_Oczy_P = new Kolor(PlayerPrefs.GetFloat("Kolor_R_Oczy"), PlayerPrefs.GetFloat("Kolor_G_Oczy"), PlayerPrefs.GetFloat("Kolor_B_Oczy"));
        kolor_Brody = new Kolor(PlayerPrefs.GetFloat("Kolor_R_Broda"), PlayerPrefs.GetFloat("Kolor_G_Broda"), PlayerPrefs.GetFloat("Kolor_B_Broda"));
        kolory_postaci.material.color = new Color(kolor_Postaci.R,kolor_Postaci.G,kolor_Postaci.B,kolor_Postaci.A);
        OkoL_postaci.material.color = new Color(kolor_Oczy_L.R, kolor_Oczy_L.G, kolor_Oczy_L.B, kolor_Oczy_L.A);
        OkoP_postaci.material.color = new Color(kolor_Oczy_P.R, kolor_Oczy_P.G, kolor_Oczy_P.B, kolor_Oczy_P.A);
        Broda_postaci.material.color = new Color(kolor_Brody.R, kolor_Brody.G, kolor_Brody.B, kolor_Brody.A);
        amunicja = PlayerPrefs.GetInt("MojeAmmo");
        bron_level = PlayerPrefs.GetInt("MojaBron");
        pieniadze = PlayerPrefs.GetInt("Pieniadze");
        kolor_Kapuletek = new Kolor(0f, 0f, 1f);
    }
    void ObrotPostaci()
    {
        if (obrot < 90 && lewo)
        {
            obrot += 1f;
            transform.rotation = Quaternion.Euler(0f, obrot, 0f);
        }
        else
        {
            lewo = false;
            obrot -= 1f;
            if (obrot < -90f)
            {
                lewo = true;
            }
            transform.rotation = Quaternion.Euler(0f, obrot, 0f);
        }
    }
    public void Wyjdz()
    {
        Application.Quit();
    }
    public void Wystartuj()
    {
        SceneManager.LoadScene(1);
    }
    public void Sklep()
    {
        Panel1.SetActive(false);
        Panel2.SetActive(true);
        ListaBroni.SetActive(true);
        Tekty();
    }
    public void WrocZeSklepu()
    {
        Panel2.SetActive(false);
        Panel1.SetActive(true);
        ListaBroni.SetActive(false);
    }
    public void WlasciwySklep()
    {
        Panel1.SetActive(false);
        Panel3.SetActive(true);
    }
    public void WrocZWlasciwegoSklepu()
    {
        Panel1.SetActive(true);
        Panel3.SetActive(false);
    }
    public void KupBron()
    {
        if(pieniadze>50)
        {
            pieniadze = pieniadze - 50;
            bron_level = bron_level + 1;
        }
        Tekty();
    }
    public void KupAmmo()
    {
        if(pieniadze>5)
        {
            pieniadze = pieniadze - 5;
            amunicja = amunicja + 30;
        }
        Tekty();
    }
    void Tekty()
    {
        MojeMonety.text = "" + pieniadze;
        MojLevelBroni.text = "Moja Bron: " + bron_level;
        MojeAmmo.text = "Moje AMMO: " + amunicja ;
        ZmiennyLevel.text = "LVL:" + (bron_level + 1) + "za 50$";
        PlayerPrefs.SetInt("MojeAmmo", amunicja);
        PlayerPrefs.SetInt("MojaBron", bron_level);
        PlayerPrefs.SetInt("Pieniadze", pieniadze);
    }
    public void LiniaR(float k)
    {
        R = k;
        Zmien_Kolor();
    }
    public void LiniaG(float k)
    {
        G = k;
        Zmien_Kolor();
    }
    public void LiniaB(float k)
    {
        B = k;
        Zmien_Kolor();
    }
}