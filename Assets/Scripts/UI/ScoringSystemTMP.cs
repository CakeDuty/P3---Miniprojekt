using UnityEngine;
using TMPro;

public class ScoringSystemTMP : MonoBehaviour
{
    public static ScoringSystemTMP Instance;

    public TMP_Text scoreText;
    private int score = 0;

    void Start()
    {
        // Singleton pattern to ensure only one instance of the scoring system exists
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        // Ensure that the scoreText is assigned in the Unity Editor
        if (scoreText == null)
        {
            Debug.LogError("ScoreText is not assigned!");
        }

        UpdateScoreUI();
    }

    public void AddScore(int points)
    {
        score += points;
        UpdateScoreUI();
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }
}
