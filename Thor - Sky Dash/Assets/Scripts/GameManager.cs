using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int coinCount = 0;
    public float gameSpeed = 10f;
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }
    void Update()
    {
    }
}