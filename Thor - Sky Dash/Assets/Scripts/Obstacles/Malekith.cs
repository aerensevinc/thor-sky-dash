using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class Malekith : Boss
{
    public GameObject aetherBlock;
    public float spawnRate;
    public float spawnDuration;
    private bool spawningOver;
    private void Start()
    {
        spawningOver = false;
        StartCoroutine(SpawnRoutine());
    }
    public override void Move()
    {
        /* sa buraları doldur baboli ben yatingo
        ya şu şeyleri Obstacle class ına al da rahatla allah rızası için
        changeX changeY felan filan
        50 kere yazdın şunu amk yeter la
        neyse iyi geceler. */
    }
    private IEnumerator SpawnRoutine()
    {
        float timer = 0f;
        while (timer < spawnDuration)
        {
            Instantiate(aetherBlock, Vector3.up * 6, quaternion.identity);
            yield return new WaitForSeconds(spawnRate);
            timer += spawnRate;
        }
        spawningOver = true;
    }
}
