using UnityEditor;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public float fallSpeed;
    protected virtual void FixedUpdate()
    {
        fallSpeed = GameManager.instance.gameSpeed;
        transform.position += Vector3.down * fallSpeed * Time.deltaTime;
    }
    public abstract void Interact();
}