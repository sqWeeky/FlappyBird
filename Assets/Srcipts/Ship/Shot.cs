using System.Collections;
using UnityEngine;

public class Shot : MonoBehaviour
{
    [SerializeField] private Transform _shotPosition;
    [SerializeField] private Bullet _bullet;
    [SerializeField] private float _timer = 3f;

    private bool _canShot = true;

    public void Activation()
    {
        if (_canShot)
        {
            StartCoroutine(Shoot());
        }
    }

    protected IEnumerator Shoot()
    {
        _canShot = false;
        Instantiate(_bullet, _shotPosition.position, _shotPosition.rotation);
        yield return new WaitForSeconds(_timer);
        _canShot = true;
    }
}
