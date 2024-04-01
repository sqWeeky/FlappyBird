using UnityEngine;

public class ShipTracker : MonoBehaviour
{
    [SerializeField] private Ship _bird;
    [SerializeField] private float _xOffset;

    private void Update()
    {
        var position = transform.position;
        position.x = _bird.transform.position.x + _xOffset;
        transform.position = position;
    }
}