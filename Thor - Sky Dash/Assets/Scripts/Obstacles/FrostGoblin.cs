using System.Collections;
using NUnit.Framework;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;

public class FrostGoblin : Obstacle
{
    private void Start()
    {
        horizontalDirection = transform.position.x > 3f ? -1 : 1;
    }
    
    public override void Move()
    {
        transform.position += new Vector3(DeltaX(), DeltaY(), 0);
        if (Mathf.Abs(transform.position.x) > 3f)
        {
            horizontalDirection = -horizontalDirection;
        }
    }
}
