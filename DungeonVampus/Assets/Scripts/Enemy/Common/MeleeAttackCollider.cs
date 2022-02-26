using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttackCollider : MonoBehaviour
{
    private EnemySoundController _soundController;
    private EnemyAttack _enemyAttack;
    private bool _canAttack = true;

    private void Start()
    {
        _enemyAttack = GetComponentInParent<EnemyAttack>();
        _soundController = GetComponentInParent<EnemySoundController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Player>(out Player player) && _canAttack)
        {
            player.HealthSystem.TakeDamage(_enemyAttack.Damage);
            player.gameObject.GetComponent<PlayerSoundController>().PlayHitSound();
            _soundController.PlayHitSound();
            _canAttack = false;
            if (player.HealthSystem.GetHealth <= 0)
            {
                player.gameObject.GetComponent<Player>().enabled = false;
                player.gameObject.GetComponent<PlayerMove>().enabled = false;
                player.gameObject.GetComponent<PlayerRotate>().enabled = false;
                player.gameObject.GetComponent<PlayerRotateSmooth>().enabled = false;
                Player.Dead = true;
            }
            StartCoroutine(AttackCooldown());
        }
    }

    IEnumerator AttackCooldown()
    {
        yield return new WaitForSeconds(_enemyAttack.MeleeWaitingTime / 2);
        _canAttack = true;
    }
}
