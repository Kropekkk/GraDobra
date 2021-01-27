using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Nowy Szkielet", menuName = "Szkielet")]
public class SzkieletBroni : ScriptableObject
{
    public string Nazwa_szkieltu;
    public string JakiMagazynekPasuje;
    public int PredkoscWystrzalu;
    public int Zasieg;
    public int damage;
    public GameObject bron;
    public Transform MiejsceNaLufe;
    public Transform MiejsceNaMagazynek;
}