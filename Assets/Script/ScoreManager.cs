using UnityEngine;

public class ScoreManager : MonoBehaviour
{

    public static ScoreManager Instance; // Singleton for easy access

    public int score;
    public bool isPlayerAlive = true;

    [SerializeField] GameOver gameOver;
    [SerializeField] GameoverBackground gameoverBackground;
    void Awake()
    {
        // Ensure there's only one instance of ScoreManager
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddScore(int points)
    {
        score += points;
        Debug.Log("Score: " + score); // For debugging purposes
    }

    public int GetScore()
    {
        return score;
    }

    public void Dead() {
        isPlayerAlive = false;
        gameOver.gameOver();
        gameoverBackground.gameOver();
    }
}
