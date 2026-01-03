using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMovement : UpdateObject
{
    private Rigidbody2D _rigidbody2D;
    private float _speed = 10;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public override void StartUpdate()
    {
        Move(Vector2.left);
    }

    private void Move(Vector2 direction)
    {
        _rigidbody2D.MovePosition(_rigidbody2D.position + _speed * Time.fixedDeltaTime * direction);
    }
}