using UnityEditor;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public float verticalSpeed = 1;
    protected float gameSpeed;
    private void Update()
    {
        gameSpeed = GameManager.instance.gameSpeed;
    }
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