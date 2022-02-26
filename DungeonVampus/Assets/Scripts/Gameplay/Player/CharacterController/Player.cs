using UnityEngine;

[RequireComponent(typeof(CharacterController), typeof(PlayerMove), typeof(PlayerRotate))]
public class Player : MonoBehaviour
{
    [SerializeField]
    private int MaxHp;
    [SerializeField]
    private Healthbar HealthBar;

    private PlayerMove _move;
    private PlayerRotate _currentRotate;
    private bool _isRotateEnable = true;
    private HealthSystem _healthSystem;

    public HealthSystem HealthSystem { get { return _healthSystem; } }

    public static bool Dead = false;

    private void Awake()
    {
        _move = GetComponent<PlayerMove>();
        _currentRotate = GetComponent<PlayerRotate>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Start()
    {
        _healthSystem = new HealthSystem(MaxHp, gameObject);
        HealthBar.Setup(_healthSystem);
    }

    private void Update()
    {
        _move.Move();
        if (_isRotateEnable)
        {
            _currentRotate.Rotate();
        }
    }
    public void SwitchEnableRotate() 
    {
        _isRotateEnable = !_isRotateEnable;
    }
}
