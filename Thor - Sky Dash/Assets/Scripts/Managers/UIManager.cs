using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public GameObject gameOverPanel;
    public TMP_Text inGamePointText;
    public TMP_Text inGameCoinText;
    public TMP_Text inGameHealthText;
    public TMP_Text finalScoreText;
    public TMP_Text finalCoinText;
    public TMP_Text highestScoreText;
    private GameManager gameManager;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }

    private void Start()
    {
        gameOverPanel.SetActive(false);
        gameManager = GameManager.instance;
    }

    private void Update()
    {
        if (!gameManager.IsGameOver())
        {
            inGamePointText.text = $"Score: {gameManager.score}";
            inGameCoinText.text = $"{gameManager.coinCount}";
            inGameHealthText.text = $"{gameManager.health}";
        }
    }

    public void ActivateGameOver(int highScore)
    {
        gameOverPanel.SetActive(true);
        finalScoreText.text = $"Score: {gameManager.score}";
        finalCoinText.text = $"+{gameManager.coinCount}";
        highestScoreText.text = $"High Score: {highScore}";
    }
}