using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Nowa Bron",menuName = "Bron")]
public class Bron : ScriptableObject
{
    public string nazwa_broni;
    public string magazynek;
    public string szkieletbroni;
    public string lufa;
    public Magazynek mojmagazynek;
    public Lufa mojalufa;
    public SzkieletBroni mojszkielet;
}
