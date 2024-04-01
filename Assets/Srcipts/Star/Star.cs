using UnityEngine;

public class Star : MonoBehaviour, IInteractable
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out Ship ship))
        {
            Destroy(gameObject);
        }
    }
}