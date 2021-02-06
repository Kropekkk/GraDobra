using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TworzenieBroni
{

    public GameObject SzkieletBroni,MagazynekBroni,LufaBroni;
    public ObslugaSzkieletu obsluga_szkieletu;
    public Obslugamagazynka obsluga_magazynka;
    public ObslugaLufy obsluga_lufy;

    public KupionaBron mojabron = new KupionaBron();

    public TworzenieBroni()
    {
        Debug.Log("test");
    }

    public void Pobierz(int id)
    {
        mojabron.Wczytaj(id);

        //mojabron.szkielet




    }
    public void Wczytaj(int id)
    {
        mojabron.Wczytaj(id);

        //mojabron.nazwabroni




    }
}