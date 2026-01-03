using System;
using UnityEngine;

public class SeetInput : InputState
{
    private float _startTime = 0.4f;
    private float _currentTime = 0;

    public SeetInput()
    {
        _currentTime = _startTime;
    }

    public void Play(Action action)
    {
        if (IsWork == false) return;

        if (Input.GetKeyDown(KeyCode.C) && _currentTime <= 0)
        {
            _currentTime = _startTime;
            action?.Invoke();
        }

        _currentTime -= Time.deltaTime;
    }
}