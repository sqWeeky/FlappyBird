using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;

    private float _timeDeath = 3f;

    private void Start()
    {
        StartCoroutine(Death());
    }

    private void Update()
    {
        transform.Translate(Vector2.right * _speed * Time.deltaTime);
    }

    private IEnumerator Death()
    {
        yield return new WaitForSeconds(_timeDeath);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out Enemy enemy))
        {
            enemy.Die();
            Destroy(gameObject);
        }
    }
}
