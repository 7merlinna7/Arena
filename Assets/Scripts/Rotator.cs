using UnityEngine;

public class Rotator 
{
    private float _rotationSpeed;
    private Quaternion _lookRotation;
    private Transform _characterTransform;

    public Rotator (float rotationSpeed,Transform characterTransform)
    {
        _rotationSpeed = rotationSpeed;
        _characterTransform = characterTransform;
    }

    public void ProcessRorateTo(Vector3 direction)
    {
        _lookRotation = Quaternion.LookRotation(direction);
            float step = _rotationSpeed * Time.deltaTime;
            _characterTransform.rotation = Quaternion.RotateTowards(_characterTransform.rotation, _lookRotation, step);
    }
}
