using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Nowa Bron",menuName = "Bron")]
public class Bron : ScriptableObject
{
    public string nazwa_broni;

    public int damage;
    public int zasieg;

    public string Jaki_magazynek_pasuje;
    public Magazynek aktualny_magazynek;


}
