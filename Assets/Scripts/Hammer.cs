using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class Hammer : MonoBehaviour
{
    public ObserverBehaviour hammerTarget;
    private bool isTracked = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isTracked)
        {
            Ray r = Camera.main.ScreenPointToRay(RayCaster());
            RaycastHit hit;

            if (Physics.Raycast(r, out hit, 100, LayerMask.GetMask("Default")))
            {
                if(hit.collider.TryGetComponent<Spawner>(out Spawner spawner))
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
                Debug.Log(hit.collider.name);
            }
        }
    }

    public void OnTargetStatusChanged(ObserverBehaviour target, TargetStatus targetStatus)
    {
        if (targetStatus.Status == Status.NO_POSE)
        {
            OnTargetLost();
        }
        else
        {
            OnTargetDetected();
        }
    }
    public void OnTargetDetected()
    {
        isTracked = true;
    }

    public void OnTargetLost()
    {
        isTracked = false;
    }

    private Vector2 RayCaster()
    {
        return Camera.main.WorldToScreenPoint(hammerTarget.transform.position);
    }
}
