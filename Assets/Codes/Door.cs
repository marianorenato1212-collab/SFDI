using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    [SerializeField] SpriteRenderer[] gems;
    [SerializeField] Collider2D doorBlocker;
    [SerializeField] string nextScene;

    int gemsCount = 0;
    bool doorOpen = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Si colocamos una gema
        if (collision.CompareTag("Gem"))
        {
            gems[gemsCount].color = Color.white;
            gemsCount++;

            Destroy(collision.gameObject);

            // Si tenemos las 3 gemas
            if (gemsCount >= 3)
            {
                OpenDoor();
            }
        }

        // Si el jugador entra a la puerta y está abierta
        if (collision.CompareTag("Player") && doorOpen)
        {
            SceneManager.LoadScene(nextScene);
        }
    }

    void OpenDoor()
    {
        doorOpen = true;

        // Cambia el color de la puerta
        GetComponent<SpriteRenderer>().color = Color.black;

        // Quita el bloqueo
        if (doorBlocker != null)
        {
            doorBlocker.enabled = false;
        }
    }
}