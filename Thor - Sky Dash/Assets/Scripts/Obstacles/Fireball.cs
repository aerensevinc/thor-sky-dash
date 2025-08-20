using UnityEngine;

public class Fireball : Obstacle
{
    private void Start()
    {
        float sizeConstant = Random.Range(0.15f, 0.25f);
        transform.localScale = new Vector3(sizeConstant, sizeConstant, 0);
    }
}