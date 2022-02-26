using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI_2 : MonoBehaviour
{
    private enum EnemyState
    {
        Patrol,
        Chase,
        Attack
    }

    [SerializeField] private Transform _target;
    [SerializeField] private NavMeshAgent _agent;
    [Space]
    [SerializeField] private int _maxHP;
    [SerializeField] private float _patrolSpeed = 4;
    [Space]
    [SerializeField] private EnemyState _state;
    [SerializeField] private EnemyState _previousState;

    public HealthSystem HealthSystem { get { return _healthSystem; } }
    private HealthSystem _healthSystem;

    private float _distanceToTarget;

    private FieldOfView _fieldOfView;
    private EnemyAttack _enemyAttack;
    private EnemySoundController _soundController;

    public bool isDead;


    public float GetDistanceToTarget()
    {
        return _distanceToTarget;
    }

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _state = EnemyState.Patrol;

        _healthSystem = new HealthSystem(_maxHP, gameObject);
        _fieldOfView = GetComponent<FieldOfView>();
        _enemyAttack = GetComponent<EnemyAttack>();
        _soundController = GetComponent<EnemySoundController>();
    }

    private void Update()
    {
        if (_target == null)
            _target = FindObjectOfType<PlayerMove>().transform;

        _distanceToTarget = Vector3.Distance(_target.position, transform.position);

        switch (_state)
        {
            case EnemyState.Patrol:
                Patrol();
                break;

            case EnemyState.Chase:
                Chase();
                break;

            case EnemyState.Attack:
                PrepareToAttack();
                break;
        }
    }

    private void FaceTarget()
    {
        Vector3 direction = (_target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 10f);
    }

    private void Patrol()
    {
        RaycastHit raycastHit;
        Ray ray = new Ray(transform.position, transform.forward);
        int layerMask = 1 << 8;

        transform.Translate(Vector3.forward * _patrolSpeed * Time.deltaTime);
        Debug.DrawRay(transform.position, transform.forward * 3, Color.cyan);

        _soundController.PlayMoveSound();

        if (Physics.Raycast(ray, out raycastHit, 3f, layerMask))
            transform.Rotate(0, 90, 0);

        if (Vector3.Distance(transform.position, _target.position) < _fieldOfView.radius && _fieldOfView.canSeePlayer)
            _state = EnemyState.Chase;
    }

    private void Chase()
    {
        if ((_distanceToTarget <= _fieldOfView.radius && (_previousState == EnemyState.Attack || _previousState == EnemyState.Chase)) || _fieldOfView.canSeePlayer)
        {
            _soundController.PlayMoveSound();
            _agent.SetDestination(_target.position);
            _previousState = EnemyState.Chase;
            if (_distanceToTarget <= _agent.stoppingDistance)
            {
                _state = EnemyState.Attack;
                FaceTarget();
            }
        }
    }

    private void PrepareToAttack()
    {
        FaceTarget();
        if (_distanceToTarget > _agent.stoppingDistance)
        {
            _state = EnemyState.Chase;
            _previousState = EnemyState.Attack;
        }

        if (_fieldOfView.canSeePlayer && !Player.Dead)
            _enemyAttack.Attack();
        else
        {
            _state = EnemyState.Chase;
            _previousState = EnemyState.Attack;
        }

        if (Player.Dead)
            _state = EnemyState.Patrol;
    }

    public void CheckHealth()
    {
        if (_healthSystem.GetHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _agent.stoppingDistance);
    }
}
