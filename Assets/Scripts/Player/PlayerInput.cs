using UnityEngine;

public class PlayerInput : MonoBehaviour 
{
    private const string HorizontalAxisName = "Horizontal";
    private const string VerticalAxisName = "Vertical";

    private Vector3 _input;
    private Player _player;

    public void Initialize (Player player)
    {
        _player = player;
    }

    public void Update()
    {
        IsMoving();
        if (Input.GetKeyDown(KeyCode.Space)) 
            _player.Shoot();
    }

    public void IsMoving()
    {
        _input = new Vector3(Input.GetAxisRaw(HorizontalAxisName), 0, Input.GetAxisRaw(VerticalAxisName));
        if (_input != Vector3.zero)
            _player.Move(_input);
    }
}
