using UnityEngine;

public class KeyDos : MonoBehaviour
{
    [Header("Pantalla de victoria (Canvas o Panel)")]
    public GameObject victoryScreen;

    void Start()
    {
        // Oculta la pantalla de victoria al inicio
        if (victoryScreen != null)
            victoryScreen.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("¡Jugador recogió la llave de victoria!");

            if (victoryScreen != null)
                victoryScreen.SetActive(true);

            // Opcional: detener el tiempo al ganar
            Time.timeScale = 0f;

            // Opcional: destruir la llave para que no vuelva a activarse
            Destroy(gameObject);
        }
    }
}
