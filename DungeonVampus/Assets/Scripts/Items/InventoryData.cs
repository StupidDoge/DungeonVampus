using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace NewItemSystem
{
    [CreateAssetMenu(fileName = "NewInventoryData", menuName = "ScriptableObjects/Inventory/InventoryData")]
    public class InventoryData : ScriptableObject
    {
        [SerializeField] private List<InventorySlot> _items;
        public List<InventorySlot> Items => _items;

        public void AddItem(InventorySlot item) 
        {
            _items.Add(item);
        }

    }
}