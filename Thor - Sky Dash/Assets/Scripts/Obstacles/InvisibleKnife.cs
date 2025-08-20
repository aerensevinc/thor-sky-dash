using UnityEngine;

public class InvisibleKnife : Obstacle
{
    public float invisiblePosition;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        gameSpeed = GameManager.instance.gameSpeed;
        if (transform.position.y <= invisiblePosition)
        {
            spriteRenderer.enabled = false;
        }
    }
}