using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniJeu : MonoBehaviour
{
    public float pointageTemps;
    public TextMeshProUGUI textScore;
    public TextMeshProUGUI textScorePanneau;
    [SerializeField] GameObject panneauRecord;
    public TMP_InputField inputNom; 

    void Start()
    {
        //supprimer apres!!
        //PlayerPrefs.DeleteAll();
        pointageTemps = 0;
    }

    private void Update()
    {
        textScore.text = pointageTemps.ToString("00.00");
    }

  public  void TraiterDefaite()
    {
        float recordActuel = PlayerPrefs.GetFloat("meilleurScore", 0f);
        if (pointageTemps>=recordActuel)
        {
            Invoke("MontrerPanneauNouveauRecord", 3f);
        }
        
    }

    void MontrerPanneauNouveauRecord()
    {
        Debug.Log("Nouveau Record");
        panneauRecord.SetActive(true);
        textScorePanneau.text = textScore.text;
    }

    public void EnregistrerNomRecord() {

        string nom = inputNom.text;
        PlayerPrefs.SetString("nom", nom);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //Redemarrer la scene actuel
    }
}
