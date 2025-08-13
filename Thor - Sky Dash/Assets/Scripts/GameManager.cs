using System.Collections;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject Thor;
    private SpriteRenderer thorSprite;
    public TMP_Text pointText;
    public TMP_Text coinText;
    [HideInInspector]
    public int coinCount = 0;
    [HideInInspector]
    public int points = 0;
    public float gameSpeed = 10f;
    public float gameSpeedConstant = 0.2f;
    public float gameSpeedChangeRate = 50f;
    public bool gameStarted = false;
    public bool gameOver = false;
    public bool isThorInvincible = false;
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        thorSprite = Thor.GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        StartCoroutine(IncreaseSpeedRoutine(gameSpeedChangeRate, gameSpeedConstant));
        coinCount = 0;
        points = 0;
        gameStarted = false;
        gameOver = false;
    }
    private void Update()
    {
        coinText.text = $"Coins: {coinCount}";
        pointText.text = $"{points}";
        if (gameOver)
        {
            /*gameSpeed = 0;*/
            Debug.Log("Game Over!");
        }
    }
    private IEnumerator IncreaseSpeedRoutine(float changeRate, float increase)
    {
        while (true)
        {
            yield return new WaitForSeconds(changeRate);
            gameSpeed += increase;
        }
    }
    public void ChangeGameSpeed(float intensity, float duration)
    {
        StartCoroutine(GameSpeedRoutine(intensity, duration));
    }
    public void MakeThorInvincible(float duration)
    {
        StartCoroutine(InvincibleRoutine(duration));
    }
    private IEnumerator GameSpeedRoutine(float intensity, float duration)
    {
        gameSpeed *= intensity;
        yield return new WaitForSeconds(duration);
        gameSpeed /= intensity;
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