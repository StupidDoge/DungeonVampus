using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace NewItemSystem
{
    [CreateAssetMenu(fileName = "InventorySlot", menuName = "ScriptableObjects/Inventory/Slot")]
    public class InventorySlot : ScriptableObject
    {
        [SerializeField] private ItemSO _item;
        [SerializeField] private bool _isStack;
        [SerializeField] private int _valueItem;
        [SerializeField] private int _maxStack;

        public bool IsStack => _isStack;
        public int ValueItem => _valueItem;
        public ItemSO Item => _item;

        public bool RecovereValue()
        {
            _valueItem--;
            if (_valueItem <= 0) 
            {
                _valueItem = 0;
                return true;
            }
            return false;
        }
    }
}