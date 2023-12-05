using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reintentar : MonoBehaviour
{

    public ComenzarNivel comenzarNivel;
    int puntaje;
    // Start is called before the first frame update
    void Start()
    {
        comenzarNivel = FindObjectOfType<ComenzarNivel>();
       
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //metodo onclick
    public void ReintentarNivel()
    {
        SceneManager.LoadScene("Nivel1");
         PlayerPrefs.SetInt("puntaje", 0);
    }
}
        

