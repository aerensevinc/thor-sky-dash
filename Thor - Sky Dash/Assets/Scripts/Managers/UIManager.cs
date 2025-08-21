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
    public TMP_Text finalPointText;
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
        if (!gameManager.gameOver)
        {
            inGamePointText.text = $"Points: {gameManager.points}";
            inGameCoinText.text = $"Coins: {gameManager.coinCount}";
            inGameHealthText.text = $"Health: {gameManager.health}";
        }
    }

    public void ActivateGameOver(int highestScore)
    {
        gameOverPanel.SetActive(true);
        finalPointText.text = $"Points: {gameManager.points}";
        finalCoinText.text = $"Coins: {gameManager.coinCount}";
        highestScoreText.text = $"Highest Score: {highestScore}";
    }
}
