using System.Collections;
using UnityEngine;

public class ThorScript : MonoBehaviour
{
    public GameObject lightningBolt;

    public void ThrowLightning(float spawnDuration, float spawnRate)
    {
        StartCoroutine(SpawnLightningRoutine(spawnDuration, spawnRate));
    }

    private IEnumerator SpawnLightningRoutine(float spawnDuration, float spawnRate)
    {
        float timer = 0f;
        GameManager.instance.thorSprite.color = Color.cyan;
        while (timer < spawnDuration)
        {
            Vector3 spawnPosition = transform.position + Vector3.up * 1.2f;
            Instantiate(lightningBolt, spawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(spawnRate);
            timer += spawnRate;
        }
        GameManager.instance.thorSprite.color = Color.white;
    }
}