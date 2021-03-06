using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Vuforia;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public UIManager ui;
    public int score { get; private set; } = 0;
    public int highScore { get; private set; } = 0;
    [SerializeField]
    private int life = 3;
    public bool isGameOver { get; private set; } = false;
    [SerializeField] private AudioBank audioBank;
    public AudioSource audioSource;
    [SerializeField] private ObserverBehaviour imageTarget;

    public SpawnerManager spawnerManager;
    public GameObject textLoss;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(this);
    }

    private void Start()
    {
        if (imageTarget != null)
        {
            imageTarget.OnTargetStatusChanged += OnTargetStatusChanged;
            Debug.Log("Yes");
        }
        else
        {
            Debug.LogError("Target not found");
        }
    }

    public void AddScore()
    {
        score++;
        Debug.Log(score);
    }

    public void AddBonusScore()
    {
        // Play vine boom SFX here
        audioSource.PlayOneShot(audioBank.audioclips[9]);
        score += 10;
        Debug.Log("Bonus: " + score);
    }

    public int CurrentScore()
    {
        return score;
    }

    public int CurrentLife()
    {
        return life;
    }

    public void RemoveLife()
    {
        life--;
        if (life <= 0)
        {
            GameOver();
        }
    }

    public void RemoveAllLives()
    {
        // Play Deltarune Explosion SFX here
        audioSource.PlayOneShot(audioBank.audioclips[4]);
        life = 0;
        GameOver();
    }

    private void GameOver()
    {
        if (!isGameOver)
        {
            isGameOver = true;
            if (score >= highScore)
            {
                highScore = score;
            }
            // Do something
            //just in case
            ui.UpdateLife();
            PauseGame();
            ui.OnGameOver(true);
        }
    }
    public void RestartGame()
    {
        Debug.Log("Restarting");
        /*SceneManager.LoadScene(SceneManager.GetActiveScene().name);*/
        life = 3;
        score = 0;
        UnPause();
        ui.OnGameOver(false);
        isGameOver = false;
        Debug.Log("Restarted");
    }
    public void PauseGame()
    {
        Time.timeScale = 0;
    }
    public void UnPause()
    {
        Time.timeScale = 1;
    }

    public void PlaySound(int index)
    {
        audioSource.PlayOneShot(audioBank.audioclips[index], 1);
    }

    public void OnTargetStatusChanged(ObserverBehaviour target, TargetStatus targetStatus)
    {
        if (targetStatus.Status != Status.TRACKED)
        {
            OnTargetLost();
        }
        else
        {
            OnTargetFound();
        }

        Debug.Log("Status changed");
    }

    public void OnTargetLost()
    {
        spawnerManager.OnTargetLost();
        textLoss.SetActive(true);
        Debug.Log("Target lost");
    }

    public void OnTargetFound()
    {
        spawnerManager.OnTargetFound();
        textLoss.SetActive(false);
        Debug.Log("Target found");
    }
}
