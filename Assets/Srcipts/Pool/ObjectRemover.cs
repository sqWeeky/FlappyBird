using UnityEngine;

public class ObjectRemover : MonoBehaviour
{
    [SerializeField] private PoolEnemies _poolEnemies;
    [SerializeField] private PoolStars _poolStars;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Enemy enemy))
        {
            _poolEnemies.PutEnemy(enemy);            
        }

        if (other.TryGetComponent(out Star star))
        {
            _poolStars.PutStar(star);
        }
    }
}