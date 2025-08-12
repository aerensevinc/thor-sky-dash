using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject Thor;
    private SpriteRenderer thorSprite;
    public int coinCount = 0;
    public float gameSpeed = 10f;
    public float gameSpeedConstant = 0.2f;
    public float gameSpeedChangeRate = 50f;
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
    }
    private void Update()
    {
        Debug.Log($"Game Speed: {gameSpeed}");
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