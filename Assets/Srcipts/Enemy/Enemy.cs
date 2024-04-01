using UnityEngine;

public class Enemy : MonoBehaviour, IInteractable
{
    [SerializeField] private ShotEnemy _shot;

   

    public void Die()
    {
        FindObjectOfType<PoolEnemies>().PutEnemy(this);
    }

    public void OnGet()
    {
        _shot.OnGet();
    }

    public void OnReturn()
    {
        _shot.OnReturn();
    }
}