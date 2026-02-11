using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class InputControler : MonoBehaviour
{

    [SerializeField] private PlayerMovement playerMovement;
    private MainMovement _inputSystemActions;
    public Vector2 MovementDirection { get; private set; }
    private void Awake()
    {
        _inputSystemActions = new MainMovement();
    }
    private void FixedUpdate()
    {
        if (_inputSystemActions.Movement.enabled)
        {
            MovementDirection = _inputSystemActions.Movement.Move.ReadValue<Vector2>();
            playerMovement.Movement(MovementDirection);
        }
    }
    private void OnEnable()
    {
        _inputSystemActions.Enable();
    }

    private void OnDisable()
    {
        _inputSystemActions.Disable();
    }


}