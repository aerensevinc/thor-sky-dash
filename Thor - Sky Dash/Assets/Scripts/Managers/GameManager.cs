using System.Collections;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject Thor;
    public SpriteRenderer thorSprite;
    [HideInInspector]
    public int highestScore;
    [HideInInspector]
    public int coinCount;
    [HideInInspector]
    public int points;
    [HideInInspector]
    public int health;
    public int startHealth;
    public float gameSpeed;
    public float gameSpeedConstant;
    public float gameSpeedChangeRate;
    [HideInInspector]
    public bool gameStarted;
    [HideInInspector]
    public bool gameOver;
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
        StartCoroutine(GameSpeedRoutine());
        thorSprite = Thor.GetComponent<SpriteRenderer>();
        coinCount = 0;
        points = 0;
        health = startHealth;
        gameStarted = false;
        gameOver = false;
        isThorInvincible = false;
        isOnCoolDown = false;
        highestScore = PlayerPrefs.GetInt("HighestScore", 0);
    }

    private void Update()
    {
        if (health <= 0 && !gameOver)
        {
            gameOver = true;
            gameSpeed = 0;
            if (points > highestScore)
            {
                ChangeHighestScore(points);
                highestScore = points;
            }
            UIManager.instance.ActivateGameOver(highestScore);
        }
    }

    private void ChangeHighestScore(int score)
    {
        PlayerPrefs.SetInt("HighestScore", score);
        PlayerPrefs.Save();
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
    }

    private IEnumerator ChangeSpeedRoutine(float intensity, float duration)
    {
        gameSpeed *= intensity;
        yield return new WaitForSeconds(duration);
        gameSpeed /= intensity;
    }

    public void MakeThorInvincible(float duration)
    {
        StartCoroutine(InvincibleRoutine(duration));
    }

    private IEnumerator InvincibleRoutine(float duration)
    {
        isThorInvincible = true;
        thorSprite.color = Color.cyan;
        yield return new WaitForSeconds(duration);
        isThorInvincible = false;
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
        thorSprite.color = Color.white;
    }
}