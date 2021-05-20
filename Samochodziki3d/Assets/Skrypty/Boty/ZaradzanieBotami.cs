using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZaradzanieBotami : MonoBehaviour
{
    public GameObject Bot;
    int ile_mobow;
    float losowaliczba;
    bool Czytrwa=false;
    float czas = 0;
    public Text tablica;
    public Gra jedynaGra;
    int botaktualne;

    public void Info(int level)
    {
        ile_mobow = 2 + level*2;
        botaktualne = ile_mobow;
    }

    public void Rozpocznij()
    {
        if (!Czytrwa)
        {
            Czytrwa = true;
            Gra();
        }
        else
        {
            Debug.Log("Juztrwa");
        }
    }
    private void Update()
    {
        if (Czytrwa)
        {
            czas += Time.deltaTime;
        }
    }
    void Gra()
    {
        Spawnuj();
        tablica.text = "Gra Level: "+jedynaGra.mojLevelGry;
    }
    void KoniecGry()
    {
        Czytrwa = false;
        tablica.text = "Wygrales, Twoj czas to: " + Mathf.RoundToInt(czas);
        jedynaGra.PrzeszedlLevel();
        czas = 0;
    }
    void Spawnuj()
    {
        while (ile_mobow > 0)
        {
            losowaliczba = Random.Range(-30f, -2f);
            Vector3 spawn = new Vector3(Random.RandomRange(-70f,-50f), 1, losowaliczba);
            Instantiate(Bot, spawn, transform.rotation);
            ile_mobow = ile_mobow - 1;
        }
    }
    public void Jedenniezyje()
    {
        botaktualne = botaktualne - 1;
        if(botaktualne<1)
        {
            KoniecGry();
        }
    }
    public void Przegrana()
    {
        Czytrwa = false;
        tablica.text = "Przegrales Strzel zeby zaczac";
        czas = 0;
        jedynaGra.Przegrana();

        GameObject[] boty = GameObject.FindGameObjectsWithTag("bot");
        foreach (GameObject target in boty)
        {
            GameObject.Destroy(target);
        }
    }

}
