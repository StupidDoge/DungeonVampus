using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _speed;

    private CharacterController _player;
    private PlayerSoundController _playerSoundController;
    private Vector3 _moveDir;

    private void Awake() 
    {
        _player = GetComponent<CharacterController>();
        _playerSoundController = GetComponent<PlayerSoundController>();
    } 

    public void Move() 
    {
        _moveDir = ((transform.right * Input.GetAxis("Horizontal")) + (transform.forward * Input.GetAxis("Vertical"))) * _speed;
        _player.Move(_moveDir * Time.deltaTime);
        if (_player.velocity.magnitude > 2f)
            _playerSoundController.PlayMoveSound();
    }
}
