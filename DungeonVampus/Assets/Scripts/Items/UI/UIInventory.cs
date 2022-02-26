using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace NewItemSystem
{
    public class UIInventory : MonoBehaviour
    {
        [Header("InventoryData")]
        [SerializeField] private InventoryData _inventoryData;
        [SerializeField] private Inventory _inventory;
       
        [Header("SlotsUI")]
        [SerializeField] private UIInventorySlots[] _slots;
        [SerializeField] private UIInventorySlots[]  _equipSlots;

        private void Start()
        {
            InstantiateSlots();
        }

        private void InstantiateSlots() 
        {
            for (int i = 0; i < _slots.Length; i++)
            {
                if (i< _inventoryData.Items.Count && _inventoryData.Items[i] != null)
                {
                    _slots[i].gameObject.SetActive(true) ;
                    _slots[i].SetSlot(_inventoryData.Items[i],this);
                }
                else 
                {
                    _slots[i].gameObject.SetActive(false);
                }
            }
        }

        public void UseItem(UIInventorySlots item, int clickIndex) 
        {
            if (clickIndex == -2 && _inventory.LeftHolderItem.Slot != item.ItemSlot && _inventory.RightHolderItem.Slot != item.ItemSlot)
            {
                EquipSlot(0, item);
                _inventory.LeftHolderItem.Slot = item.ItemSlot;
                item.ClearSlot(true);

            }
            else if (clickIndex == -1 && _inventory.RightHolderItem.Slot != item.ItemSlot && _inventory.LeftHolderItem.Slot != item.ItemSlot)
            {
                EquipSlot(1, item);
                _inventory.RightHolderItem.Slot = item.ItemSlot;
                item.ClearSlot(true);
            }

        }
        public void TakeOffSlot(UIInventorySlots item,int equipSlotIndex) 
        {
            for (int i = 0; i < _slots.Length; i++)
            {
                if (_slots[i].IsEmpty)
                {
                    _slots[i].SetSlot(item.ItemSlot, this);
                    GetHolder(equipSlotIndex).DestroyCurrentPrefab();
                    item.ClearSlot(false) ;
                    break;
                }
            }
        }
        public HolderItem GetHolder(int index ) 
        {
            switch (index)
            {
                case 0:
                    return _inventory.LeftHolderItem;
                case 1:
                    return _inventory.RightHolderItem;
                default:
                    return null;
            }
            
        }
        private void EquipSlot(int index, UIInventorySlots item) 
        {
            if (_equipSlots[index].IsEmpty)
            {
                _equipSlots[index].SetSlot(item.ItemSlot, this);
            }
            else
            {
                for (int i = 0; i < _slots.Length; i++)
                {
                    if (_slots[i].IsEmpty)
                    {
                        Debug.Log(_slots[i].name);
                        _slots[i].SetSlot(_equipSlots[index].ItemSlot, this);
                        _equipSlots[index].SetSlot(item.ItemSlot, this);
                        break;
                    }
                }
            }
        }
    }
}
