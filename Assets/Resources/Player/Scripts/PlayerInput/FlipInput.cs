using PinePie.SimpleJoystick;
using System;
using UnityEngine;

public class FlipInput : InputState
{
    private JoystickController _joystick;
    //private Vector2 _mousePosition; Нужное на потом все что за коментами
    // private bool _isMobile = false;

    public Vector2 Direction { get; private set; }

    public FlipInput(JoystickController joystick)
    {
        // _isMobile = Application.isMobilePlatform;
        _joystick = joystick;
    }

    public Vector2 Play(Action<Vector2> action, Vector2 direction)
    {
        if (IsWork == false) return direction;

        //#if UNITY_WEBGL && !UNITY_EDITOR

        // _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // if (_isMobile)
        //{
        if (_joystick.InputDirection.x > 0) direction = Vector2.right;
        if (_joystick.InputDirection.x < 0) direction = Vector2.left;
        // }
        //#endif
        //if (_mousePosition.x > transform.position.x)
        //    _direction = Vector2.right;

        //if (_mousePosition.x < transform.position.x)
        //    _direction = Vector2.left;

        action?.Invoke(Direction);
        return Direction = direction;

    }
}