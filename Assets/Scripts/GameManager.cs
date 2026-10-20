using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int score { get; private set; }
    public int totalCoins;
    public bool isGameOver { get; private set; }

    void Awake()
    {
        if (Instance != null && Instance != this) { Destroy(gameObject); return; }
        Instance = this;
    }

    void Start()
    {
        totalCoins = FindObjectsOfType<Coin>().Length;
        Time.timeScale = 1f;
    }

    public void AddScore(int amount)
    {
        if (isGameOver) return;
        score += amount;
        UIManager.Instance.UpdateScore(score, totalCoins);

        if (score >= totalCoins)
            YouWin();
    }

    public void GameOver()
    {
        if (isGameOver) return;
        isGameOver = true;
        Time.timeScale = 0f;
        UIManager.Instance.ShowGameOver();
    }

    public void YouWin()
    {
        if (isGameOver) return;
        isGameOver = true;
        Time.timeScale = 0f;
        UIManager.Instance.ShowYouWin();
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }
}
