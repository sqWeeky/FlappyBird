using System.Collections;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    [SerializeField] private float _speed;

    private float _timeDeath = 2f;

    private void Start()
    {
        StartCoroutine(Death());
    }

    private void Update()
    {
        transform.Translate(transform.right * _speed * Time.deltaTime);
    }

    private IEnumerator Death()
    {
        yield return new WaitForSeconds(_timeDeath);
        Destroy(gameObject);
    }
}