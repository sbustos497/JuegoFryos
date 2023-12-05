using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RutinaBoo : MonoBehaviour
{
    public GenerarBoo generarBoo;
    public Rigidbody2D rb;
    public float speed = 400f;

    int congelado;
   public bool terminado = false;





    HashSet<Collider2D> objetosCongelados = new HashSet<Collider2D>();
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)) * speed);
        generarBoo = FindObjectOfType<GenerarBoo>();


    }


    void Update()
    {
        // Restringir la posición del objeto dentro de los límites de la cámara
        Vector3 clampedPosition = Camera.main.WorldToViewportPoint(transform.position);
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, 0.05f, 0.95f);
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, 0.05f, 0.95f);
        transform.position = Camera.main.ViewportToWorldPoint(clampedPosition);

        if (clampedPosition.x == 0.05f || clampedPosition.x == 0.95f)
        {
            rb.velocity = new Vector2(-rb.velocity.x, rb.velocity.y);
        }
        if (clampedPosition.y == 0.05f || clampedPosition.y == 0.95f)
        {
            rb.velocity = new Vector2(rb.velocity.x, -rb.velocity.y);
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;

            Collider2D[] colliders = Physics2D.OverlapPointAll(mousePos);

            foreach (Collider2D collider in colliders)
            {
                if (!objetosCongelados.Contains(collider))
                {
                    collider.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                    objetosCongelados.Add(collider);
                    congelado++;
                    Debug.Log("Congelado: " + congelado);
                }
            }
        }

        if (congelado == generarBoo.spawnCount && !terminado)
        {
            
            terminado = true;
            Debug.Log("Terminado");

        }
    }





    




}





































