using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateOnClick : MonoBehaviour
{
    private void OnMouseDown() // Una función que se activa al hacer clic en el colisionador del objeto
    {
        transform.Rotate(0, 0, 90); // girando el objeto 90 grados sobre el eje Z
    }
}
