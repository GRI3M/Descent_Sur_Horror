using Unity.VisualScripting;
using UnityEngine;

namespace ItemScripts
{
    public class Utilities : Items
    {
        [Header("Utility Values")]
        [SerializeField] public UtilitySO utilitySO;
        public int utilityCount;
        
    }
    
    public enum UtilityTypes
    {
        Flashbang,
        Grenade,
        Molotov,
        ThrowingKnife,
        SmokeBomb,
    }
}
