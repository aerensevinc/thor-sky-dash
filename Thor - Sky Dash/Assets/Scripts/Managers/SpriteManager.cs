using System;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using Unity.VisualScripting;
using UnityEditor.U2D.Animation;
using UnityEngine;

public class SpriteManager : MonoBehaviour
{
    public static SpriteManager instance;
    public List<SpritePacket> spriteList;
    [HideInInspector]
    public SpritePacket currentSprite;

    public static void ChangeSprite(SpriteName spriteName)
    {
        instance.currentSprite = instance.spriteList[(int)spriteName];
    }

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

public enum SpriteName
{
    normal = 0,
    lokified = 1,
    invincible = 2,
    fast = 3,
    dead = 4,
}
