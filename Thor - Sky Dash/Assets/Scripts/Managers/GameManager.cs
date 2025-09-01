using System.Collections;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject Thor;
    public SpriteRenderer thorSprite;
    [HideInInspector]
    public int highScore;
    [HideInInspector]
    public int coinCount;
    [HideInInspector]
    public int score;
    [HideInInspector]
    public int health;
    public int startHealth;
    public float gameSpeed;
    public float gameSpeedConstant;
    public float gameSpeedChangeRate;
    [HideInInspector]
    public GameState state;
    [HideInInspector]
    public bool isThorInvincible;
    [HideInInspector]
    public bool isOnCoolDown;

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
        AudioManager.instance.PlaySound("mainTheme", false);
        StartCoroutine(GameSpeedRoutine());
        thorSprite = Thor.GetComponent<SpriteRenderer>();
        coinCount = 0;
        score = 0;
        health = startHealth;
        state = GameState.PreGameStart;
        isThorInvincible = false;
        isOnCoolDown = false;
        highScore = PlayerPrefs.GetInt(PlayerPrefsKeys.highScore, 0);
    }

    private void Update()
    {
        switch (state)
        {
            case GameState.GameActive:
                if (health <= 0)
                {
                    state = GameState.PreGameOver;
                }
                break;

            case GameState.PreGameOver:
                AudioManager.instance.PlaySound("gameOver", false);
                GameOver();
                break;

            case GameState.GameOver:
                gameSpeed = 0;
                break;
        }
    }

    public bool IsGameOver()
    {
        return state == GameState.GameOver;
    }

    public bool IsGameActive()
    {
        return state == GameState.GameActive;
    }

    public void ActivateGame()
    {
        state = GameState.GameActive;
    }

    public void GameOver()
    {
        if (score > highScore)
        {
            ChangeHighScore(score);
            highScore = score;
        }
        gameSpeed = 0;
        state = GameState.GameOver;
        AddCoinsToAccount(coinCount);
        UIManager.instance.ActivateGameOver(highScore);
    }

    private void ChangeHighScore(int score)
    {
        PlayerPrefs.SetInt(PlayerPrefsKeys.highScore, score);
        PlayerPrefs.Save();
    }

    private int AddCoinsToAccount(int coinCount)
    {
        int prevCoinCount = PlayerPrefs.GetInt(PlayerPrefsKeys.coinCount, 0);
        int newCoinCount = prevCoinCount + coinCount;
        if (newCoinCount < 0)
        {
            return -1;
        }
        else
        {
            PlayerPrefs.SetInt(PlayerPrefsKeys.coinCount, newCoinCount);
            PlayerPrefs.Save();
            return newCoinCount;
        }
    }

    private IEnumerator GameSpeedRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(gameSpeedChangeRate);
            gameSpeed += gameSpeedConstant;
        }
    }

    public void ChangeGameSpeed(float intensity, float duration)
    {
        StartCoroutine(ChangeSpeedRoutine(intensity, duration));
        AudioManager.instance.SlowDownMusic(duration);
    }

    private IEnumerator ChangeSpeedRoutine(float intensity, float duration)
    {
        thorSprite.color = Color.softYellow;
        gameSpeed *= intensity;
        yield return new WaitForSeconds(duration);
        gameSpeed /= intensity;
        thorSprite.color = Color.white;
    }

    public void MakeThorInvincible(float duration)
    {
        StartCoroutine(InvincibleRoutine(duration));
    }

    private IEnumerator InvincibleRoutine(float duration)
    {
        StartCoroutine(ChangeColorRoutine(duration));
        isThorInvincible = true;
        yield return new WaitForSeconds(duration);
        isThorInvincible = false;
    }

    private IEnumerator ChangeColorRoutine(float duration)
    {
        float timer = 0f;
        while (timer < duration)
        {
            Color randomColor = new Color(Random.value, Random.value, Random.value);
            thorSprite.color = randomColor;
            yield return new WaitForSeconds(0.2f);
            timer += 0.2f;
        }
        thorSprite.color = Color.white;
    }

    public void StartCoolDown(float duration)
    {
        StartCoroutine(CoolDownRoutine(duration));
    }

    private IEnumerator CoolDownRoutine(float duration)
    {
        isOnCoolDown = true;
        thorSprite.color = Color.red;
        yield return new WaitForSeconds(duration);
        isOnCoolDown = false;
        if (IsGameActive())
        {
            thorSprite.color = Color.white;
        }
    }
}

public enum GameState
{
    PreGameStart,
    GameActive,
    PreGameOver,
    GameOver,
}

public class PlayerPrefsKeys
{
    public const string highScore = "HighScore";
    public const string coinCount = "CoinCount";
    public const string musicVol = "MusicVolume";
    public const string effectsVol = "EffectsVolume";
}