using System.Collections;
using UnityEngine;

public class ShotEnemy : MonoBehaviour
{
    [SerializeField] private Transform _shotPosition;
    [SerializeField] private BulletEnemy _bullet;
    [SerializeField] private float _timer = 1.5f;

    private Coroutine _coroutine;


    private IEnumerator Shoot()
    {
        var wait = new WaitForSeconds(_timer);

        while (enabled)
        {
            yield return wait;
            Debug.Log(gameObject.name);
            var bullet = Instantiate(_bullet, _shotPosition.position, _shotPosition.rotation);
        }
    }

    public void OnGet()
    {
        _coroutine = StartCoroutine(Shoot());
    }

    public void OnReturn()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);
    }
}