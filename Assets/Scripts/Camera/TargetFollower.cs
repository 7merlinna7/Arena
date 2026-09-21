using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetFollower : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Vector3 cameraOffset;

    private Vector3 _currentPosition;
    private Transform _target;

    public void Initialize(Transform target)
    {
        _target = target;
    }

    private void Update()
    {
        _currentPosition = new Vector3(_target.position.x, cameraOffset.y, cameraOffset.z);
        transform.position = _currentPosition;
    }
}
