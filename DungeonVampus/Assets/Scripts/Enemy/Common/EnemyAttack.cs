using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAttack : MonoBehaviour
{
    private enum EnemyType
    {
        GoblinSorcerer = 0,
        Goblin = 1,
        Slime = 2,
        Spider = 3,
        Zombie = 4,
        Bat = 5,
        Cultist = 6
    }

    [SerializeField] private EnemyType _enemyType;
    [SerializeField] private Transform _attackCollider;
    [SerializeField] private Projectile _projectile;
    [SerializeField] private float _waitingTime;
    [SerializeField] private int _damage;
    [SerializeField] private float _hitDistance;
    [SerializeField] private float _meleeWaitingTime;

    private EnemySpriteController _enemySpriteController;
    private EnemySoundController _soundController;
    private MeleeAttackAnimationController _batAttackAnimationController;
    private EnemyAI_2 _enemyAI;

    private NavMeshAgent _agent;

    private float _lastTime = -100;
    private bool _canAttack = true;
    public bool hitFlag;

    public int GetEnemyType()
    {
        return (int)_enemyType;
    }

    public int Enemy => (int)_enemyType;

    public int Damage => _damage;

    public float MeleeWaitingTime => _meleeWaitingTime;

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _enemyAI = GetComponent<EnemyAI_2>();
        _soundController = GetComponent<EnemySoundController>();
        _enemySpriteController = GetComponentInChildren<EnemySpriteController>();
        _batAttackAnimationController = GetComponentInChildren<MeleeAttackAnimationController>();
    }

    public void Attack()
    {
        switch (_enemyType)
        {
            case EnemyType.Goblin:
                if (!hitFlag && _enemyAI.GetDistanceToTarget() < _hitDistance && _canAttack)
                {
                    StartCoroutine(_batAttackAnimationController.MeleeAttackAnimation());
                    _canAttack = false;
                    StartCoroutine(AttackReload(_meleeWaitingTime));
                }
                break;

            case EnemyType.GoblinSorcerer:
                if (_canAttack)
                {
                    DistantAttack();
                    StartCoroutine(AttackReload(_waitingTime));
                }
                break;

            case EnemyType.Slime:
                Debug.Log("Slime attack");
                break;

            case EnemyType.Spider:
                Debug.Log("Spider attack");
                break;

            case EnemyType.Zombie:
                Debug.Log("Zombie attack");
                break;

            case EnemyType.Bat:
                if (!hitFlag && _enemyAI.GetDistanceToTarget() < _hitDistance && _canAttack)
                {
                    StartCoroutine(_batAttackAnimationController.MeleeAttackAnimation());
                    _canAttack = false;
                    StartCoroutine(AttackReload(_meleeWaitingTime));
                }
                break;

            case EnemyType.Cultist:
                DistantAttack();
                break;
        }
    }

    private void DistantAttack()
    {
        if (Time.time >= _lastTime + _waitingTime)
        {
            _lastTime = Time.time;
            Projectile projectile = Instantiate(_projectile, _attackCollider.transform.position, _attackCollider.transform.rotation);
            projectile.Damage = _damage;
            _soundController.PlayFireballCastSound();
        }
    }

    public IEnumerator EnemyMeleeAttack(float t)
    {
        _attackCollider.GetComponent<BoxCollider>().enabled = true;
        yield return new WaitForSeconds(t);
        _attackCollider.GetComponent<BoxCollider>().enabled = false;
    }

    private IEnumerator AttackReload(float time)
    {
        yield return new WaitForSeconds(time);
        _canAttack = true;
    }
}
