using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager uInstance;

    [SerializeField] private Text lifeText;
    [SerializeField] private Text scoreText;
    [Header("Game Over")]
    public GameObject gameOver;
    [SerializeField] private Text totalScoreText;
    [SerializeField] private Text highScoreText;

    private int highScore = 0;

    private void Awake()
    {
        if (uInstance == null)
        {
            uInstance = null;
        }
        else if (uInstance != this)
        {
            Destroy(this);
        }
    }

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
        /*if (GameManager.uInstance.isGameOver)
        {
            OnGameOver(true);
        }*/
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
        if(score > highScore)
        {
            highScoreText.text = "High Score: " + score.ToString();
            //not sure if this will reset as well
            highScore = score;
        }
        totalScoreText.text = "Score: " + scoreText.text;
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
