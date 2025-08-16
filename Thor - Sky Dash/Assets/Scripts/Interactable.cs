using UnityEditor;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public float verticalSpeed = 1;
    private void FixedUpdate()
    {
        Move();
    }
    public virtual void Move()
    {
        float gameSpeed = GameManager.instance.gameSpeed;
        transform.position += gameSpeed * verticalSpeed * Time.deltaTime * Vector3.down;
    }
    public abstract void Interact();
}