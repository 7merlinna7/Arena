using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour,IDamageble
{
    private const float _minDirectionValue = -1f;
    private const float _maxDirectionValue = 1f;

    private Mover _mover;
    private Rotator _rotator;
    private Health _health;
    private float _timeToChangeDirection;
    private int _damage;

    private Vector3 _currentDirection;
    private bool _isMoving;

    public bool IsActive;
    public bool IsDead => _health.IsDead;
    public void Initialize(Mover mover, Rotator rotator,Health health,float timeToChangeDirection,int damage)
    {
        _mover = mover;
        _rotator = rotator;
        _health = health;
        _timeToChangeDirection = timeToChangeDirection;
        _damage = damage;
        IsActive = true;
    }

    private void Update()
    {
        if (IsActive==false)
            return;

        if (_isMoving == false)
        StartCoroutine(StartMove());

        Move(_currentDirection);
    }

    public void Stop() => IsActive = false;

    public void TakeDamage(int damage) => _health.TakeDamage(damage);

    private void Move(Vector3 direction)
    {
        _rotator.ProcessRorateTo(direction);
        _mover.Move(direction);
    }

    private IEnumerator StartMove()
    {
        _isMoving = true;
        _currentDirection = new Vector3(Random.Range(_minDirectionValue, _maxDirectionValue), 0, Random.Range(_minDirectionValue, _maxDirectionValue));
        yield return new WaitForSeconds(_timeToChangeDirection);
        _isMoving = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
        if (player != null)
            player.TakeDamage(_damage);
    }
}
