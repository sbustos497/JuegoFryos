using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorrarConCursor : MonoBehaviour
{
 public GameObject objetoABorrar;
 bool presionar;

 //start es el primer metodo que se ejecuta
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
       Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
         mousePos.z = 0;

         if(presionar == true){
             GameObject objeto = Instantiate(objetoABorrar, mousePos, Quaternion.identity);
             objeto.transform.parent = GameObject.Find("Borrador").transform;
         }

            if(Input.GetMouseButtonDown(0)){
                presionar = true;
            }

           else if(Input.GetMouseButtonUp(0)){
                presionar = false;
            }

            
    }


    
}

