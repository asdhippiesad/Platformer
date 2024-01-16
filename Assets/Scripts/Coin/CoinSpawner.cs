using System.Collections;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin _coinPrefab;
    [SerializeField] private Transform _coinSpawn;

    private float _minSpawnInterval = 5f;
    private float _maxSpawnInterval = 10f;

    private void Awake()
    {
        StartCoroutine(SpawnCoins());
    }

    private IEnumerator SpawnCoins()
    {
        float spawnInterval = Random.Range(_minSpawnInterval, _maxSpawnInterval);
        bool isWorking = true;

        while (isWorking)
        {
            var waitForSecond = new WaitForSeconds(spawnInterval);
            Instantiate(_coinPrefab, _coinSpawn.position, Quaternion.identity);
            yield return waitForSecond;
        }
    }
}
