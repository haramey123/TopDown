using UnityEngine;
using UnityEngine.SceneManagement;

public class FPGameManager : MonoBehaviour
{
    static FPGameManager gameManager;
    public static FPGameManager Instance { get { return gameManager; } }

    private int currentScore = 0;
    public bool isDead;

    FPUIManager uiManager;
    public FPUIManager UIManager { get { return uiManager; } }

    private void Awake()
    {
        gameManager = this;
        uiManager = FindObjectOfType<FPUIManager>();
    }

    private void Start()
    {
        UIManager.UpdateScore(0);
    }

    public void GameOver()
    {
        SaveHighScore();
        UIManager.SetRestart();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }    

    public void QuitGame()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void AddScore(int score)
    {
        currentScore += score;
        Debug.Log(currentScore);
        UIManager.UpdateScore(currentScore);
    }

    public void SaveHighScore()
    {
        int highscore = PlayerPrefs.GetInt("Highscore", 0); // ����� �ְ� ���� �ҷ�����. 0�� ����� ������ ��ȯ�Ǵ� �⺻��

        if (currentScore > highscore)
        {
            PlayerPrefs.SetInt("Highscore", currentScore); // �ְ� ���� ����
        }
        UIManager.UpdateHighscore(PlayerPrefs.GetInt("Highscore", 0));
    }

    public void ResetHighScore()
    {
        PlayerPrefs.SetInt("Highscore", 0);
    }
}
