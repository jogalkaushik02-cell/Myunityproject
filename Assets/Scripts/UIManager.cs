using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    public Text scoreText;
    public GameObject gameOverPanel;
    public GameObject youWinPanel;
    public Text finalScoreText;

    void Awake()
    {
        if (Instance != null && Instance != this) { Destroy(gameObject); return; }
        Instance = this;
    }

    void Start()
    {
        if (gameOverPanel) gameOverPanel.SetActive(false);
        if (youWinPanel) youWinPanel.SetActive(false);
    }

    public void UpdateScore(int score, int total)
    {
        if (scoreText) scoreText.text = $"Coins: {score} / {total}";
    }

    public void ShowGameOver()
    {
        if (gameOverPanel) gameOverPanel.SetActive(true);
        if (finalScoreText) finalScoreText.text = $"Score: {GameManager.Instance.score}";
    }

    public void ShowYouWin()
    {
        if (youWinPanel) youWinPanel.SetActive(true);
        if (finalScoreText) finalScoreText.text = $"Score: {GameManager.Instance.score}";
    }

    public void OnRestartButton()
    {
        GameManager.Instance.Restart();
    }
}
