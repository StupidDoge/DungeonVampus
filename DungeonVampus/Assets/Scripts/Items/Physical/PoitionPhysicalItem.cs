using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace NewItemSystem
{
    public class PoitionPhysicalItem : PhysicalItem
    {
        [SerializeField] private Poition _poition;
        [SerializeField] private SpriteRenderer _mainSprite;
        private UnityEvent _poitionUse;
        private UnityEvent<int> _poitionEffect;
        
        public UnityEvent PoitionEvent 
        {
            set { _poitionUse = value; }
            get { return _poitionUse; }
        }

        public UnityEvent<int> PoitionEffect 
        {
            set { _poitionEffect = value; }
            get { return _poitionEffect; }
        
        }
        //delegate
        public override void UseItem()
        {
            _poitionUse.Invoke();
            //_poitionEffect.Invoke(_poition.Value);
            FindObjectOfType<Player>().HealthSystem.Heal(_poition.Value);
        }
        public void SetEventsPoition(UnityAction recovery, UnityAction<int> effect) 
        {
            if (_poitionEffect == null) 
            {
                _poitionEffect = new UnityEvent<int>();
            }
            if (_poitionUse == null) 
            {
                _poitionUse = new UnityEvent();
            }

            _poitionEffect.AddListener(effect);
            _poitionUse.AddListener(recovery);
        }
        public override void SetItem<T>(T item)
        {
            Poition t_poition= item as Poition;
            _poition.Name = t_poition.Name;
            _poition.MetaType = t_poition.MetaType;
            _poition.Value = t_poition.Value;
            _poition.Icon = t_poition.Icon;
            _mainSprite.sprite = t_poition.Icon;
        }
    }
}