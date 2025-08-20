using System.Collections;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject Thor;
    public SpriteRenderer thorSprite;
    public TMP_Text pointText;
    public TMP_Text coinText;
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
    }

    private void Update()
    {
        coinText.text = $"Coins: {coinCount}";
        pointText.text = $"{points}";
        if (health <= 0)
        {
            gameOver = true;
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
        StartCoroutine(SpeedChangeRoutine(intensity, duration));
    }

    private IEnumerator SpeedChangeRoutine(float intensity, float duration)
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
        thorSprite.color = Color.cyan;
        isThorInvincible = true;
        yield return new WaitForSeconds(duration);
        isThorInvincible = false;
        thorSprite.color = Color.white;
    }
}