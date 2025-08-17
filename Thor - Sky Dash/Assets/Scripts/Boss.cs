using System.Collections;
using UnityEngine;

public abstract class Boss : Obstacle
{
    public float waitTime;
    private void Awake()
    {
        SpawnManager.instance.StopSpawning();
        StartCoroutine(WaitRoutine());
    }
    private void OnDestroy()
    {
        GameManager gameManager = GameManager.instance;
        SpawnManager spawnManager = SpawnManager.instance;
        if (gameManager != null && spawnManager != null)/*!gameManager.gameOver)*/
        {
            spawnManager.StartSpawning();
        }
    }
    private IEnumerator WaitRoutine()
    {
        float oldVerticalSpeed = verticalSpeed;
        float oldHorizontalSpeed = horizontalSpeed;
        verticalSpeed = 0;
        horizontalSpeed = 0;
        yield return new WaitForSeconds(waitTime);
        verticalSpeed = oldVerticalSpeed;
        horizontalSpeed = oldHorizontalSpeed;
    }
}