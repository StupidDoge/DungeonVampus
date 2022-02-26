using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace NewItemSystem
{
    public class Inventory : MonoBehaviour
    {
        [Header("InventorySlots")]
        [SerializeField] private InventoryData _inventoryData;
        [SerializeField] private WeaponContainer _selectedContainer;
        [SerializeField] private float _rangePickUp;
        [SerializeField] private LayerMask _itemLayer;

        [Header("HolderArms")]
        [SerializeField] private HolderItem _leftHolderItem;
        [SerializeField] private HolderItem _rightHolderItem;

        [Header("Event")]
        [SerializeField] private UnityEvent _useInventory;
        [SerializeField] private GameObject _holder;
        private bool _isEnableInventory;

        public HolderItem LeftHolderItem=> _leftHolderItem;
        public HolderItem RightHolderItem=> _rightHolderItem;
       

        private void Update()
        {
            CheckContainer();
            if (Input.GetKeyDown(KeyCode.I))
            {
                _isEnableInventory = !_isEnableInventory;
                _holder.SetActive(_isEnableInventory);
                _useInventory.Invoke();
                if (_isEnableInventory)
                {
                    Cursor.lockState = CursorLockMode.Confined;
                }
                else
                {
                    Cursor.lockState = CursorLockMode.Locked;
                }
            }
            if (Input.GetKeyDown(KeyCode.E)) 
            {
                PickUpItem();
            }
        }
        public void PickUpItem() 
        {
            if (_selectedContainer != null)
            {
                _inventoryData.AddItem(_selectedContainer.Item);
                Destroy(_selectedContainer.gameObject);
                _selectedContainer = null;
            }
        }
        private void CheckContainer() 
        {
            if (Physics.Raycast(transform.position, transform.forward, out RaycastHit info, _rangePickUp, _itemLayer))
            {
                _selectedContainer = info.collider.GetComponent<WeaponContainer>();
            }
            else 
            {
                _selectedContainer = null;
            }
        }
    }
}