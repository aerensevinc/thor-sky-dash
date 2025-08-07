using UnityEditor;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public float fallSpeed;
    protected Rigidbody2D rigidBody;
    protected virtual void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }
    protected virtual void FixedUpdate()
    {
        if (GameManager.instance == null) return;
        fallSpeed = GameManager.instance.gameSpeed;
        if (rigidBody != null)
        {
            rigidBody.linearVelocityY = -fallSpeed * Time.deltaTime * 10f;
        }
    }
    public abstract void Interact();
}