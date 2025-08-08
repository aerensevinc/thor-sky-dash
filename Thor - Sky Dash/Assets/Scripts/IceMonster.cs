using System.Collections;
using JetBrains.Annotations;
using UnityEngine;

public class IceMonster : MonoBehaviour
{
    public GameObject IceSpike;
    public float spawnRate = 2f;
    public float y_position = 2.5f;
    private float timer = 0;
    private bool inPosition = false;

    void Start()
    {
        StartCoroutine(FlyDownRoutine(y_position));
    }
    void Update()
    {
        if (inPosition)
        {
            StartCoroutine(SpawnRoutine());
            inPosition = false;
        }
    }

    private IEnumerator SpawnRoutine()
    {
        Debug.Log("Routine started!");
        while (true)
        {
            Instantiate(IceSpike, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(spawnRate);
        }
    }
    private IEnumerator FlyDownRoutine(float y_position)
    {
        while (transform.position.y > y_position)
        {
            transform.position += Vector3.down * GameManager.instance.gameSpeed * Time.deltaTime;
            yield return null;
        }
        inPosition = true;
    }
}