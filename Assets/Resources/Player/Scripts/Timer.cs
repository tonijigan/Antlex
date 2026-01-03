using UnityEngine;

public class Timer
{
    private float _witeTime;
    private float _currentTime;
    public bool IsTime { get; private set; } = true;

    public Timer(float witeTime)
    {
        _witeTime = witeTime;
        _currentTime = witeTime;
    }

    public void Reset()
    {
        IsTime = true;
        _currentTime = _witeTime;
    }

    public void TimeUp()
    {
        IsTime = false;
        _currentTime -= Time.deltaTime;

        if (_currentTime < 0)
        {
            _currentTime = _witeTime;
            IsTime = true;
        }
    }
}