using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpriteController : MonoBehaviour
{
    private EnemyAttack _enemyAttack;
    private EnemySoundController _enemySoundController;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;
    private int _enemyType;

    void Start()
    {
        _enemyAttack = GetComponentInParent<EnemyAttack>();
        _enemySoundController = GetComponentInParent<EnemySoundController>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _enemyType = _enemyAttack.GetEnemyType();

        _animator = GetComponent<Animator>();
        _animator.SetInteger("enemyType", _enemyType);
    }

    /*public IEnumerator MeleeAttackAnimation(float t)
    {
        _enemyAttack.hitFlag = true;
        _animator.SetBool("hitFlag", _enemyAttack.hitFlag);
        _enemySoundController.PlayHitSound();
        yield return new WaitForSeconds(t);
        _enemyAttack.hitFlag = false;
        _animator.SetBool("hitFlag", _enemyAttack.hitFlag);
    }

    public void MeleeAttack()
    {
        StartCoroutine(_enemyAttack.EnemyMeleeAttack(0.1f));
    }*/

    public IEnumerator SwitchColor()
    {
        _spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.25f);
        _spriteRenderer.color = Color.white;
    }
}
