using System.Collections;
using UnityEngine;

public class ShotEnemy : MonoBehaviour
{
    [SerializeField] private Transform _shotPosition;
    [SerializeField] private BulletEnemy _bullet;
    [SerializeField] private float _timer = 1.5f;

    private Coroutine _coroutine;

    private void Start()
    {
        
        gameObject.name = "Enemy" + Random.Range(0, 1000000);
    }

    private IEnumerator Shoot()
    {
        Debug.Log(gameObject.name);
        Instantiate(_bullet, _shotPosition.position, _shotPosition.rotation);
        yield return new WaitForSeconds(_timer);
        StartCoroutine(Shoot());
    }

    public void OnGet()
    {
        _coroutine = StartCoroutine(Shoot());
    }

    public void OnReturn()
    {
        StopCoroutine(_coroutine);
    }
}