using TMPro;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public TMP_Text highScoreText;

    private void Start()
    {
        highScoreText.text = $"Highest Score: {PlayerPrefs.GetInt("HighestScore", 0)}";
    }
}
