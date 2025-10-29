using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    static UIManager uiManager;
    public static UIManager Instance { get { return uiManager; } }

    public TextMeshProUGUI highscoreText;

    private void Awake()
    {
        uiManager = this;
    }

    void Start()
    {
        if (highscoreText == null)
        {
            Debug.LogError("Highscore Text is not assigned in the inspector.");
        }
        DisableHighscore();
    }

    public void EnableHighscore(int score)
    {
        if (highscoreText != null)
        {
            highscoreText.text = $"Highscore: {score}";
            highscoreText.gameObject.SetActive(true);
        }
    }

    public void DisableHighscore()
    {
        if (highscoreText != null)
            highscoreText.gameObject.SetActive(false);
    }
}
