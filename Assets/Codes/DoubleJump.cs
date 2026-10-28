using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJump : MonoBehaviour
{
 bool used; // una variable que se utiliza para rastrear si el jugador ha utilizado el segundo salto
   Rigidbody2D rb;
   void Start()
   {
       rb = GetComponent<Rigidbody2D>();
   }

   void Update()
   {

       if (!used)// si se usó el segundo salto
           used = GetComponent<PlayerControl>().isGrounded; // devolviendo la carga de doble salto si estamos en el suelo
       else
       if (Input.GetKeyDown(KeyCode.Space))
       {
           rb.velocity = new Vector2(rb.velocity.x, 7);
           used = false;
       }
   }
}
