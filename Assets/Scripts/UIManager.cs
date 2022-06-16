using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text lifeText;
    [SerializeField] private Text scoreText;
    [SerializeField] private GameObject gameOver;

    // Start is called before the first frame update
    void Start()
    {
        lifeText.text = "Lives: " + GameManager.instance.CurrentLife().ToString();
        scoreText.text = "Score: " + GameManager.instance.CurrentScore().ToString();
    }

    private void FixedUpdate()
    {
        lifeText.text = "Lives: " + GameManager.instance.CurrentLife().ToString();
        scoreText.text = "Score: " + GameManager.instance.CurrentScore().ToString();
    }
}
