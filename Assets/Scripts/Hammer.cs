using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Spawner>(out Spawner spawner))
        {
            if (!spawner.isSpawned)
                return;

            switch (spawner.currentType)
            {
                case SpawnType.Mole:
                    GameManager.instance.PlaySound(3);
                    GameManager.instance.AddScore();
                    break;
                case SpawnType.Trap:
                    GameManager.instance.RemoveAllLives();
                    break;
                case SpawnType.Impostor:
                    GameManager.instance.PlaySound(1);
                    GameManager.instance.AddBonusScore();
                    break;
            }

            spawner.Despawn();
            Debug.Log("Bonk");
        }
    }
}
