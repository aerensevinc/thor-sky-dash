
using System.Collections;
using Unity.VisualScripting;
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
    public float y_position = -5f;
    public float x_limit = 3f;
    public float epsilon = 0.01f;
    private bool isMovingLeft = false;
    private float movement;

    private void Start()
    {
        transform.position = new Vector3(0, -8, 0);
        thorSprite.sprite = flyingUpRight;
        thorSprite.color = Color.white;
        StartCoroutine(OpeningFlightRoutine());
    }
    private void FixedUpdate()
    {
        Vector3 changeX = Vector3.right * movement * moveSpeed * Time.deltaTime;
        if (movement > 0)
        {
            thorSprite.sprite = flyingRight;
            isMovingLeft = false;
            if (x_limit - transform.position.x > epsilon)
            {
                transform.position += changeX;
            }
        }
        else if (movement < 0)
        {
            thorSprite.sprite = flyingLeft;
            isMovingLeft = true;
            if (x_limit + transform.position.x > epsilon)
            {
                transform.position += changeX;
            }
        }
        else
        {
            thorSprite.sprite = isMovingLeft ? flyingUpLeft : flyingUpRight;
        }
    }
    private void Move(InputAction.CallbackContext context)
    {
        if (GameManager.instance.gameStarted)
        /*&& !GameManager.instance.gameOver)*/
        {
            movement = context.ReadValue<float>();
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
    private IEnumerator OpeningFlightRoutine()
    {
        while (transform.position.y < y_position)
        {
            transform.position += Vector3.up * Time.deltaTime * 2;
            yield return null;
        }
        GameManager.instance.gameStarted = true;
    }
}