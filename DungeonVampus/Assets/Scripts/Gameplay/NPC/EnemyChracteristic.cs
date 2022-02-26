using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChracteristic : MonoBehaviour, IDamage
{
    [SerializeField] private int _currentHp;

    private EnemySoundController _soundController;
    private EnemySpriteController _spriteController;

    private void Awake()
    {
        _soundController = GetComponent<EnemySoundController>();
        _spriteController = GetComponentInChildren<EnemySpriteController>();
    }

    public void TakeDamage(DamageInfo info)
    {
        _soundController.PlayTakeDamageSound();
        StartCoroutine(_spriteController.SwitchColor());
        _currentHp -= info.Damage;
        Debug.Log(gameObject.name + " hp = " + _currentHp);
        if (_currentHp <= 0)
            StartCoroutine(Die());
    }

    IEnumerator Die()
    {
        try
        {
            gameObject.GetComponentInChildren<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<BoxCollider>().enabled = false;
            gameObject.GetComponentInChildren<MeleeAttackCollider>().enabled = false;
            gameObject.GetComponent<EnemyAttack>().enabled = false;

            // временный костыль
            if (gameObject.GetComponentInChildren<MeleeAttackAnimationController>() != null)
                gameObject.GetComponentInChildren<MeleeAttackAnimationController>().DisableAttackContainer();
        } catch (NullReferenceException ex) { }

        yield return new WaitForSeconds(0.5f);
        gameObject.SetActive(false);
    }
}
