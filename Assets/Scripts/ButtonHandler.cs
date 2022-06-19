using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ButtonHandler : MonoBehaviour
{
    [SerializeField]
    private List<VirtualButtonBehaviour> virtualButtons = new List<VirtualButtonBehaviour>();

    // Start is called before the first frame update
    private void Start()
    {
        foreach (var virtualButton in virtualButtons)
        {
            virtualButton.RegisterOnButtonPressed(OnButtonPressed);
        }
    }

    private void OnButtonPressed(VirtualButtonBehaviour button)
    {
        Spawner spawner = button.GetComponentInChildren<Spawner>();
        Debug.Log(button.name);
        // Stop if spawner has no spawn
        if (!spawner.isSpawned)
            return;

        // Do something like add or remove life based on spawn
        switch (spawner.currentType)
        {
            case SpawnType.Mole:
                GameManager.instance.PlaySound(2);
                GameManager.instance.AddScore();
                Debug.Log(button.name + " is hit");//double check if the button is being hit
                break;
            case SpawnType.Trap:
                GameManager.instance.RemoveAllLives();
                break;
            case SpawnType.Impostor:
                GameManager.instance.PlaySound(2);
                GameManager.instance.AddBonusScore();
                break;
        }

        // Despawn
        spawner.Despawn();
        Debug.Log("Touch");
    }
}
