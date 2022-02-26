using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem
{
    public EventHandler OnHealthChange;

    private GameObject _character;
    public GameObject Character { set { _character = value; } }

    private int _health;
    private int _maxHealth;

    public HealthSystem(int healthMax, GameObject character)
    {
        _character = character;
        _maxHealth = healthMax;
        _health = healthMax;
    }

    public HealthSystem(int healthMax, int currentHealth)
    {
        _maxHealth = healthMax;
        _health = currentHealth;
    }

    public int GetHealth => _health;
    public int GetMaxHealth => _maxHealth;

    public void TakeDamage(int damageAmount)
    {
        _health -= damageAmount;
        if (_health <= 0)
        {
            _health = 0;
        }
        if (OnHealthChange != null)
        {
            OnHealthChange(this, EventArgs.Empty);
        }
    }
    public void Heal(int healAmount)
    {
        _health += healAmount;
        if (_health > _maxHealth)
        {
            _health = _maxHealth;
        }
        if (OnHealthChange != null)
        {
            OnHealthChange(this, EventArgs.Empty);
        }
    }
}
