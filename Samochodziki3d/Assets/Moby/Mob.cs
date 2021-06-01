using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Nowy Mob",menuName ="Mob")]
public class Mob : ScriptableObject
{
    public int Predkosc_Moba;
    public int punkty_zycia;

    public int Czas_animacji_jedzenia;
    public int Czas_animacji_idle;
    public int Czas_animacji_ruchu;

    public float Wielkosc_minimalna_moba;
    public float Wielkosc_maksymalna_moba;

    public bool Mozliwosc_atakowania_innych;

    public int Damage_zadawany_innym;

}
