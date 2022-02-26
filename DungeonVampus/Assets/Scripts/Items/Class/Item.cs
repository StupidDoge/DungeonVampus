using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace NewItemSystem
{
    public enum MetaType 
    {
         Weapon,
         Poition,
         Shield,
         Stuff,
         Bow,
    }
    [System.Serializable]
    public class Item
    {
        [Header("Main Variables")]
        [SerializeField] protected string name;
        [SerializeField] protected MetaType _metaType;
        [SerializeField] protected Sprite _icon;
      

        public string Name 
        {
            set { name = value; }
            get { return name; }
        }
        public MetaType MetaType 
        {
            set { _metaType = value; }
            get { return _metaType; }
        }
        public Sprite Icon
        {
            set { _icon = value;}
            get { return _icon; }
        }
    }
}