using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_controller : MonoBehaviour
{
    [SerializeField] GameObject tip, objects;

    private void OnTriggerEnter2D()
    {
        objects.SetActive(true); // Activar objetos coleccionables
        tip.SetActive(true); // Activar la pista de texto
        Destroy(tip, 10); // Destruir la pista de texto después de 10 segundos
        Destroy(this); // Destruir este script
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
