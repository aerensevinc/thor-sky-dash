using UnityEngine;

public class Background : MonoBehaviour
{
    public float speed;
    public float yPosition;

    private void FixedUpdate()
    {
        if (!GameManager.instance.IsGameOver())
        {
            float gameSpeed = GameManager.instance.gameSpeed;
            if (transform.position.y <= yPosition)
            {
                Teleport();
            }
            else
            {
                transform.position += gameSpeed * speed * Time.deltaTime * Vector3.down;
            }
        }
    }

    private void Teleport()
    {
        transform.position = 14 * Vector3.up;
    }
}