using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttackAnimationController : MonoBehaviour
{
    [SerializeField] private float _animationLength;

    private SpriteRenderer _spriteRenderer;
    private EnemyAttack _enemyAttack;
    private EnemySoundController _enemySoundController;
    private Animator _animator;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _enemyAttack = GetComponentInParent<EnemyAttack>();
        _enemySoundController = GetComponentInParent<EnemySoundController>();
    }

    public IEnumerator MeleeAttackAnimation()
    {
        _spriteRenderer.enabled = true;
        _enemyAttack.hitFlag = true;
        _animator.SetBool("hitFlag", _enemyAttack.hitFlag);
        _enemySoundController.PlayAttackSound();

        yield return new WaitForSeconds(_animationLength);

        _spriteRenderer.enabled = false;
        _enemyAttack.hitFlag = false;
        _animator.SetBool("hitFlag", _enemyAttack.hitFlag);
    }

    public void MeleeAttack()
    {
        StartCoroutine(_enemyAttack.EnemyMeleeAttack(0.1f));
    }

    public void DisableAttackContainer() // функция для костыля 
    {
        gameObject.SetActive(false);
    }
}
