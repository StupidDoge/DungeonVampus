using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace NewItemSystem
{
    [CreateAssetMenu(fileName = "NewPoition", menuName = "ScriptableObjects/Items/Poition")]
    public class PoitionSO : ItemSO
    {
        [SerializeField] private Poition _poition;

        public Poition Poition => _poition;

        public override Sprite GetIcon()
        {
            return _poition.Icon;
        }
    }
}
