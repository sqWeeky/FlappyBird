using System;
using UnityEngine;

[RequireComponent(typeof(Shot))]
[RequireComponent(typeof(ShipMover))]
[RequireComponent(typeof(ScoreCounter))]
[RequireComponent(typeof(ShipCollisionHandler))]
public class Ship : MonoBehaviour
{
    private ShipMover _shipMover;
    private ScoreCounter _scoreCounter;
    private ShipCollisionHandler _handler;
    private Shot _shot;

    public event Action GameOver;

    private void Awake()
    {
        _shipMover = GetComponent<ShipMover>();
        _scoreCounter = GetComponent<ScoreCounter>();
        _handler = GetComponent<ShipCollisionHandler>();
        _shot = GetComponent<Shot>();
    }

    private void OnEnable()
    {
        _handler.CollisionDetected += ProcessCollision;
    }

    private void OnDisable()
    {
        _handler.CollisionDetected -= ProcessCollision;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            _shot.Activation();
        }
    }

    private void ProcessCollision(IInteractable interactable)
    {
        if (interactable is Star)
        {
            _scoreCounter.Add();
            
        }
        else if (interactable is Enemy)
        {
            GameOver?.Invoke();
        }
    }

    public void Reset()
    {
        _scoreCounter.Reset();
        _shipMover.Reset();
    }
}