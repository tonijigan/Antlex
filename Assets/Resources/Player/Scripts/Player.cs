using System;
using UnityEngine;

[RequireComponent(typeof(PlayerInput), typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [SerializeField] private int _health = 100;
    [SerializeField] private Weapon _weaponPrefab;


    public event Action Died;
    public event Action<int> TookDameged;

    private Rigidbody2D _rigidbody2D;
    private PlayerMovement _playerMovement;
    private PlayerInput _playerInput;

    private Weapon _currentWeapon = null;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _playerInput = GetComponent<PlayerInput>();
        _playerMovement = new(_rigidbody2D, transform, 20, 4.5f);
        _currentWeapon = _weaponPrefab;
    }

    private void OnEnable()
    {
        _playerInput.Fired += _currentWeapon.SetShootState;
        _playerInput.Fliped += _playerMovement.OnFlip;
        _playerInput.Moved += _playerMovement.OnMove;
        _playerInput.Seeted += _playerMovement.OnSeet;
    }

    private void OnDisable()
    {
        _playerInput.Fired -= _currentWeapon.SetShootState;
        _playerInput.Fliped -= _playerMovement.OnFlip;
        _playerInput.Moved -= _playerMovement.OnMove;
        _playerInput.Seeted -= _playerMovement.OnSeet;
    }

    public void SetState(int health, Weapon currentWeapon)
    {
        _health = health;
        _currentWeapon = currentWeapon;
    }

    private void TakeDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            _health = 0;
            Died?.Invoke();
        }

        TookDameged?.Invoke(_health);
    }
}