using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    [SerializeField]
    private List<Spawner> spawners = new List<Spawner>();
    [Header("Spawn")]
    [SerializeField]
    private float minSpawnInterval;
    [SerializeField]
    private float maxSpawnInterval;
    [Header("Despawn")]
    [SerializeField]
    private float minDespawnInterval;
    [SerializeField]
    private float maxDespawnInterval;

    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            // Wait for spawn
            yield return new WaitForSeconds(Random.Range(minSpawnInterval, maxSpawnInterval));

            // Spawn at random spawner
            Spawner toSpawn = spawners[Random.Range(0, spawners.Count)];
            if (!toSpawn.isSpawned)
            {
                toSpawn.Spawn();
            }

            // Wait for despawn
            yield return new WaitForSeconds(Random.Range(minDespawnInterval, maxDespawnInterval));

            // If spawned was not KO'd, remove life and despawn
            if (toSpawn.isSpawned)
            {
                toSpawn.Despawn();
                GameManager.instance.RemoveLife();
            }
        }
    }
}
