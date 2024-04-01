using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolStars : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private Star _prefabStar;

    private Queue<Star> _poolStars;

    public IEnumerable<Star> PooledStars => _poolStars;

    private void Awake()
    {
        _poolStars = new Queue<Star>();
    }

    public Star GetStars()
    {
        if (_poolStars.Count == 0)
        {
            var star = Instantiate(_prefabStar);
            star.transform.parent = _container;

            return star;
        }

        return _poolStars.Dequeue();
    }

    public void PutStar(Star star)
    {
        _poolStars.Enqueue(star);
        star.gameObject.SetActive(false);
    }

    public void Reset()
    {
        _poolStars.Clear();
    }
}
