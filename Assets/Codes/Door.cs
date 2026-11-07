using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    [SerializeField] SpriteRenderer[] gems;
    [SerializeField] Collider2D doorBlocker;
    [SerializeField] string nextScene;

    int gemsCount = 0;
    bool doorOpen = false;
    bool playerNearby = false;

    private void Update()
    {
        if (playerNearby)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                Debug.Log("¡Tecla arriba detectada!");

                if (doorOpen)
                {
                    Debug.Log("¡Puerta abierta!");

                    SceneManager.LoadScene(nextScene);
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Detectar las gemas
        if (collision.CompareTag("Gem"))
        {
            if (gemsCount < gems.Length)
            {
                gems[gemsCount].color = Color.white;
                gemsCount++;

                Destroy(collision.gameObject);
            }

            // Si conseguimos las 3 gemas
            if (gemsCount >= 3)
            {
                OpenDoor();
            }
        }

        // Detectar al jugador
        if (collision.CompareTag("Player"))
        {
            playerNearby = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Si el jugador se aleja de la puerta
        if (collision.CompareTag("Player"))
        {
            playerNearby = false;
        }
    }

    void OpenDoor()
    {
        doorOpen = true;

        GetComponent<SpriteRenderer>().color = Color.black;

        if (doorBlocker != null)
        {
            doorBlocker.enabled = false;
        }
    }
}