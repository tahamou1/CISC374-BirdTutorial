using UnityEngine;
using UnityEngine.UI;
//.SceneManagement;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int playerScore;

    public int highScore;
    public Text scoreText; 
    public GameObject gameOverScreen;

    public Text highScoreText;

    public GameObject titleScreen;

    void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        UpdateHighScoreText();
        Time.timeScale = 0;

    }





    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd){
        playerScore = playerScore + scoreToAdd;
        scoreText.text = playerScore.ToString();

        if (playerScore > highScore)
        {
            highScore = playerScore;
            PlayerPrefs.SetInt("HighScore", highScore); // Save high score
            PlayerPrefs.Save();
            UpdateHighScoreText(); // Update 
        }
    }

    public void restartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    } 

    public void startGame()
    {
        titleScreen.SetActive(false); 
        Time.timeScale = 1; 
    }

    public void gameOver(){
        gameOverScreen.SetActive(true);
    } 

    private void UpdateHighScoreText()
    {
        if (highScoreText != null)
        {
            highScoreText.text = "High Score: " + highScore.ToString();
        }
    }
    
}
