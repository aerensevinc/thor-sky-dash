using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class SpriteManager : MonoBehaviour
{
    public static SpriteManager instance;
    public List<SpritePacket> spriteList;
    [HideInInspector]
    public SpritePacket currentSprite;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }

    private void Start()
    {
        currentSprite = spriteList[0];
    }
}

[System.Serializable]
public class SpritePacket
{
    public Sprite upRight;
    public Sprite upLeft;
    public Sprite right;
    public Sprite left;
}
