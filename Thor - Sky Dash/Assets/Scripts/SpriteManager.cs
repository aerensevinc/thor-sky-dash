using UnityEngine;

public class SpriteManager : MonoBehaviour
{
    public static SpriteManager instance;
    public Sprite upRight;
    public Sprite upLeft;
    public Sprite right;
    public Sprite left;
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }
}
