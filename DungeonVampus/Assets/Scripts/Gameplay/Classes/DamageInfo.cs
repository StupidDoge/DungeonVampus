using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageInfo 
{
    private int _damage;

    public int Damage 
    {
        get { return _damage; }
    }
    public DamageInfo(int damage) 
    {
        _damage = damage;
    }
}
