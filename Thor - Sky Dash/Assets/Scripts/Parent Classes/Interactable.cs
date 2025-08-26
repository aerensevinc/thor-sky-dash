using UnityEditor;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public float verticalSpeed;
    public float horizontalSpeed;
    protected float gameSpeed;
    protected int horizontalDirection = 1;

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
        transform.position += new Vector3(DeltaX(), DeltaY(), 0);
    }

    public virtual float DeltaX()
    {
        return gameSpeed * horizontalSpeed * horizontalDirection * Time.deltaTime;
    }
    
    public virtual float DeltaY()
    {
        return -gameSpeed * verticalSpeed * Time.deltaTime;
    }
    
    public abstract void Interact();
}