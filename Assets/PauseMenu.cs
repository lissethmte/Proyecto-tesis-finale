using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [Header("Panel del menú de pausa")]
    public GameObject pausePanel;

    private bool isPaused = false;

    void Start()
    {
        // Asegura que el menú de pausa esté oculto al inicio
        if (pausePanel != null)
            pausePanel.SetActive(false);
    }

    void Update()
    {
        // Pulsar Escape o P para pausar/reanudar
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }
    }

    public void PauseGame()
    {
        if (pausePanel != null)
            pausePanel.SetActive(true);

        Time.timeScale = 0f; // Pausa el juego
        isPaused = true;
        Debug.Log("Juego pausado");
    }

    public void ResumeGame()
    {
        if (pausePanel != null)
            pausePanel.SetActive(false);

        Time.timeScale = 1f; // Reanuda el juego
        isPaused = false;
        Debug.Log("Juego reanudado");
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; // Asegura que el tiempo vuelva a la normalidad
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Debug.Log("Juego reiniciado");
    }

    public void QuitGame()
    {
        Time.timeScale = 1f; // Para que el tiempo no quede en 0
        Debug.Log("Salir del juego");
        Application.Quit();
    }
}

