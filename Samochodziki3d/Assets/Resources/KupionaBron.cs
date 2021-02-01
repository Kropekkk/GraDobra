using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KupionaBron
{
    public string nazwabroni;
    public string szkielet;
    public string magazynek;
    public string lufa;
    public List<string> lista = new List<string>();
    public int zajety;
    

    public void Zapisz(int id,string nazwa,string sz, string ma, string lu)
    {
        PlayerPrefs.SetString("NazwaBroni"+id, nazwa+id);
        PlayerPrefs.SetString("NazwaSzkieletu"+id, sz);
        PlayerPrefs.SetString("NazwaMagazynka"+id, ma);
        PlayerPrefs.SetString("NazwaLufy"+id, lu);
        Debug.Log(PlayerPrefs.GetString("NazwaBroni" + id));
    }
    public void Wczytaj(int id)
    {
        nazwabroni = PlayerPrefs.GetString("NazwaBroni"+id);
        szkielet = PlayerPrefs.GetString("NazwaSzkieletu"+id);
        magazynek = PlayerPrefs.GetString("NazwaMagazynka" + id);
        lufa = PlayerPrefs.GetString("NazwaLufy" + id);
       
    }
    public void ZapisaneBronie()
    {
        int i = 0;

        while (i<10)
        {
            if (PlayerPrefs.GetString("NazwaBroni"+i) != "")
            {
                lista.Add(PlayerPrefs.GetString("NazwaBroni"+i));
                i = i + 1;
            }
            else
            {
                i = 11;
                Debug.Log("Nie ma zadnego");
            }
        }
    }
    public void SprawdzCzyZajete()
    {
        int licz = 0;
        while (licz< 2)//2 to sloty
        {
            if (PlayerPrefs.GetString("NazwaBroni" + licz) != "")
            {
                licz += 1;
            }
            else
            {
                zajety = licz;
                licz = 3;
            }
        }
    }
}