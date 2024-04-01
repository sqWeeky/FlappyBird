using System.Collections;
using UnityEngine;

public class GeneratorEnemy : MonoBehaviour
{
    [SerializeField] private float _delay;
    [SerializeField] private float _lowerBound;
    [SerializeField] private float _upperBound;
    [SerializeField] private PoolEnemies _pool;

    private void Start()
    {
        StartCoroutine(GenerateObject());
    }

    private IEnumerator GenerateObject()
    {
        var wait = new WaitForSeconds(_delay);

        while (enabled)
        {
            Spawn();
            yield return wait;
        }
    }


    private void Spawn()
    {
        float spawnPositionY = Random.Range(_upperBound, _lowerBound);
        Vector3 spawnPoint = new Vector3(transform.position.x, spawnPositionY, transform.position.z);

        var newObject = _pool.GetEnemy();

        newObject.gameObject.SetActive(true);
        newObject.transform.position = spawnPoint;
    }
}