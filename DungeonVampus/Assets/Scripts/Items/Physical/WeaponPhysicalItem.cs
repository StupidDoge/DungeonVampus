using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
namespace NewItemSystem
{
    public class WeaponPhysicalItem : PhysicalItem
    {
        [SerializeField] private Weapon _weapon;
        [SerializeField] private Animator _animator;
        [SerializeField] private SpriteRenderer _mainSprite;
        [SerializeField] private Func<float, bool> _staminaCallback;

        private AudioClip _hitEnemySound, _hitEnvironmentSound;

        private AudioSource _audioSource;
        private float _lastTimeAttack;

        private bool _alreadyPlayed = false;

        public override void SetItem<T>(T item)
        {
            Weapon t_weapon = item as Weapon;
            _weapon.Name = t_weapon.Name;
            _weapon.MetaType = t_weapon.MetaType;
            _weapon.Damage = t_weapon.Damage;
            _weapon.SpeedAttack = t_weapon.SpeedAttack;
            _weapon.StaminaCost = t_weapon.StaminaCost;
            _weapon.Icon = t_weapon.Icon;
            _weapon.AttackSound = t_weapon.AttackSound;
            _mainSprite.sprite = t_weapon.Icon;

            _audioSource = GetComponent<AudioSource>();
            _audioSource.clip = _weapon.AttackSound;
            _hitEnemySound = t_weapon.HitEnemySound;
            _hitEnvironmentSound = t_weapon.HitEnvironmentSound;
        }
        public void AddDelegateStaminaDecreaset(Func<float, bool> callback)
        {
            _staminaCallback = callback;
        }
        public override void UseItem()
        {
            if (Time.time >= _lastTimeAttack + _weapon.SpeedAttack && _staminaCallback(_weapon.StaminaCost) && !PauseMenu.gameIsPaused)
            {
                _audioSource.Play();
                _lastTimeAttack = Time.time;
                _animator.Play("Attack");
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<EnemyChracteristic>(out EnemyChracteristic target))
            {
                target.TakeDamage(new DamageInfo(_weapon.Damage));
                _audioSource.PlayOneShot(_hitEnemySound);
            }

            if (other.CompareTag("Obstacle") && !_alreadyPlayed)
            {
                _audioSource.PlayOneShot(_hitEnvironmentSound);
                StartCoroutine(SoundCooldown());
            }
        }

        IEnumerator SoundCooldown()
        {
            _alreadyPlayed = true;
            yield return new WaitForSeconds(0.5f);
            _alreadyPlayed = false;
        }

    }
}