using UnityEditor;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public float speedConstant = 1;
    protected float gameSpeed;
    void FixedUpdate()
    {
        Move();
    }
    public virtual void Move()
    {
        gameSpeed = GameManager.instance.gameSpeed;
        transform.position += Vector3.down * gameSpeed * speedConstant * Time.deltaTime;
    }
    public abstract void Interact();
}