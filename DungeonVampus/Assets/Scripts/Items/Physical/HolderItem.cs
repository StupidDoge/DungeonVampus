using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
namespace NewItemSystem
{
    public class HolderItem : MonoBehaviour
    {
        [SerializeField] private InventorySlot _slot;
        [SerializeField] private Chracteristic _chracteristic;
        [SerializeField] private GameObject[] _prefabs;
        [SerializeField] private PhysicalItem _currenPreafab;
        [SerializeField] private bool _rightArm;
        [SerializeField] private bool _isActive=true;
        [SerializeField] private InputHandler _input;
        private ItemSO _weaponData;

        public InventorySlot Slot 
        {
            get
            { 
                return _slot;
            }
            set 
            {
                _slot = value;
                InstantiateItem(_slot);
            }
        }

        private void Update()
        {
            if (_isActive)
            {
                if (_rightArm && _input.rightMouseButton)
                {
                    if (_currenPreafab)
                    {
                        Debug.Log("Right");
                        UseItem();
                    }
                }
                if (!_rightArm && _input.leftMouseButton)
                {
                    if (_currenPreafab)
                    {
                       Debug.Log("Left");
                        UseItem();
                    }
                }
            }
        }
        private void UseItem()
        {
            _currenPreafab.UseItem();
        }
        public void SetActive() 
        {
            _isActive = !_isActive;

        }
        public void DestroyCurrentPrefab() 
        {
            Debug.Log(gameObject.name);
            if (_currenPreafab != null)
            {
                Debug.Log(gameObject.name+""+1);
                Destroy(_currenPreafab.gameObject);
                _slot = null;
                _currenPreafab = null;
            }
        }
        public void InstantiateItem(InventorySlot _slot) 
        {
           
            _weaponData =  _slot.Item;
            DestroyCurrentPrefab();
            switch (_weaponData.MetaType)
            {
                case (MetaType.Weapon):
                    InstantiateWeapon(_weaponData);
                    break;
                case (MetaType.Poition):
                    InstantiatePoition(_weaponData);
                    break;
            }
        }
        private void InstantiateWeapon(ItemSO weaponData) 
        {
            WeaponSO t_weapon = weaponData as WeaponSO;
            //_currenPreafab = Instantiate(_prefabs[0]);
            GameObject go = null;
            switch (t_weapon.TypeWeapon)
            {
                case TypeWeapon.Sword:
                    go = Instantiate(_prefabs[0], this.transform.position, _prefabs[0].transform.rotation, transform);
                    break;
                case TypeWeapon.Spear:
                    go = Instantiate(_prefabs[1], this.transform.position, _prefabs[1].transform.rotation, transform);
                    break;
                case TypeWeapon.Dagger:
                    break;
            }
           
            _currenPreafab = go.GetComponent<WeaponPhysicalItem>();
            _currenPreafab.SetItem<Weapon>(t_weapon.Weapon);
            _currenPreafab.GetComponent<WeaponPhysicalItem>().AddDelegateStaminaDecreaset(_chracteristic.DecreaseStamina);

        }
        private void InstantiatePoition(ItemSO weaponData) 
        {
            PoitionSO t_poition = weaponData as PoitionSO;
            GameObject go = Instantiate(_prefabs[2], this.transform.position ,Quaternion.identity, transform);
            go.transform.localRotation = Quaternion.Euler(0, 0, 0);
            _currenPreafab = go.GetComponent<PhysicalItem>();
            _currenPreafab.SetItem<Poition>(t_poition.Poition);
            _currenPreafab.GetComponent<PoitionPhysicalItem>().SetEventsPoition(RecoverItem,_chracteristic.Heal);
        }
        private void RecoverItem() //уменьшаяет кол-во нынешнего предмета 
        {
            if (_slot.RecovereValue()) 
            {
                DestroyCurrentPrefab();
            }
        }
        //private void Instantiate
    }
}