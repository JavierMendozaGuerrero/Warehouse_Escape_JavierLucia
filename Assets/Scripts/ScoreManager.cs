using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    public int Score { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        Score = 0;
    }

    public void AddScore(int amount)
    {
        Score += amount;
        FindFirstObjectByType<ScoreUI>()?.UpdateScore(Score);

    }

    public void ResetScore()
    {
        Score = 0;
        FindFirstObjectByType<ScoreUI>()?.UpdateScore(Score);

    }
}
