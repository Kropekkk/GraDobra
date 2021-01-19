using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gra : MonoBehaviour
{
    public int mojLevelGry;
    public Text ktorylevel;
    public ZaradzanieBotami obslugbotow;

    void Start()
    {
        InformacjeOgrze();
    }
    void InformacjeOgrze()
    {
        mojLevelGry = PlayerPrefs.GetInt("LevelGry");
        if (mojLevelGry == 0)
        {
            mojLevelGry = 1;
        }
        Teksty();
        Wyslij();
    }
    public void PrzeszedlLevel()
    {
        int ch;
        ch = PlayerPrefs.GetInt("Pieniadze");
        PlayerPrefs.SetInt("Pieniadze", ch+10*mojLevelGry);
        mojLevelGry = mojLevelGry + 1;
        PlayerPrefs.SetInt("LevelGry", mojLevelGry);
        Teksty();
        Wyslij();
    }
    void Teksty()
    {
        ktorylevel.text = "Level: " + mojLevelGry;
    }
    void Wyslij()
    {
        obslugbotow.Info(mojLevelGry);
    }
    public void Przegrana()
    {
        mojLevelGry = 1;
        PlayerPrefs.SetInt("LevelGry", mojLevelGry);
        Teksty();
        Wyslij();
    }
}
