using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace NewItemSystem
{
    public class PhysicalItem : MonoBehaviour
    {
        public virtual void UseItem() 
        {
        
        }

        public virtual void SetItem<T>(T item) where T:class
        {

        }

      
    }
}