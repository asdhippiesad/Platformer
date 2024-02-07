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
    private float _randomSpawnPoint = 6f;

    private void Start()
    {
        _point = new Transform[_pointSpawn.childCount];

        for (int i = 0; i < _pointSpawn.childCount; i++)
            _point[i] = _pointSpawn.GetChild(i);

        _coroutine = StartCoroutine(SpawnItems());
    }

    private IEnumerator SpawnItems()
    {
        int maxCount = 5;

        do
        {
            float spawninterval = Random.Range(_minSpawnInterval, _maxSpawnInterval);
            int randomIndex = Random.Range(0, _object.Length);
            yield return new WaitForSeconds(spawninterval);

            for (int i = 0; i < _point.Length; i++)
            {
                Vector3 spawnPosition = new Vector3(_point[i].position.x, Random.Range(0, _randomSpawnPoint), _point[i].position.z);
                Instantiate(_object[randomIndex], spawnPosition, Quaternion.identity);
            }

            maxCount--;

        } while (maxCount > 0);
    }
}