
using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveScript : MonoBehaviour
{
    public SpriteRenderer thorSprite;
    public Sprite[] sprites;
    public float moveSpeed;
    public float yPosition;
    private bool isMovingLeft;
    private bool isReverse;
    private float movement;

    private void Start()
    {
        isMovingLeft = false;
        isReverse = false;
        transform.position = new Vector3(0, -8, 0);
        thorSprite.sprite = sprites[(int)SpritePose.upRight];
        thorSprite.color = Color.white;
        StartCoroutine(OpeningFlightRoutine());
    }

    private void Update()
    {
        transform.rotation = UnityEngine.Quaternion.Euler(0, 0, 0);
        HandleTouchInput();
    }

    private void FixedUpdate()
    {
        if (GameManager.instance.IsGameActive())
        {
            transform.position = new Vector3(transform.position.x, yPosition, 0);
        }
        Vector3 deltaX = movement * moveSpeed * Time.deltaTime * Vector3.right;
        if (movement > 0)
        {
            thorSprite.sprite = sprites[(int)SpritePose.right];
            isMovingLeft = false;
            if (transform.position.x < 3.2f)
            {
                transform.position += deltaX;
            }
        }
        else if (movement < 0)
        {
            thorSprite.sprite = sprites[(int)SpritePose.left];
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
                thorSprite.sprite = sprites[(int)SpritePose.upLeft];
            }
            else
            {
                thorSprite.sprite = sprites[(int)SpritePose.upRight];
            }
        }
    }

    private void Move(InputAction.CallbackContext context)
    {
        if (GameManager.instance.IsGameActive())
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

    private void HandleTouchInput()
    {
        if (Touchscreen.current == null || !GameManager.instance.IsGameActive())
        {
            return;
        }

        var touch = Touchscreen.current.primaryTouch;
        if (touch.press.isPressed)
        {
            movement = touch.position.ReadValue().x < Screen.width / 2f ? -1f : 1f;
            if (isReverse)
            {
                movement = -movement;
            }
        }
        else if (touch.press.wasReleasedThisFrame)
        {
            movement = 0f;
        }
    }

    public void MakeThorFaster(float intensity, float duration)
    {
        StartCoroutine(ThorFasterRoutine(intensity, duration));
    }

    private IEnumerator ThorFasterRoutine(float intensity, float duration)
    {
        moveSpeed *= intensity;
        thorSprite.color = Color.yellowGreen;
        yield return new WaitForSeconds(duration);
        moveSpeed /= intensity;
        thorSprite.color = Color.white;
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
        while (transform.position.y < yPosition)
        {
            transform.position += 2 * Time.deltaTime * Vector3.up;
            yield return null;
        }
        GameManager.instance.ActivateGame();
    }

    private enum SpritePose
    {
        upRight = 0,
        upLeft = 1,
        right = 2,
        left = 3,
    }
}