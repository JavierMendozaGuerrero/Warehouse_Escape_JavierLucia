using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;

    private void Start()
    {
        
        int current = (ScoreManager.Instance != null) ? ScoreManager.Instance.Score : 0;
        UpdateScore(current);
    }

    public void UpdateScore(int value)
    {
        scoreText.text = "Score: " + value;
    }
}
