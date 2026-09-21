using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _speed;
    [SerializeField] private float _timeToDestroy;
    private Vector3 _direction;
    private bool _isActive;

    public void Shoot(Vector3 direction)
    {
        _isActive = true;
        _direction = direction;
    }

    private void Update()
    {
        if (_isActive)
            transform.Translate(_direction * _speed * Time.deltaTime, Space.World);
        Destroy(gameObject,_timeToDestroy);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        if (enemy != null)
            enemy.TakeDamage(_damage);
    }
}
