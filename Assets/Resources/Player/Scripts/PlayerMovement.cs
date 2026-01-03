using UnityEngine;

public class PlayerMovement
{
    private Rigidbody2D _rigidbody2D;
    private Vector2 _direction = Vector2.right;
    private Transform _transform;
    private float _speed;
    private float _clampPosotionY;
    private bool _isSeet = false;

    public PlayerMovement(Rigidbody2D rigidbody2D, Transform transform, float speed, float clampPosotionY)
    {
        _rigidbody2D = rigidbody2D;
        _transform = transform;
        _speed = speed;
        _clampPosotionY = clampPosotionY;
    }

    public void OnMove(Vector2 direction)
    {
        _direction = direction;
        _rigidbody2D.MovePosition(_rigidbody2D.position + _speed * Time.fixedDeltaTime * _direction);
    }

    public void OnFlip(Vector2 faceDirection)
    {
        if (faceDirection.x > 0)
            _transform.localScale = new(1, _transform.localScale.y);

        if (faceDirection.x < 0)
            _transform.localScale = new(-1, _transform.localScale.y);
    }

    public void OnSeet()
    {
        _isSeet = !_isSeet;
        if (_isSeet == true) _transform.localScale = new Vector2(_transform.localScale.x, _transform.localScale.y / 1.5f);
        if (_isSeet == false) _transform.localScale = new Vector2(_transform.localScale.x, 1);
    }
}