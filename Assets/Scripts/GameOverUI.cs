using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject winPanel;

    private GameManager gm;
    private bool waitingInput = false;

    private void Start()
    {
        if (gameOverPanel != null) gameOverPanel.SetActive(false);
        if (winPanel != null) winPanel.SetActive(false);

        gm = FindFirstObjectByType<GameManager>();
        if (gm != null)
            gm.GameEnded += OnGameEnded;
    }

    private void OnDestroy()
    {
        if (gm != null)
            gm.GameEnded -= OnGameEnded;
    }

    private void OnGameEnded(GameManager.EndState state)
    {
        
        if (gameOverPanel != null) gameOverPanel.SetActive(false);
        if (winPanel != null) winPanel.SetActive(false);

        if (state == GameManager.EndState.Lose && gameOverPanel != null)
            gameOverPanel.SetActive(true);

        if (state == GameManager.EndState.Win && winPanel != null)
            winPanel.SetActive(true);

        Time.timeScale = 0f;
        waitingInput = true;
    }

    private void Update()
    {
        if (!waitingInput) return;

        if (Input.anyKeyDown)
        {
            waitingInput = false;
            Time.timeScale = 1f;

            
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
