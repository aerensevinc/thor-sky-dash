using TMPro;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public TMP_Text highScoreText;
    public TMP_Text totalCoinCount;
    private void Start()
    {
        highScoreText.text = $"High Score: {PlayerPrefs.GetInt(PlayerPrefsKeys.highScore, 0)}";
        totalCoinCount.text = $"{PlayerPrefs.GetInt(PlayerPrefsKeys.coinCount, 0)}";
    }
}