using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace NewItemSystem
{
  

    [CreateAssetMenu(fileName = "NewWeapon", menuName = "ScriptableObjects/Items/Weapon")]
    public class WeaponSO : ItemSO
    {
        [SerializeField] private Weapon _weapon;

        public Weapon Weapon => _weapon;
        public TypeWeapon TypeWeapon => _weapon.TypeWeapon;

        public override Sprite GetIcon()
        {
            return _weapon.Icon;
        }
    }
}