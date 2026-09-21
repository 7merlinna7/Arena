using UnityEngine;

public class Shooter :MonoBehaviour
{
    [SerializeField] Bullet _bullet;
    public void Shoot()
    {
        Bullet bullet = (Instantiate(_bullet, transform.position, Quaternion.identity, null)).GetComponent<Bullet>();
        bullet.Shoot(transform.forward);
    }
}
