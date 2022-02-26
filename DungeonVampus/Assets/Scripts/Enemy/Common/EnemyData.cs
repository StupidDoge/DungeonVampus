using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewInventoryData", menuName = "ScriptableObjects/Enemy/EnemyData")]
public class EnemyData : ScriptableObject
{

    private enum EnemyName
    {
        SkeletonArcher = 0,
        SkeletonSwordsman = 1,
        Slime = 2,
        Spider = 3,
        Zombie = 4,
        Bat = 5,
        Cultist = 6
    }

    private enum EnemyAttackType
    {
        Melee = 0,
        Distant = 1,
        Bat = 2
    }

    [SerializeField] private Sprite _sprite;
    [SerializeField] private EnemyName _name;
    [SerializeField] private EnemyAttackType _attackType;
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _damage;
    [SerializeField] private float _waitingTime;
    [SerializeField] private float _hitDistance;
    [SerializeField] private float _stoppingDistance;
    [SerializeField] private float _speed;

    public Sprite Sprite { get => _sprite; }
    public int Name { get => (int)_name; }
    public int AttackType { get => (int)_attackType; }
    public float MaxHealth { get => _maxHealth; }
    public float Damage { get => _damage; }
    public float WaitingTime { get => _waitingTime; }
    public float HitDistance { get => _hitDistance; }
    public float StoppingDistance { get => _stoppingDistance; }
    public float Speed { get => _speed; }
}
