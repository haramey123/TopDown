using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public GameObject restartText;

    void Start()
    {
        if (scoreText == null)
        {
            Debug.LogError("Score Text is not assigned in the inspector.");
        }

        if (restartText == null)
        {
            Debug.LogError("Restart Text is not assigned in the inspector.");
        }

        restartText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    public void SetRestart()
    {
        restartText.gameObject.SetActive(true);

    }

    public void UpdateScore(int score)
    {
        if (scoreText != null)
        {
            scoreText.text = score.ToString();
        }
    }
}
