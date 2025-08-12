using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveScript : MonoBehaviour
{
    public SpriteRenderer thorSprite;
    public Sprite flyingUpRight;
    public Sprite flyingUpLeft;
    public Sprite flyingRight;
    public Sprite flyingLeft;
    public float moveSpeed = 5f;
    private bool isMovingLeft = false;
    private float movement;

    void Start()
    {
        thorSprite.sprite = flyingUpRight;
        thorSprite.color = Color.white;
    }

    void Update()
    {
        transform.position += Vector3.right * movement * moveSpeed * Time.deltaTime;
        if (movement > 0)
        {
            thorSprite.sprite = flyingRight;
            isMovingLeft = false;
        }
        else if (movement < 0)
        {
            thorSprite.sprite = flyingLeft;
            isMovingLeft = true;
        }
        else
        {
            thorSprite.sprite = isMovingLeft ? flyingUpLeft : flyingUpRight;
        }
    }
    public void Move(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<float>();
    }
}