
using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveScript : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public float moveSpeed;
    public float y_position;
    private bool isMovingLeft;
    private bool isReverse;
    private float movement;

    private void Start()
    {
        isMovingLeft = false;
        isReverse = false;
        transform.position = new Vector3(0, -8, 0);
        spriteRenderer.sprite = SpriteManager.instance.currentSprite.upRight;
        spriteRenderer.color = Color.white;
        StartCoroutine(OpeningFlightRoutine());
    }

    private void Update()
    {
        transform.rotation = UnityEngine.Quaternion.Euler(0, 0, 0);
    }

    private void FixedUpdate()
    {
        if (GameManager.instance.gameStarted)
        {
            transform.position = new Vector3(transform.position.x, y_position, 0);
        }
        Vector3 deltaX = movement * moveSpeed * Time.deltaTime * Vector3.right;
        if (movement > 0)
        {
            spriteRenderer.sprite = SpriteManager.instance.currentSprite.right;
            isMovingLeft = false;
            if (transform.position.x < 3.2f)
            {
                transform.position += deltaX;
            }
        }
        else if (movement < 0)
        {
            spriteRenderer.sprite = SpriteManager.instance.currentSprite.left;
            isMovingLeft = true;
            if (transform.position.x > -3.2f)
            {
                transform.position += deltaX;
            }
        }
        else
        {
            if (isMovingLeft)
            {
                spriteRenderer.sprite = SpriteManager.instance.currentSprite.upLeft;
            }
            else
            {
                spriteRenderer.sprite = SpriteManager.instance.currentSprite.upRight;
            }
        }
    }

    private void Move(InputAction.CallbackContext context)
    {
        if (GameManager.instance.gameStarted && !GameManager.instance.gameOver)
        {
            movement = context.ReadValue<float>();
            if (isReverse)
            {
                movement = -movement;
            }
        }
        else
        {
            movement = 0;
        }
    }

    public void MakeThorFaster(float intensity, float duration)
    {
        StartCoroutine(ThorFasterRoutine(intensity, duration));
    }

    private IEnumerator ThorFasterRoutine(float intensity, float duration)
    {
        moveSpeed *= intensity;
        yield return new WaitForSeconds(duration);
        moveSpeed /= intensity;
    }

    public void ReverseControls()
    {
        isReverse = true;
    }

    public void UnReverseControls()
    {
        isReverse = false;
    }

    private IEnumerator OpeningFlightRoutine()
    {
        while (transform.position.y < y_position)
        {
            transform.position += 2 * Time.deltaTime * Vector3.up;
            yield return null;
        }
        GameManager.instance.gameStarted = true;
    }
}