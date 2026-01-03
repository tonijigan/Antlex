using PinePie.SimpleJoystick;
using System;
using UnityEngine;

public class FireInput : InputState
{
    public void Play(Action<bool, Vector2> action, JoystickController joystick, Vector2 direction)
    {
        if (joystick.InputDirection.x > 0 || joystick.InputDirection.x < 0) action?.Invoke(true, direction);
        else action?.Invoke(false, direction);
    }
}