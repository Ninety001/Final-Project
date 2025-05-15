using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab;
    public float spawnInterval = 2f;
    public float xSpawnPos = 25f;
    public float ySpawnPos = 1f;

    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnCoin();
            timer = 0f;
        }
    }

    void SpawnCoin()
    {
        Vector3 spawnPos = new Vector3(xSpawnPos, ySpawnPos, 0);
        Instantiate(coinPrefab, spawnPos, Quaternion.identity);
    }
}