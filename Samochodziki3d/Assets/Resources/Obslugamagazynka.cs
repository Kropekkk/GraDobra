using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obslugamagazynka : MonoBehaviour
{
    public Color kolormagazynka;
    public MeshRenderer wygladmagazynka;

    private void Start()
    {
        kolormagazynka = new Color(1f, 0f, 0f);
        wygladmagazynka.material.color = kolormagazynka;
    }
}