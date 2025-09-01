using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public GameObject settingsPanel;
    public TMP_Text highScoreText;
    public TMP_Text totalCoinCount;
    public Slider musicSlider;
    public Slider effectsSlider;
    public AudioSource menuMusicSource;

    private void Start()
    {
        highScoreText.text = $"High Score: {PlayerPrefs.GetInt(PlayerPrefsKeys.highScore, 0)}";
        totalCoinCount.text = $"{PlayerPrefs.GetInt(PlayerPrefsKeys.coinCount, 0)}";
        musicSlider.value = PlayerPrefs.GetFloat(PlayerPrefsKeys.musicVol, 1);
        effectsSlider.value = PlayerPrefs.GetFloat(PlayerPrefsKeys.effectsVol, 1);
        menuMusicSource.volume = PlayerPrefs.GetFloat(PlayerPrefsKeys.musicVol, 1);
        settingsPanel.SetActive(false);
    }

    private void Update()
    {
        menuMusicSource.volume = PlayerPrefs.GetFloat(PlayerPrefsKeys.musicVol, 1);
    }

    public void SetMusicVolume(float volume)
    {
        PlayerPrefs.SetFloat(PlayerPrefsKeys.musicVol, volume);
    }

    public void SetEffectsVolume(float volume)
    {
        PlayerPrefs.SetFloat(PlayerPrefsKeys.effectsVol, volume);
    }
}