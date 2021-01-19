using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mojapostac
{
    int aktualnezycie;
    int maksymalnezycie;
    public Kolor kolor_Postaci, kolor_Oczy_L,kolor_Oczy_P,kolor_Brody;
    public int pienadze,mojeammo,mojabron;

    public Mojapostac()
    {
        kolor_Postaci = new Kolor(PlayerPrefs.GetFloat("Kolor_R"), PlayerPrefs.GetFloat("Kolor_G"), PlayerPrefs.GetFloat("Kolor_B"));
        kolor_Oczy_L= new Kolor(PlayerPrefs.GetFloat("Kolor_R_Oczy"), PlayerPrefs.GetFloat("Kolor_G_Oczy"), PlayerPrefs.GetFloat("Kolor_B_Oczy"));
        kolor_Oczy_P = new Kolor(PlayerPrefs.GetFloat("Kolor_R_Oczy"), PlayerPrefs.GetFloat("Kolor_G_Oczy"), PlayerPrefs.GetFloat("Kolor_B_Oczy"));
        kolor_Brody = new Kolor(PlayerPrefs.GetFloat("Kolor_R_Broda"), PlayerPrefs.GetFloat("Kolor_G_Broda"), PlayerPrefs.GetFloat("Kolor_B_Broda"));
        pienadze = PlayerPrefs.GetInt("Pieniadze");
        mojabron = PlayerPrefs.GetInt("MojaBron");
        mojeammo = PlayerPrefs.GetInt("MojeAmmo");
    }
}