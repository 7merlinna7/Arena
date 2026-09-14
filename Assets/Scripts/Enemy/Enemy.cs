using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    private const float _minDirectionValue = -1f;
    private const float _maxDirectionValue = 1f;

    private Mover _mover;
    private Rotator _rotator;

    private float _timeToChangeDirection;

    private Vector3 _currentDirection;

    public bool IsMoving { get; private set; }
    public bool IsActive { get; private set; }

    public int Damage { get; private set; }

    public void Initialize(Mover mover, Rotator rotator,float timeToChangeDirection)
    {
        _mover = mover;
        _rotator = rotator;
        _timeToChangeDirection = timeToChangeDirection;

        IsActive = true;
    }

    private void Update()
    {
        if (IsActive == false)
            return;

        if (IsMoving==false)
        StartCoroutine(StartMove());

        Move(_currentDirection);
    }

    public void Move(Vector3 direction)
    {
        _rotator.ProcessRorateTo(direction);
        _mover.Move(direction);
    }

    private IEnumerator StartMove()
    {
        IsMoving = true;
        _currentDirection = new Vector3(Random.Range(_minDirectionValue, _maxDirectionValue), 0, Random.Range(_minDirectionValue, _maxDirectionValue));
        yield return new WaitForSeconds(_timeToChangeDirection);
        IsMoving = false;
    }
}
