using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTwoTrigger : MonoBehaviour
{
    [Tooltip("Nombre de la escena a cargar al colisionar")]
    public string levelTwoSceneName = "LevelTwo"; // Nombre exacto de tu escena

    void OnTriggerEnter(Collider other)
    {
        // Verifica que el objeto que colisiona sea el jugador
        if (other.CompareTag("Player"))
        {
            Debug.Log("Jugador colisionó con el spawn. Cargando LevelTwo...");
            SceneManager.LoadScene(levelTwoSceneName);
        }
    }
}
