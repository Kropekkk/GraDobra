using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TworzenieBota
{ 
    public float zycie;
    private float wysokosc, szerokosc, dlugosc;
    public int szybkosc;
    public Vector3 rozmiarybota;

    private int skala=10;
    float los;
    public float kolor_R, kolor_G, kolor_B;

    public void NowyBot()
    {
        los=Random.RandomRange(2f,6f);
        if(los>=4)
        {
            SzybkiBot();
        }
        if(los<4)
        {
            GrubyBot();
        }
        
    }
    void SzybkiBot()
    {
        szerokosc = Random.RandomRange(0.5f, 1f);
        dlugosc = szerokosc;
        wysokosc = (dlugosc + szerokosc);
        zycie = 20f;
        szybkosc = 15;
        rozmiarybota = new Vector3(szerokosc, wysokosc, dlugosc);

        kolor_R = 1f;
        kolor_G = 0f;
        kolor_B = 0f;
    }
    void GrubyBot()
    {
        szerokosc = Random.RandomRange(2f, 4f);
        dlugosc = szerokosc;
        wysokosc = skala / (dlugosc * szerokosc);
        zycie = 100f;
        szybkosc = 3;
        rozmiarybota = new Vector3(szerokosc, wysokosc, dlugosc);

        kolor_R = 0F;
        kolor_G = 1F;
        kolor_B = 0f;
    }
}
