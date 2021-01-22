using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bron : MonoBehaviour
{
    public float damage;
    public float zasieg;
    public float coile = 2f;

    private float czas = 0f;

    public int Magazynek, amunicja;

    public Camera mojwidok;
    public Text Ileamunicji;
    public bool czyAutomat=true;
    public ZaradzanieBotami boty;
    public MeshRenderer kolor_broni;
    public MeshRenderer kolor_magazynka;
    public MeshRenderer kolor_lufy;
    bool zmiana_magazynka = true;
    public Animator bron_animacja;
    float czasmagazynka;

    void Start()
    {
        //GameObject go = Instantiate(Resources.Load("Karabin"), transform.position, transform.rotation) as GameObject;
        //go.transform.parent = GameObject.Find("Slot1").transform;
        //Instantiate(Resources.Load("Karabin"),transform.position,transform.rotation);
        KonfiguracjaBroni();
    }
    void Update()
    {
        if(czyAutomat)
        {
            if(Input.GetButton("Fire1") && Time.time >= czas && amunicja > 0)
            {
                czas = Time.time + coile / 10;
                Strzal();
            }
        }
        else
        {
            if (Input.GetButtonDown("Fire1") && Time.time >= czas && amunicja > 0)
            {
                czas = Time.time + coile / 2;
                Debug.Log("czasgry: " + Time.time + " nastepnystrzral: " + czas);
                Strzal();
            }
        }
        if(Input.GetKey("r") && zmiana_magazynka)
        {
            Zmiana();
        }
        else
        {
            czasmagazynka += Time.deltaTime;
            if(czasmagazynka>2)
            {
                bron_animacja.SetBool("magazynek", false);
                zmiana_magazynka = true;
                czasmagazynka = 0;
            }
        }
    }
    void Strzal()
    {
        amunicja = amunicja - 1;
        PlayerPrefs.SetInt("MojeAmmo", amunicja);
        Ileamunicji.text = "Amunicja: " + amunicja;
        RaycastHit hit;
        if (Physics.Raycast(mojwidok.transform.position, mojwidok.transform.forward, out hit, zasieg)) ;
        {
            if(hit.transform.name =="Start")
            {
                boty.Rozpocznij();
            }
            Bot jaki = hit.transform.GetComponent<Bot>();
            if (jaki != null)
            {
                jaki.Zycie(10f);
            }
        }
    }
    void KonfiguracjaBroni()
    {
       /* kolor_broni.material.color = new Color(1f, 0f, 0f, 1f);
        kolor_magazynka.material.color = new Color(0f, 0f, 0f);
        kolor_lufy.material.color = new Color(0, 1f, 0f);
        Rodzajebroni mojabron = new Rodzajebroni("Pistolet");
        damage = mojabron.damage;
        zasieg = mojabron.zasieg;
        Magazynek = mojabron.pojemnoscmagazynka;
        amunicja = mojabron.amunicja;
        Ileamunicji.text = "Amunicja: " + amunicja;*/
    }
    void Zmiana()
    {
        bron_animacja.SetBool("magazynek", true);
        zmiana_magazynka = false;

    }
}