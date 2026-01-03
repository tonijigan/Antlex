using PinePie.SimpleJoystick;
using System;
using UnityEngine;

public class MoveInput : InputState
{
    private const string Horizontal = "Horizontal";
    private const string Vertical = "Vertical";

    private JoystickController _joystick;

    public MoveInput(JoystickController joystick) => _joystick = joystick;

    public void Play(Action<Vector2> action)
    {
        if (IsWork == false) return;

        action?.Invoke(new(_joystick.InputDirection.x, _joystick.InputDirection.y));
        action?.Invoke(new(Input.GetAxis(Horizontal), Input.GetAxis(Vertical)));
    }
}