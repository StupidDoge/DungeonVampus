using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace NewItemSystem
{
    public class WeaponContainer : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spr;
        [SerializeField] private InventorySlot _item;

        public InventorySlot Item => _item;
        private void Start()
        {
            _spr.sprite = _item.Item.GetIcon();
        }
    }
}