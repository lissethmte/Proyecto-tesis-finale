using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ZoneTimer : MonoBehaviour
{
    public float countdownTime = 60f; // Tiempo en segundos
    public TextMeshProUGUI timerText; // Texto del timer
    public TextMeshProUGUI messageText; // Texto del mensaje de fin

    private float currentTime;
    private bool timerActive = false;

    void Start()
    {
        currentTime = countdownTime;

        // Ocultar textos al inicio
        if (timerText != null) timerText.gameObject.SetActive(false);
        if (messageText != null) messageText.gameObject.SetActive(false);
    }

    void Update()
    {
        if (timerActive)
        {
            currentTime -= Time.deltaTime;
            if (currentTime < 0) currentTime = 0;

            // Actualizar timer
            if (timerText != null)
                timerText.text = "TIEMPO: " + Mathf.Ceil(currentTime).ToString();

            // Fin del timer
            if (currentTime == 0)
            {
                timerActive = false;
                if (messageText != null)
                {
                    messageText.gameObject.SetActive(true);
                    messageText.text = "¡EL TIEMPO SE ACABÓ!";
                }

                // Reiniciar la escena después de 3 segundos
                Invoke("RestartGame", 3f);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Solo se activa con el jugador y si no estaba activo
        if (other.CompareTag("Player") && !timerActive)
        {
            StartTimer();
        }
    }

    void StartTimer()
    {
        timerActive = true;

        // Mostrar el timer al entrar al trigger
        if (timerText != null) timerText.gameObject.SetActive(true);

        // Asegurarse que el mensaje siga oculto
        if (messageText != null) messageText.gameObject.SetActive(false);

        Debug.Log("¡Timer iniciado!");
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
