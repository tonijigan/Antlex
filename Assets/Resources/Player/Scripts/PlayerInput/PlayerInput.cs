using PinePie.SimpleJoystick;
using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : UpdateObject
{
    [SerializeField] private JoystickController _joystickFire;
    [SerializeField] private JoystickController _joystickMove;

    private MoveInput _moveInput;
    private FlipInput _flipedInput;
    private SeetInput _seetInput;
    private FireInput _fireInput;

    private List<InputState> _inputStates = new();
    private Vector2 _direction = Vector2.right;

    public event Action<bool, Vector2> Fired;
    public event Action<Vector2> Moved;
    public event Action<Vector2> Fliped;
    public event Action Seeted;

    private void Awake()
    {
        _inputStates.Add(_moveInput = new(_joystickMove));
        _inputStates.Add(_flipedInput = new(_joystickFire));
        _inputStates.Add(_seetInput = new());
        _inputStates.Add(_fireInput = new());

        foreach (var input in _inputStates) input.Init(_inputStates);
    }

    public override void StartUpdate()
    {
        _direction = _flipedInput.Play(Fliped, _direction);
        _moveInput.Play(Moved);
        _seetInput.Play(Seeted);
        _fireInput.Play(Fired, _joystickFire, _direction);
    }

    //private void FixedUpdate()
    //{
    //    _moveInput.Play(Moved);
    //}
}