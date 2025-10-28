using TMPro;
using UnityEngine;

public class FPUIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highscoreText;
    public GameObject gameOverText;

    void Start()
    {
        if (scoreText == null)
        {
            Debug.LogError("Score Text is not assigned in the inspector.");
        }

        if (highscoreText == null)
        {
            Debug.LogError("Highscore Text is not assigned in the inspector.");
        }

        if (gameOverText == null)
        {
            Debug.LogError("Game Over Texts are not assigned in the inspector.");
        }

        gameOverText.SetActive(false);
    }

    // Update is called once per frame
    public void SetRestart()
    {
        gameOverText.SetActive(true);

    }

    public void UpdateScore(int score)
    {
        if (scoreText != null)
        {
            scoreText.text = score.ToString();
        }
    }

    public void UpdateHighscore(int score)
    {
        if (highscoreText != null)
        {
            highscoreText.text = $"Highscore: {score}";
        }
    }
}
