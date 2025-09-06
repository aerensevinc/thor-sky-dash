using UnityEngine;

public class SlowGiant : FlyingSkeleton
{
    private void Update()
    {
        gameSpeed = GameManager.instance.gameSpeed;
        if (transform.position.y > 7.5f && SpawnManager.instance.isSpawningBoss)
        {
            Destroy(gameObject);
        }
    }
}