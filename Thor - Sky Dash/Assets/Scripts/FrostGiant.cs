using UnityEngine;

public class FrostGiant : Obstacle
{
    public Rigidbody2D frostGiantRigidBody;
    void Start()
    {
        frostGiantRigidBody.linearVelocityY = -fallSpeed * Time.deltaTime * 10f;
    }
}
