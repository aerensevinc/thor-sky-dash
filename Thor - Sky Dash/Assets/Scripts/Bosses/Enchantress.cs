using System.Collections;
using UnityEngine;

public class Enchantress : SpawnerBoss
{
    private float hauntThorDuration;
    private bool startedHaunting;

    private void Start()
    {
        hauntThorDuration = Random.Range(3f, 6f);
        startedHaunting = false;
    }

    public override void MoveWhileEntry()
    {
        if (Mathf.Abs(transform.position.x) > 1f)
        {
            horizontalDirection = -horizontalDirection;
        }
        transform.position += new Vector3(DeltaX(), DeltaY(), 0);
    }

    public override void MoveWhileSpawning()
    {
        float thor_x = GameManager.instance.Thor.transform.position.x;
        if (Mathf.Abs(transform.position.x - thor_x) < 0.1f)
        {
            horizontalDirection = 0;
        }
        else
        {
            horizontalDirection = transform.position.x > thor_x ? -1 : 1;
        }
        transform.position += Vector3.right * DeltaX();
    }

    public override void MoveWhileExit()
    {
        float thor_x = GameManager.instance.Thor.transform.position.x;
        if (Mathf.Abs(transform.position.x - thor_x) < 0.1f)
        {
            horizontalDirection = 0;
        }
        else
        {
            horizontalDirection = transform.position.x > thor_x ? -1 : 1;
        }
        if (transform.position.y <= -1.3f && !startedHaunting)
        {
            StartCoroutine(StopRoutine(verticalSpeed));
            startedHaunting = true;
        }
        else
        {
            transform.position += new Vector3(0.4f * DeltaX(), 2f * DeltaY());
        }
    }

    private IEnumerator StopRoutine(float oldSpeed)
    {
        verticalSpeed = 0;
        yield return new WaitForSeconds(hauntThorDuration);
        verticalSpeed = oldSpeed;
    }

    protected override Vector3 SpawnPosition()
    {
        return transform.position + Vector3.down;
    }
}
