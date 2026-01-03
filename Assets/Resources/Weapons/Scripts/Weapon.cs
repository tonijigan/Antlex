using System.Linq;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Transform _bulletPointPosition;
    [SerializeField] private BulletContainer _bulletContainer;
    [SerializeField] private float _timeBetweenShoots = 0.5f;

    private Timer _timer;

    private void Start()
    {
        _timer = new(_timeBetweenShoots);
    }

    public void SetShootState(bool isShoot, Vector2 direction)
    {
        if (isShoot == false)
        {
            _timer.Reset();
            return;
        }

        if (_timer.IsTime)
        {
            var bullet = _bulletContainer.Bullets.Where(bullet => bullet.isActiveAndEnabled == false).FirstOrDefault();
            bullet.SetCurrentDirection(direction);
            bullet.transform.position = _bulletPointPosition.position;
            bullet.gameObject.SetActive(true);
        }
        _timer.TimeUp();
    }
}