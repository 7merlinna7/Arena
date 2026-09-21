using UnityEngine;

public class Mover 
{
    private float _speed;
    private Transform _characterTransform;

    public Mover(float speed, Transform characterTransform)
    {
        _speed = speed;
        _characterTransform = characterTransform;
    }

    public void Move(Vector3 direction)
    {
        Vector3 normalazedMoveDirection = direction.normalized;
        ProcessMoveToTarget(normalazedMoveDirection);
    }

    public Vector3 GetDirectionToTarget(Vector3 currentTarget) => currentTarget - _characterTransform.position;

    public void ProcessMoveToTarget(Vector3 direction) => _characterTransform.Translate(direction * _speed * Time.deltaTime, Space.World);


}
