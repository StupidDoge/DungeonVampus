using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace NewItemSystem
{
    public class ItemSO : ScriptableObject
    {
        [SerializeField] private MetaType _metaType;
        [SerializeField] protected bool _isStack;
        [SerializeField] protected int _maxStack;

        public MetaType MetaType => _metaType;



        public virtual Sprite GetIcon() 
        {
            return null;
        }
    }
}