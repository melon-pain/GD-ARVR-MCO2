using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text lifeText;
    [SerializeField] private Text scoreText;
    [Header("Game Over")]
    public GameObject gameOver;
    [SerializeField] private Text totalScoreText;
    [SerializeField] private Text highScoreText;

    // Start is called before the first frame update
    void Start()
    {
        lifeText.text = "Lives: " + GameManager.instance.CurrentLife().ToString();
        scoreText.text = "Score: " + GameManager.instance.CurrentScore().ToString();
        gameOver.SetActive(false);
    }
    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            GameManager.instance.RemoveLife();
        }
        UpdateLife();
        UpdateScore();
    }
    public void UpdateScore()
    {
        scoreText.text = "Score: " + GameManager.instance.CurrentScore().ToString();
    }

    public void UpdateLife()
    {
        int life = GameManager.instance.CurrentLife();
        if(life <= 0)
        {
            life = 0;
        }
        lifeText.text = "Lives: " + life.ToString();
    }

    public void OnGameOver(bool condition)
    {
        gameOver.SetActive(condition);
        int score = GameManager.instance.CurrentScore();
        highScoreText.text = "High Score: " + GameManager.instance.highScore.ToString();
        totalScoreText.text = "Score: " + score.ToString();
    }

    public void OnMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void OnQuit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
