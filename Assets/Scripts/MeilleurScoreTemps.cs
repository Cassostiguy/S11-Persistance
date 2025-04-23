using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MeilleurScoreTemps : MonoBehaviour
{
    public float meilleurScore = 0f;
    public TextMeshProUGUI textMeilleurScore;

    private MiniJeu _jeu;

    private void Start()
    {
        _jeu = GetComponent<MiniJeu>();
        //va regarder les meme composante qui a dans d'audre script

        meilleurScore = PlayerPrefs.GetFloat("meilleurScore", 0f);
        //0f est la valeur de default
      
       string nom = PlayerPrefs.GetString("nom","");
        textMeilleurScore.text = "Meilleur score de " + nom +" "+ meilleurScore.ToString("00.00");
    }

    private void Update()
    {
        if(_jeu.pointageTemps > meilleurScore)
            //si le pointage actuel est plus eleve que le meilleur score
        {
            meilleurScore = _jeu.pointageTemps;

            PlayerPrefs.SetFloat("meilleurScore", meilleurScore);
            //remplace la valeur de meilleur score
            textMeilleurScore.text = "Meilleur score "+" : " + meilleurScore.ToString("00.00");
            //DateTime.Now.ToString("g") pas obligé montre le temps ou on a eu le meilleur score
        }
    }
}
