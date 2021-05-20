using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZapisaywanieBroni
{
    private float R,G,B;

    public Color kolorbroni;


    string kolorR, kolorG, kolorB;


    public void ZapiszKolor(float r, float g, float b,string nazwabroni,string czescbroni)
    {
        // idbroni

        kolorR = nazwabroni + czescbroni + "R";
        kolorG = nazwabroni + czescbroni + "G";
        kolorB = nazwabroni + czescbroni + "B";

        PlayerPrefs.SetFloat(kolorR, r);
        PlayerPrefs.SetFloat(kolorG, g);
        PlayerPrefs.SetFloat(kolorB, b);
    }
    public void WczytajKolor(string nazwabroni, string czescbroni)
    {
        kolorR = nazwabroni + czescbroni + "R";
        kolorG = nazwabroni + czescbroni + "G";
        kolorB = nazwabroni + czescbroni + "B";


        R = PlayerPrefs.GetFloat(kolorR);
        G = PlayerPrefs.GetFloat(kolorG);
        B = PlayerPrefs.GetFloat(kolorB);
        kolorbroni = new Color(R, G, B);
    }
}