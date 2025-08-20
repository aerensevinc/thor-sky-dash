using System.Collections;
using UnityEngine;

public class Boss : Obstacle
{
    public float waitTime;
    public float yPosition;
    private void Awake()
    {
        SpawnManager.instance.StopSpawning();
        StartCoroutine(WaitRoutine());
    }
    private void OnDestroy()
    {
        WhenDestroyed();
        GameManager gameManager = GameManager.instance;
        SpawnManager spawnManager = SpawnManager.instance;
        if (gameManager != null && spawnManager != null)/*!gameManager.gameOver)*/
        {
            spawnManager.StartSpawning();
        }
    }
    protected virtual void WhenDestroyed()
    {
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