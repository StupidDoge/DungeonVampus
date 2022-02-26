using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chracteristic : MonoBehaviour
{
    [Header("Health")]
    [Header("Main Characteristic")]
    [SerializeField] private int _maxHp;
    [SerializeField] private int _currentHp;
    private HealthSystem _healthSystem;

    [Header("Defender")]
    [SerializeField] private float _defendValue;

    [Header("Stamina")]
    [SerializeField] private float _maxStamina;
    [SerializeField] private float _currentStamina;
    [SerializeField] private float _restoreStaminaAmount;
    [SerializeField] private float _timeToResetStamina;
    private StaminaSystem _staminaSystem;

    [Header("Sub Characteristic")]
    [SerializeField] private int _strenght;
    [SerializeField] private int _intelligence;
    [SerializeField] private int _dexterity;

    private float _lastTimeStamina;
    private bool _isDecreased;

    public int Strenght
    {
        set
        {
            if (value > 0)
            {
                _strenght = value;
            }
            else
            {
                _strenght = 0;
            }
        }

    }
    public int Intelligence
    {

        set
        {
            if (value > 0)
            {
                _intelligence = value;
            }
            else
            {
                _intelligence = 0;
            }
        }

    }
    public int Dexterity
    {

        set
        {
            if (value > 0)
            {
                _dexterity = value;
            }
            else
            {
                _dexterity = 0;
            }
        }

    }


    private void Start()
    {
        _healthSystem = new HealthSystem(_maxHp,_currentHp);
        _staminaSystem = new StaminaSystem(_maxStamina, _restoreStaminaAmount, _timeToResetStamina);

    }
    private void Update()
    {
        if (Time.time >= _staminaSystem.LastTimeUseStamina + _staminaSystem.TimeToReset)
        {
            _staminaSystem.IsDecreased = false;
        }

        if (!_staminaSystem.IsDecreased)
        {
            _staminaSystem.RecoveryStamina();

        }
    }
    public void CalculateCharacteristic() //расчет здоровь€ и стамины иcход€ из характеристик
    {

    }
    public void Heal(int healAmount) 
    {
        _healthSystem.Heal(healAmount);
    }
    public bool DecreaseStamina(float cost)
    {
        return _staminaSystem.DecreaseStamina(cost);
    }
    public void TakeDamage(DamageInfo info) 
    {
    
    }
}
