using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObslugaSzkieletu : MonoBehaviour
{
    public Color kolorszkieltu;
    public MeshRenderer wygladszkieltu;
    public SzkieletBroni mojszkielet;

    public Transform Miejsce_Na_Magazynek;
    public Transform Miejsce_Na_Lufe;

    public ParticleSystem blysk;

    public int damage_szkieletu;

    public void Awake()
    {
        damage_szkieletu = mojszkielet.damage;
    }

    public void MojKolorSzkieletu()
    {
        wygladszkieltu.material.color = kolorszkieltu;
        //wygladszkieltu.sharedMaterial.color = kolorszkieltu;
    }
    public void Strzal()
    {
        blysk.Play();
    }
}