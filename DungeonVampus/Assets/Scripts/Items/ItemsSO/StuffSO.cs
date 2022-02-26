using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace NewItemSystem
{
    [CreateAssetMenu(fileName = "NewStuff", menuName = "ScriptableObjects/Items/Stuff")]
    public class StuffSO : ItemSO
    {
        [SerializeField] private Stuff _stuff;
    }
}
