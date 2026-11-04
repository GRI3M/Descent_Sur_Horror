using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class EnemySpawner : MonoBehaviour
{
    [Header("Pluggins")]
    [SerializeField] GameObject criminal;
    [SerializeField] Transform spawnPoint;
    PlayerHealth playerHealth;

    [Header("Enemy Spawner Values")]
    [SerializeField] float spawnTime = 5;
    

    void Start()
    {
        playerHealth = FindAnyObjectByType<PlayerHealth>();
        StartCoroutine(spawnEnemyRoutine());
    }

    /// <summary>
    /// Coroutine that spawns enemies at spawn gate.
    /// </summary>
    /// <returns>Time to spawn next enemy</returns>
    IEnumerator spawnEnemyRoutine()
    {
        while (playerHealth)
        {
            Instantiate(criminal, spawnPoint.position, transform.rotation);
            yield return new WaitForSeconds(spawnTime);  
        }
    }
}
