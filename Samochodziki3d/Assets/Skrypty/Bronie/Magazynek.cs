using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Nowy Magazynek", menuName = "Magazynek")]
public class Magazynek : ScriptableObject
{
    public string Nazwa_magazynka;

    public string Przeznaczenie_magazynka;

    public int pojemnosc_magazynka;
    public int cena_magazynka;
}