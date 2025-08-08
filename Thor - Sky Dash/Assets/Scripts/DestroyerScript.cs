using System.Diagnostics;
using UnityEngine;

public class DestroyerScript : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
    }
}