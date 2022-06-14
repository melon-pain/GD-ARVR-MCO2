using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SpawnType
{
    Mole,
    Trap,
    Impostor
}

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject molePrefab;
    [SerializeField]
    private GameObject trapPrefab;
    [SerializeField]
    private float trapSpawnChance = 0.2f;
    [SerializeField]
    private GameObject impostorPrefab;
    [SerializeField]
    private float impostorSpawnChance = 0.1f;

    private Dictionary<SpawnType, GameObject> spawn = new Dictionary<SpawnType, GameObject>();
    private GameObject current = null;
    public SpawnType currentType { get; private set; }

    public bool isSpawned { get; private set; } = false;

    // Start is called before the first frame update
    private void Start()
    {
        spawn.Add(SpawnType.Mole, Instantiate(molePrefab, transform));
        spawn.Add(SpawnType.Trap, Instantiate(trapPrefab, transform));
        spawn.Add(SpawnType.Impostor, Instantiate(impostorPrefab, transform));
    }

    public void Spawn()
    {
        float rand = Random.Range(0.0f, 1.0f);
        if (rand <= impostorSpawnChance)
        {
            // Play amogus SFX here
            currentType = SpawnType.Impostor;
        }
        else if (rand <= trapSpawnChance)
        {
            currentType = SpawnType.Trap;
        }
        else
        {
            currentType = SpawnType.Mole;
        }

        current = spawn[currentType];
        current.SetActive(true);

        isSpawned = true;
        Debug.Log("Spawn");
    }

    public void Despawn()
    {
        current.SetActive(false);
        isSpawned = false;

        Debug.Log("Despawn");
    }
}
