using UnityEngine;

public class InvisibleKnife : Obstacle
{
    public float invisiblePosition;
    private bool isInvisible;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        isInvisible = false;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        gameSpeed = GameManager.instance.gameSpeed;
        if (!isInvisible && transform.position.y <= invisiblePosition)
        {
            spriteRenderer.enabled = false;
            isInvisible = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        spriteRenderer.enabled = true;
    }
}