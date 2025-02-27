using System.Collections;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObjectPool pipePool;  // Referencia al pool

    public float heightRange = 0.5f;
    public float maxTime = 1.75f;

    private float timer;

    void Start()
    {
        SpawnPipe();
    }

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

        GameObject newPipe = pipePool.GetInactiveGameObject(); // Saca una tubería del pool

        if (newPipe != null)
        {
            newPipe.transform.position = spawnPosition;
            newPipe.transform.rotation = Quaternion.identity;
            newPipe.SetActive(true);

            // Desactiva la tubería después de 15 segundos para devolverla al pool
            StartCoroutine(ReturnPipeAfterTime(newPipe, 15f));
        }
        else
        {
            Debug.LogWarning("No hay tuberías disponibles en el pool y no se puede expandir.");
        }
    }

    private IEnumerator ReturnPipeAfterTime(GameObject pipe, float delay)
    {
        yield return new WaitForSeconds(delay);
        pipe.SetActive(false); // En vez de destruirla, se desactiva para que el pool la reutilice
    }
}

