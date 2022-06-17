using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField] private Text lifeText;
    [SerializeField] private Text scoreText;
    [SerializeField] private GameObject gameOver;

    private void Awake()
    {
        if(instance == null)
        {
            instance = null;
        }
        else if(instance != this)
        {
            Destroy(this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        lifeText.text = "Lives: " + GameManager.instance.CurrentLife().ToString();
        scoreText.text = "Score: " + GameManager.instance.CurrentScore().ToString();
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
}
