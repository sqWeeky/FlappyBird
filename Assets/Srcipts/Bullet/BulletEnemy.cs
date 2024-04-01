using System.Collections;
using UnityEngine;

public class BulletEnemy : MonoBehaviour, IInteractable
{
    [SerializeField] private float _speed;

    private float _timeDeath = 5f;

    private void Start()
    {
        StartCoroutine(ActivateDeath());
    }

    private void Update()
    {
        transform.Translate(transform.right * _speed * Time.deltaTime);
    }

    private IEnumerator ActivateDeath()
    {
        yield return new WaitForSeconds(_timeDeath);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}