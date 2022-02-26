using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
namespace NewItemSystem
{
    public class UIInventorySlots : MonoBehaviour,IPointerClickHandler
    {
        [SerializeField] private Image _icon;
        [SerializeField] private InventorySlot _itemSlot;
        [SerializeField] private bool _isEmpty=true;
        [SerializeField] private int _equipSlotIndex;
        [SerializeField] private bool _isEqupSlot;
        private UIInventory _inventory;
        public bool IsEmpty => _isEmpty;
        public InventorySlot ItemSlot => _itemSlot;

        public void OnEnable()
        {
            CheckItem();
        }
        public void OnPointerClick(PointerEventData eventData)
        {
            if (!_isEqupSlot)
            {
                int index = eventData.pointerId;
                _inventory.UseItem(this, index);
            }
            else 
            {
                _inventory.TakeOffSlot(this,_equipSlotIndex);
            }
        }
        public void CheckItem()
        {
            if (_itemSlot != null)
            {
                if (_itemSlot.IsStack)
                {
                    if (_itemSlot.ValueItem <= 0)
                    {
                        ClearSlot(false);
                    }
                }
            }
        }
        public void ClearSlot(bool setActive) 
        {
            _isEmpty = true;
            _itemSlot = null;
            _icon.sprite = null;
            if(setActive)
            gameObject.SetActive(false);
        }
        public void SetSlot(InventorySlot slot,UIInventory inventory) 
        {
            _inventory = inventory;
            _itemSlot = slot;
            _icon.sprite = _itemSlot.Item.GetIcon();
            _isEmpty = false;
            gameObject.SetActive(true);

        }
    }
}