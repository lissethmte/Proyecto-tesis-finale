using UnityEngine;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{
    public void RestartGame()
    {
        // Asegura que el tiempo no quede pausado
        Time.timeScale = 1f;

        // Cargar la primera escena del juego
        SceneManager.LoadScene(0);
    }
}
