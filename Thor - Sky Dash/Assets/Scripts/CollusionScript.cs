using UnityEngine;

public class CollusionScript : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Abstract colison");
        if (collision.collider.GetComponent<FrostGiant>() != null)
        {
            Debug.Log("Collided with an obstacle!");
        }
    }
}
