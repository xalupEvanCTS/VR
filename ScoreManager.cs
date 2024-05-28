using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance; // Singleton instance
    public int score = 0;
    public Text scoreText;

    private void Awake()
    {
        // Ensure that there's only one instance of the ScoreManager
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Optional: Only needed if you need the score manager across different scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddScore(int pointsToAdd)
    {
        score += pointsToAdd;
        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }
}
