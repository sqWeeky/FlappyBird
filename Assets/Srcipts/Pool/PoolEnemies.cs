using System.Collections.Generic;
using UnityEngine;

public class PoolEnemies : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private Enemy _prefabEnemy;

    private Queue<Enemy> _poolEnemy;

    public IEnumerable<Enemy> PooledEnemes => _poolEnemy;

    private void Awake()
    {
        _poolEnemy = new Queue<Enemy>();
    }

    public Enemy GetEnemy()
    {
        if (_poolEnemy.Count == 0)
        {
            var enemy = Instantiate(_prefabEnemy);
            enemy.transform.parent = _container;

            enemy.gameObject.SetActive(true);
            enemy.OnGet();
            return enemy;
        }
        var enemy_1 = _poolEnemy.Dequeue();
        enemy_1.gameObject.SetActive(true);
        enemy_1.OnGet();
        return enemy_1;
    }

    public void PutEnemy(Enemy enemy)
    {
        enemy.OnReturn();
        _poolEnemy.Enqueue(enemy);
        enemy.gameObject.SetActive(false);
    }

    public void Reset()
    {
        _poolEnemy.Clear();
    }
}