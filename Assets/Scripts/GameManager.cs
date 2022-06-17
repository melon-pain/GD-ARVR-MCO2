using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField]
    private int score = 0;
    [SerializeField]
    private int life = 3;
    public bool isGameOver { get; private set; } = false;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(this);
    }

    public void AddScore()
    {
        score++;
        UIManager.instance.UpdateScore();
        Debug.Log(score);
    }

    public void AddBonusScore()
    {
        // Play vine boom SFX here
        score += 10;
        UIManager.instance.UpdateScore();
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
        UIManager.instance.UpdateLife();
        if (life <= 0)
        {
            GameOver();
        }
    }

    public void RemoveAllLives()
    {
        // Play Deltarune Explosion SFX here
        life = 0;
        GameOver();
    }

    private void GameOver()
    {
        if (!isGameOver)
        {
            isGameOver = true;
            // Do something
            PauseGame();
            UIManager.instance.OnGameOver(true);
        }
    }
    public void RestartGame()
    {
        UnPause();
        UIManager.instance.OnGameOver(false);
    }
    public void PauseGame()
    {
        Time.timeScale = 0;
    }
    public void UnPause()
    {
        Time.timeScale = 1;
    }
}
