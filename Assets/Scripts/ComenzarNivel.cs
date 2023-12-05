using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ComenzarNivel : MonoBehaviour
{
   public RutinaBoo rutinaBoo;
    public  GameObject PanelLose;
    public TextMeshProUGUI contador;
    public float tiempo = 3f;
    public GameObject ImagenNegra;
    public GameObject Borrador;
    public float tiempoRestante = 10f;

    public TextMeshProUGUI timer;
    public TextMeshProUGUI puntajeText;
    public TextMeshProUGUI MaximoPuntaje;
    
    
     bool termina= false;
   
   int puntaje;
   int maxScore;

   void Awake()
   {
    Time.timeScale = 1;
   }
    void Start()
    {

        // Comienza el contador
        StartCoroutine(TimerComenzar());
        rutinaBoo = FindObjectOfType<RutinaBoo>();
            
        puntaje = PlayerPrefs.GetInt("puntaje");
        puntajeText.text = "Puntaje: " + puntaje.ToString();
         maxScore = PlayerPrefs.GetInt("maximoPuntaje");
        MaximoPuntaje.text = "Maximo Puntaje: " + maxScore.ToString();
       


        



    }

    System.Collections.IEnumerator TimerComenzar()
    {

        while (tiempo >= 1)
        {
            contador.text = tiempo.ToString();
            yield return new WaitForSeconds(1f);
            tiempo--;
            
            
            
        
           
        }


        contador.text = "GO";
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("boo");
            for (int i = 0; i < gameObjects.Length; i++)
            {
                //que se habiliten los colider
                gameObjects[i].GetComponent<Collider2D>().enabled = true;
            }
        
        ImagenNegra.SetActive(true);
        
            
        // Espera 1 segundo
        yield return new WaitForSeconds(1f);
        // Desactiva el contador
        contador.gameObject.SetActive(false);
        Borrador.SetActive(true);
        StartCoroutine(Timer());
    }

    System.Collections.IEnumerator Timer()
    {
        while (tiempoRestante >= 1)
        {
            timer.text = "Tiempo: " + tiempoRestante.ToString();
            yield return new WaitForSeconds(1f);
            tiempoRestante--;
        }

        timer.text = "Time's up!";
        //pausar el juego
        Time.timeScale = 0;

         //setActive false tag boo
          GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("boo");
            for (int i = 0; i < gameObjects.Length; i++)
            {
                gameObjects[i].SetActive(false);
            }

         Borrador.SetActive(false);
         PanelLose.SetActive(true);

        // Espera 1 segundo
        yield return new WaitForSeconds(1f);
        // Desactiva el contador
        timer.gameObject.SetActive(false);
      
       
        
       




    }

    void terminar()
    {
        if (rutinaBoo.terminado == true && termina == false)
        {
            
            Debug.Log("Terminado");
            puntaje++;
            PlayerPrefs.SetInt("puntaje", puntaje);

            termina= true;
            SceneManager.LoadScene("nivel1");
            
            

            
        }
       
    }

    void Update()
    {

        if(termina == false){
        terminar();
        
        }

        //si el puntaje es mayor que el puntaje maximo 
        if (puntaje > maxScore)
        {
            maxScore = puntaje;
            PlayerPrefs.SetInt("maximoPuntaje", maxScore);
            MaximoPuntaje.text = "Maximo Puntaje: " + maxScore.ToString();
        }

    }
}

