using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
 [SerializeField] SpriteRenderer[] gems; // La lista de cristales
   int gemsCount; // La cantidad de cristales colocados al lado de la puerta

   private void OnTriggerEnter2D(Collider2D collision)
   {
       if (collision.tag == "Gem")
       {

           gems[gemsCount].color = Color.white;// Cambiando el color del cristal a blanco
           gemsCount++; // Aumentar el número de cristales recolectados
           Destroy(collision.gameObject); // Destruyendo el cristal llevado al pedestal
           if (gemsCount >= 3) // Si se han llevado 3 cristales a los pedestales
           {
               GetComponent<SpriteRenderer>().color = Color.black;// Cambiando el color de la puerta a negro
           }
       }
   }
}
