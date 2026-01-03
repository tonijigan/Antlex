using UnityEngine;

public class BulletContainer : UpdateObject
{
    private const int BulletCount = 30;

    [SerializeField] private Bullet _bulletPrefab;

    public Bullet[] Bullets { get; private set; }

    private void Start()
    {
        Bullets = new Bullet[BulletCount];

        for (int i = 0; i < Bullets.Length; i++)
        {
            Bullets[i] = Instantiate(_bulletPrefab, transform);
            Bullets[i].StopFly();
        }
    }

    public override void StartUpdate()
    {
        foreach (Bullet bullet in Bullets)
        {
            if (bullet.isActiveAndEnabled)
                bullet.StartFly();
        }
    }
}