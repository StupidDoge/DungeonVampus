using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace NewItemSystem
{
    public enum TypePoition 
    {
        RestoreHeal,
        RestoreStamina,
    }
    [System.Serializable]
    public class Poition : Item
    {
        [Header("Poition Variables")]
        [SerializeField] private int _value;
        public int Value 
        {
            get { return _value; }
            set { _value = value; }
        }
    }
}