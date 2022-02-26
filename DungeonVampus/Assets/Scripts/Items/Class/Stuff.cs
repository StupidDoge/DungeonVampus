using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace NewItemSystem
{
    [System.Serializable]
    public class Stuff : Item
    {
        [SerializeField] private int _damage;
        [SerializeField] private float _speedAttack;
        [SerializeField] private int _maxStorage;
        //тип камня для перезарядки 
    }
}
