using System.Collections;
using UnityEngine;

public class ItemsSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] _object;
    [SerializeField] private Transform _pointSpawn;

    private Transform[] _point;
    private Coroutine _coroutine;

    private int _minSpawnInterval = 1;
    private int _maxSpawnInterval = 5;
    private float _randomSpawnObject = 7f;

    private void Awake()
    {
        _point = new Transform[_pointSpawn.childCount];

        for (int i = 0; i < _pointSpawn.childCount; i++)
            _point[i] = _pointSpawn.GetChild(i);

        _coroutine = StartCoroutine(SpawnCoins());
    }

    private IEnumerator SpawnCoins()
    {
        int maxCount = 5;

        do
        {
            float spawninterval = Random.Range(_minSpawnInterval, _maxSpawnInterval);
            int randomIndex = Random.Range(0, _object.Length);
            var waitForSeconds = new WaitForSeconds(spawninterval);
            yield return waitForSeconds;

            for (int i = 0; i < _point.Length; i++)
            {
                Vector3 spawnPosition = new Vector3(_point[i].position.y, Random.Range(0f, _randomSpawnObject), _point[i].position.z);
                Instantiate(_object[randomIndex], spawnPosition, Quaternion.identity);
            }

            maxCount--;

        } while (maxCount > 0);

    }
}