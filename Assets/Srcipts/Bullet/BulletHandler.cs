using UnityEngine;

public class BulletHandler : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent(out Enemy enemy))
        {
            Destroy(enemy);
        }

        Destroy(gameObject);
    }
}