using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObslugaLufy : MonoBehaviour
{
    public Color kolorLufy;
    public MeshRenderer wygladLufy;
    public Lufa mojalufa;

    public void KolorLufy()
    {
        //wygladLufy.material.color = kolorLufy;
        wygladLufy.sharedMaterial.color = kolorLufy;
    }
}
