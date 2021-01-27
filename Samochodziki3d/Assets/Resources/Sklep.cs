using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Sklep : MonoBehaviour
{
    public List<GameObject> nowaLista;

    public GameObject zaznaczony;

    public Transform MiejsceBroni;
    public GameObject TaBron;

    public GameObject SzkieletBroni;
    public GameObject MagazyekBroni;
    public GameObject LufaBroni;

    public ObslugaSzkieletu obsluga_szkieletu;
    public Obslugamagazynka mag;
    public ObslugaLufy lufa;

    public ObslugaBroni mojabron;





    private void Start()
    {


    }

    void Update()   
    {
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray,out hit))
            {
                BoxCollider bc = hit.collider as BoxCollider;
                if(bc!=null)
                {
                    if(Resources.Load(bc.name) !=null)
                    {
                        zaznaczony = Instantiate(Resources.Load(bc.name)) as GameObject;
                        Wykonaj();
                    }
                }
            }
        }
    }
    void Wykonaj()
    {
        if(SzkieletBroni==null)
        {
            if(zaznaczony.GetComponent<ObslugaSzkieletu>())
            {
                SzkieletBroni = Instantiate(zaznaczony, MiejsceBroni.position, MiejsceBroni.rotation);
                SzkieletBroni.transform.parent = MiejsceBroni.transform;
                obsluga_szkieletu = SzkieletBroni.GetComponent<ObslugaSzkieletu>();
                mojabron.Szkielet = SzkieletBroni;
            }
        }
        else
        {
            if(zaznaczony.GetComponent<Obslugamagazynka>())
            {
                if(MagazyekBroni==null)
                {
                    MagazyekBroni = Instantiate(zaznaczony, obsluga_szkieletu.Miejsce_Na_Magazynek.position, obsluga_szkieletu.Miejsce_Na_Magazynek.rotation);
                    MagazyekBroni.transform.parent = MiejsceBroni.transform;
                }
                else
                {
                    Destroy(MagazyekBroni);
                    MagazyekBroni = Instantiate(zaznaczony, obsluga_szkieletu.Miejsce_Na_Magazynek.position, obsluga_szkieletu.Miejsce_Na_Magazynek.rotation);
                    MagazyekBroni.transform.parent = MiejsceBroni.transform;
                }
                mojabron.Magazynek = MagazyekBroni;
                
            }
            if(zaznaczony.GetComponent<ObslugaLufy>())
            {
                if(LufaBroni==null)
                {
                    LufaBroni = Instantiate(zaznaczony, obsluga_szkieletu.Miejsce_Na_Lufe.position, obsluga_szkieletu.Miejsce_Na_Lufe.rotation);
                    LufaBroni.transform.parent = MiejsceBroni.transform;
                }
                else
                {
                    Destroy(LufaBroni);
                    LufaBroni = Instantiate(zaznaczony, obsluga_szkieletu.Miejsce_Na_Lufe.position, obsluga_szkieletu.Miejsce_Na_Lufe.rotation);
                    LufaBroni.transform.parent = MiejsceBroni.transform;
                }
                mojabron.Lufa = LufaBroni;
            }
        }

        Destroy(zaznaczony);

    }
    public void Zapisz()
    {
        TaBron.transform.rotation = Quaternion.Euler(-90, 0, 0);
        PrefabUtility.SaveAsPrefabAsset(TaBron, "Assets/Resources/Bronie/NowaBron.prefab");
    }
}