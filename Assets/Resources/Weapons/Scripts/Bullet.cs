using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _speed;

    private Vector2 _startPosition;
    private Transform _transform;
    private Vector2 _direction = Vector2.right;
    private Timer _timer = new(1f);

    private void Awake()
    {
        _transform = transform;
        _startPosition = _transform.position;
    }

    public void StartFly()
    {
        _transform.Translate(_speed * Time.deltaTime * _direction);

        _timer.TimeUp();

        if (_timer.IsTime == true)
        {
            StopFly();
            _transform.position = _startPosition;
        }
    }

    public void SetCurrentDirection(Vector2 currentDirection)
    {
        _direction = currentDirection;
    }

    public void StopFly()
    {
        _timer.Reset();
        gameObject.SetActive(false);
    }
}