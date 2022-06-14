using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    }

    public void AddBonusScore()
    {
        // Play vine boom SFX here
        score += 10;
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
        life = 0;
        GameOver();
    }

    private void GameOver()
    {
        if (!isGameOver)
        {
            isGameOver = true;
            // Do something
        }
    }
}
