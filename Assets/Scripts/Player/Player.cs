using UnityEngine;

public class Player : MonoBehaviour,IDamageble
{
    private Mover _mover;
    private Rotator _rotator;

    public int Damage {  get; private set; }
    public bool CanMoving { get; private set; } = true;

    public void Initialize(Mover mover,Rotator rotator)
    {
        _mover = mover;
        _rotator = rotator;
    }

    public void Move(Vector3 direction)
    {
        if(CanMoving == false)
            return;

        _rotator.ProcessRorateTo(direction);
        _mover.Move(direction);
    }

    public void TakeDamage(int damage)
    {

    }

    public void Shoot()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Wall>())
            CanMoving = false;
        else CanMoving = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Wall>())
            CanMoving = true;
    }
}
