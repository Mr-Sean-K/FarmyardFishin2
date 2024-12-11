using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text livesText, scoreText, timerText, gameOverText;
    public GameObject gameOverPanel;
    public GameObject[] hearts; 

    public int lives = 3;
    public static int score = 0;
    float timer = 60f;
    bool gameOver = false;

    void Start()
    {
        UpdateUI();
        gameOverPanel.SetActive(false);
    }

    void Update()
    {
        if (gameOver) return;

        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = 0;
            EndGame();
        }
        UpdateUI();

        

    }

    void UpdateUI()
    {
        livesText.text = $"Lives: {lives}";
        scoreText.text = $"Score: {score}";
        timerText.text = $"Time: {Mathf.CeilToInt(timer)}s";
    }

  

  

    public void LoseLife()
    {
        if (gameOver) return;

        lives--;
        if (lives <= 0) 
        {
            lives = 0;
            EndGame();
        }
        UpdateUI();
    }

    void EndGame()
    {
        gameOver = true;
        gameOverPanel.SetActive(true);
        gameOverText.text = "Game Over";

        gameOverText.gameObject.SetActive(true);
        
        
    }
}