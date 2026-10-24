using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] float speed=5f;
    [SerializeField] float jumpForce=7f;
    [SerializeField] LayerMask groundLayer; 
    // El lugar al que debe regresar el jugador    
    Vector2 savePoint;
    // La altura de caída; si el jugador alguna vez está por debajo de ella, lo devolveremos al punto de guardado.
    [SerializeField] float RespawnHeight; 
    public bool isGrounded = false;
    Rigidbody2D rb;
    SpriteRenderer sprite;
     Animator anim;
     [SerializeField] GameObject prefab; // El objeto de plataforma que crearemos
     GameObject building_prefab; // Una variable en la que almacenaremos la plataforma creada actualmente
    int steps = 0; // El número de plataformas en el inventario
    [SerializeField] GameObject steps_panel; // El panel de interfaz de inventario
     [SerializeField] GameObject prefab2; // El objeto de plataforma que crearemos
 GameObject building_prefab2; // Una variable en la que almacenaremos la plataforma creada actualmente
 int steps2 = 0; // El número de plataformas en el inventario
 [SerializeField] GameObject steps_panel2; // El panel de interfaz de inventario
 [SerializeField] GameObject Magnet; // variable imán

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        savePoint = transform.position;// Al comienzo del juego, almacenamos la posición actual del personaje como nuestro punto de reaparición.
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        
        if (horizontalInput > 0)
        {
            sprite.flipX = false;
        }
        if (horizontalInput < 0)
        {
            sprite.flipX = true;
        }

             // Controles de personaje
             rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);

          // Almacenando el colisionador en una variable separada para facilitar su uso
         Collider2D col = GetComponent<Collider2D>();
            // Creando un área circular debajo de los pies del personaje
            isGrounded = Physics2D.OverlapCircle(transform.position - transform.up * ((col.bounds.extents.y / transform.localScale.y - col.offset.y) * transform.localScale.y), 0.01f, groundLayer);
        
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
           if (horizontalInput != 0)
            {
                anim.SetBool("Run", true);
            }
            else
            {
                anim.SetBool("Run", false);
            }

         anim.SetFloat("Y", rb.velocity.y);
        if (isGrounded) 
        anim.SetFloat("Y", 0); 

        if (Input.GetKeyDown(KeyCode.S))
        {
            anim.SetBool("Crouch" , true);
        }
        else
        {
            anim.SetBool("Crouch" , false);
        }
        if (building_prefab) // Si la variable building_prefab contiene un objeto...
        {

            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); // Obteniendo la posición del mouse
            building_prefab.transform.position = new Vector3(mousePosition.x, mousePosition.y, transform.position.z); // Mover el objeto a la posición del mouse

            if (Input.GetMouseButtonDown(0)) // Si se hace clic con el botón izquierdo del ratón...
            {
                building_prefab.GetComponent<Collider2D>().enabled = true; // Habilitar el componente collider en el objeto
                building_prefab = null; // Borrar la variable del objeto de construcción para detener la ejecución de este código
                
            }
        }
        if (transform.position.y<RespawnHeight) // Si la elevación actual del personaje es inferior a RepsawnHeight...
         {
            transform.position = savePoint; // ... cambiamos la posición del personaje a la almacenada en la variable del punto de reaparición.
         }
         if (building_prefab) // Si la variable building_prefab contiene un objeto...
            {

                Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); // Obteniendo la posición del mouse
                building_prefab.transform.position = new Vector3(mousePosition.x, mousePosition.y, transform.position.z); // Mover el objeto a la posición del mouse

                if (Input.GetMouseButtonDown(0)) // Si se hace clic con el botón izquierdo del ratón...
                {
                    building_prefab.GetComponent<Collider2D>().enabled = true; // Habilitar el componente collider en el objeto
                    building_prefab = null; // Borrar la variable del objeto de construcción para detener la ejecución de este código
                    
                }
            }
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
       if (collision.tag == "checkpoint") // Si la etiqueta del objeto que tocamos es 'checkpoint'...
        {
           savePoint = collision.transform.position; // ...el punto de reaparición cambia al centro del objeto tocado.
        }

        if (collision.tag == "block") // Si la etiqueta del objeto colisionado es "block"
        {
            steps++; // Aumentar el número de bloques recolectados
            Destroy(collision.gameObject); // Destruyendo el bloque recolectado
            foreach (Transform child in steps_panel.transform) // Iterando sobre todos los elementos secundarios en el panel de inventario
            {
             if (!child.gameObject.activeInHierarchy) // Si el objeto está inactivo...
                {
                    child.gameObject.SetActive(true); // Activándolo
                 return; // Deteniendo la iteración
                }
            }
        }
        if (collision.tag == "rocky") // Si la etiqueta del objeto colisionado es "rocky"
        {
            steps2++; // Aumentar el número de bloques recolectados
            Destroy(collision.gameObject); // Destruyendo el bloque recolectado
            foreach (Transform child in steps_panel2.transform) // Iterando sobre todos los elementos secundarios en el panel de inventario
            {
                if (!child.gameObject.activeInHierarchy) // Si el objeto está inactivo...
                {
                    child.gameObject.SetActive(true); // Activándolo
                    return; // Deteniendo la iteración
                }
            }
        }
        if (collision.tag == "Magnet")
        {
            Magnet.SetActive(true);
            Destroy(collision.gameObject);
        }
    }
    public void Build_Click()
    {
        steps--; // Disminuir el número de plataformas en el inventario
        foreach (Transform child in steps_panel.transform)
        {
    
            if (child.gameObject.activeInHierarchy) // Si el objeto está activo...
            {
                child.gameObject.SetActive(false); // Desactivarlo
                building_prefab = Instantiate(prefab); // Crear una plataforma y almacenarla en la variable
                return; // Deteniendo las iteraciones
            }
        
        }
        {
            steps2--; // Disminuir el número de plataformas en el inventario
            foreach (Transform child in steps_panel.transform)
            {
            
                if (child.gameObject.activeInHierarchy) // Si el objeto está activo...
                {
                    child.gameObject.SetActive(false); // Desactivarlo
                    building_prefab = Instantiate(prefab); // Crear una plataforma y almacenarla en la variable
                    return; // Deteniendo las iteraciones
                }
                
            }
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
   {
       if (collision.transform.GetComponent<PlatformEffector2D>())// Comprobar si el objeto sobre el que estamos parados tiene un componente Platform Effector 2D
       {
           if (Input.GetKey(KeyCode.S)) // If tre S key is pressed
           collision.transform.GetComponent<Collider2D>().isTrigger = true;// Habilitando isTrigger para el objeto en el que estamos parados

       }
   }

   private void OnTriggerExit2D(Collider2D other)
   {
       if (other.GetComponent<PlatformEffector2D>())// Si salimos de la zona de activación del collider con el componente Platform Effector 2D
       {
           other.isTrigger = false;// Deshabilitar la propiedad isTrigger
       }
   }
}
