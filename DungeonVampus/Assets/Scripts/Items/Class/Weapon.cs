using System.Collections;

using System.Collections.Generic;
using UnityEngine;
namespace NewItemSystem
{
    [System.Serializable]
    public class Weapon : Item
    {
        [Header("Weapon Variables")]
        [SerializeField] private int _damage;
        [SerializeField] private float _speedAttack;
        [SerializeField] private float _staminaCost;
        [SerializeField] private AudioClip _attackSound;
        [SerializeField] private AudioClip _hitEnvironmentSound;
        [SerializeField] private AudioClip _hitEnemySound;
        [SerializeField] private TypeWeapon _typeWeapon;

        public TypeWeapon TypeWeapon => _typeWeapon;
        public int Damage 
        {
            get { return _damage; }
            set { _damage = value; }
        }

        public float SpeedAttack 
        {
            get { return _speedAttack; }
            set { _speedAttack = value; }
        }

        public float StaminaCost
        {
            get { return _staminaCost; }
            set { _staminaCost = value; }
        }

        public AudioClip AttackSound
        {
            get { return _attackSound; }
            set { _attackSound = value; }
        }

        public AudioClip HitEnvironmentSound
        {
            get { return _hitEnvironmentSound; }
            set { _hitEnvironmentSound = value; }
        }

        public AudioClip HitEnemySound
        {
            get { return _hitEnemySound; }
            set { _hitEnemySound = value; }
        }
    }
    public enum TypeWeapon
    {
        Sword,
        Spear,
        Dagger
    }
}