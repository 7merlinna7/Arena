using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
public class Player : MonoBehaviour, IDamageble, IDeadBehaviour
{
    private Mover _mover;
    private Rotator _rotator;
    private Shooter _shooter;
    private Health _health;

    public int Damage {  get; private set; }
    public bool CanMoving { get; private set; } = true;

    public bool IsDead => _health.IsDead;

    public void Initialize(Mover mover,Rotator rotator,Shooter shooter, Health health)
    {
        _mover = mover;
        _rotator = rotator;
        _health = health;
        _shooter = shooter;
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
        _health.TakeDamage(damage);
        Debug.Log("Health:" + _health.CurrentHealth);
    }

    public void Shoot() => _shooter.Shoot();

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
