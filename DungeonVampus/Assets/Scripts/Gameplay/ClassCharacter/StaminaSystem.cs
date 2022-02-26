using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StaminaSystem 
{
    public event EventHandler OnHealthChange;

    private float _stamina;
    private float  _maxStamina;
    private float _restoreStaminaAmount;
    private float _timeToReset;
    private float _lastTimeUseStamina;
    private bool _isDecreased=false;
    public float GetStamina
    {
        get { return _stamina; }
    }
    public float LastTimeUseStamina 
    {
        get { return _lastTimeUseStamina; }
        set { _lastTimeUseStamina = value; }
    }
    public bool IsDecreased 
    {
        get { return _isDecreased; }
        set { _isDecreased = value; }
    }
    public float TimeToReset 
    {
        get { return _timeToReset; }
    }
    public StaminaSystem(float maxStamina, float restoreStaminaAmount, float timeToReset)
    {
        _maxStamina = maxStamina;
        _stamina = _maxStamina;
        _restoreStaminaAmount= restoreStaminaAmount;
        _timeToReset = timeToReset;
    }
   
    public float GetHealtPrecent()
    {

        return _stamina / _maxStamina;
    }

    public bool DecreaseStamina(float staminaAmount)
    {
        if (staminaAmount <= _stamina)
        {
            _isDecreased = true;
            _lastTimeUseStamina = Time.time;
            _stamina -= staminaAmount;
            return true;
        }
        else 
        {
            return false;
        }
    }

    public void RecoveryStamina()
    {
        _stamina += _restoreStaminaAmount * Time.deltaTime;
        if (_stamina >= _maxStamina) 
        {
            _stamina = _maxStamina;
        }

    }
}
