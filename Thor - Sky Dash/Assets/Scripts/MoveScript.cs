using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveScript : MonoBehaviour
{
    public SpriteRenderer SpriteRenderer;
    public Sprite flyingRight;
    public Sprite flyingLeft;
    public float moveSpeed = 5f;
    private bool isMovingLeft = true;
    private float movement;

    void Start()
    {
        SpriteRenderer.sprite = flyingLeft;
    }

    void Update()
    {
        transform.position += Vector3.right * movement * moveSpeed * Time.deltaTime;
        if (isMovingLeft && movement > 0)
        {
            SpriteRenderer.sprite = flyingRight;
            isMovingLeft = false;
        }
        else if (!isMovingLeft && movement < 0)
        {
            SpriteRenderer.sprite = flyingLeft;
            isMovingLeft = true;
        }
    }
    public void Move(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<float>();
    }
}