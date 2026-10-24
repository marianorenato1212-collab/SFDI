using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    public Transform[] backgrounds; // Matriz de fondos
    public float[] parallaxSpeeds; // La matriz que contiene la velocidad de paralaje para cada fondo
    private float cameraHorizontalPosition; // Una variable que almacena la posición horizontal actual de la cámara.
    private float previousCameraHorizontalPosition; // Una variable que almacena la posición horizontal anterior de la cámara. 
    private float cameraVerticalPosition; // Una variable que almacena la posición horizontal actual de la cámara.
    private float previousCameraVerticalPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Obtener la posición horizontal actual de la cámara
        cameraHorizontalPosition = Camera.main.transform.position.x;


        // Comprobando los cambios en la posición de la cámara
        if (cameraHorizontalPosition != previousCameraHorizontalPosition)
        {
            // Mover los fondos a lo largo del eje X según sus velocidades de paralaje
             for (int i = 0; i < backgrounds.Length; i++)
            {
                 float parallax = (previousCameraHorizontalPosition - cameraHorizontalPosition) * parallaxSpeeds[i];
                 backgrounds[i].position += new Vector3(parallax, 0f, 0f);
            }

            // Actualizar la posición anterior de la cámara
            previousCameraHorizontalPosition = cameraHorizontalPosition;
        }
        cameraVerticalPosition = Camera.main.transform.position.y;


        // Comprobando los cambios en la posición de la cámara
        if (cameraVerticalPosition != previousCameraVerticalPosition)
        {
            // Mover los fondos a lo largo del eje X según sus velocidades de paralaje
             for (int i = 0; i < backgrounds.Length; i++)
            {
                 float parallax = (previousCameraVerticalPosition - cameraVerticalPosition) * parallaxSpeeds[i];
                 backgrounds[i].position += new Vector3(0f, parallax, 0f);
            }

            // Actualizar la posición anterior de la cámara
            previousCameraVerticalPosition = cameraVerticalPosition;
        }
    }
}
