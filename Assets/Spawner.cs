using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Prefab del enemigo
    public Transform[] spawnPoints; // Array de posiciones donde se generar�n enemigos
    public float spawnInterval = 3f; // Tiempo entre spawns
    public int maxEnemies = 10; // M�ximo de enemigos en escena

    private int currentEnemies = 0; // Contador de enemigos actuales

    void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), 0f, spawnInterval);
    }

    void SpawnEnemy()
    {
        if (currentEnemies >= maxEnemies) return; // No spawnear m�s si llegamos al l�mite

        int spawnIndex = Random.Range(0, spawnPoints.Length); // Selecciona un punto aleatorio
        Instantiate(enemyPrefab, spawnPoints[spawnIndex].position, Quaternion.identity);
        currentEnemies++; // Aumenta el contador de enemigos
    }

    public void EnemyDestroyed()
    {
        currentEnemies--; // Reduce el contador cuando un enemigo muere
    }
}
