
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
    public float moveSpeed;
    public float y_position;
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
        Vector3 changeX = movement * moveSpeed * Time.deltaTime * Vector3.right;
        if (movement > 0)
        {
            thorSprite.sprite = flyingRight;
            isMovingLeft = false;
            if (transform.position.x < 3.2f)
            {
                transform.position += changeX;
            }
        }
        else if (movement < 0)
        {
            thorSprite.sprite = flyingLeft;
            isMovingLeft = true;
            if (transform.position.x > -3.2f)
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
            transform.position +=  2 * Time.deltaTime * Vector3.up;
            yield return null;
        }
        GameManager.instance.gameStarted = true;
    }
}