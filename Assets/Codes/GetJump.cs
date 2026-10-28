using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetJump : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
   {
       if (collision.GetComponent<PlayerControl>())// si el objeto con el que chocamos tiene el script playerControl
       { 
       collision.gameObject.AddComponent<DoubleJump>();// adjuntar el script de doble salto al personaje del jugador
       Destroy(gameObject);
       }
   }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
