using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private Animator anim;
    private bool yaActivado = false;

    void Start()
    {
        // Obtenemos el componente Animator del objeto
        anim = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica si lo que entró en el trigger es el Jugador y si no se ha activado antes
        if (other.CompareTag("Player") && !yaActivado)
        {
            yaActivado = true;
            
            // Dispara la animación de encendido
            anim.SetTrigger("Activar");

            // Aquí puedes guardar la posición para el Respawn del jugador
            GuardarCheckpoint(transform.position);
        }
    }

    void GuardarCheckpoint(Vector2 posicion)
    {
        // Una forma rápida de guardar la posición usando PlayerPrefs
        PlayerPrefs.SetFloat("CheckpointX", posicion.x);
        PlayerPrefs.SetFloat("CheckpointY", posicion.y);
        PlayerPrefs.Save();
        
        Debug.Log("¡Checkpoint guardado en: " + posicion + "!");
    }
}