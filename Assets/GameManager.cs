using UnityEngine;
using TMPro; // Importante para TextMeshPro
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("UI Elements")]
    public GameObject gameOverPanel;  // Panel de Game Over
    public GameObject victoryPanel;   // Panel de Victoria
    public TextMeshProUGUI scoreText; // Texto de Puntuación en pantalla

    private int score = 0;
    public int winningScore = 50; // Puntos necesarios para ganar
    private bool gameEnded = false; // Para evitar múltiples activaciones

    private void Awake()
    {
        // Singleton para asegurarnos de que solo haya una instancia del GameManager
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject); // Evitar duplicados de GameManager
        }
    }

    private void Start()
    {
        // Asegurarse de que la pausa ya haya sido manejada por el MenuManager
        // El código de pausa debería estar en el MenuManager, no en el GameManager
        if (gameOverPanel != null) gameOverPanel.SetActive(false);
        if (victoryPanel != null) victoryPanel.SetActive(false);
        UpdateScoreUI();
    }

    // Método para sumar puntos
    public void AddScore(int points)
    {
        if (gameEnded) return; // No sumar puntos si el juego terminó

        score += points;
        UpdateScoreUI();

        // Verificar si el jugador alcanzó la puntuación ganadora
        if (score >= winningScore)
        {
            WinGame();
        }
    }

    // Método para activar Game Over
    public void GameOver()
    {
        if (gameEnded) return;

        gameEnded = true;
        if (gameOverPanel != null) gameOverPanel.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        // No pausar el tiempo aquí, ya que la pausa se maneja en el MenuManager
    }

    // Método para activar Victoria
    public void WinGame()
    {
        if (gameEnded) return;

        gameEnded = true;
        if (victoryPanel != null) victoryPanel.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        // No pausar el tiempo aquí, ya que la pausa se maneja en el MenuManager
    }

    // Método para reiniciar el juego
    public void RestartGame()
    {
        SceneManager.LoadScene("ArtAttack");
        // El reinicio de la escena y el control del tiempo debe ser manejado desde el MenuManager
        //UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

    // Método para actualizar el UI del score
    public void UpdateScoreUI()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + score;
        else
            Debug.LogError("⚠️ ¡TextMeshPro del Score no asignado en el GameManager!");
    }
}
