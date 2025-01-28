using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipePrefab;

    public float heightRange = 0.5f;

    public float maxTime = 1.75f;

    private float timer;
    void Start()
    {
        SpawnPipe();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > maxTime)
        {
            SpawnPipe();
            timer = 0;
        }
    }

    public void SpawnPipe()
    {
        Vector3 spawnPosition = transform.position + new Vector3(0, Random.Range(-heightRange, heightRange));
        GameObject newPipe;
        newPipe = Instantiate(pipePrefab, spawnPosition, Quaternion.identity);
        Destroy(newPipe, 15f);
    }

}
