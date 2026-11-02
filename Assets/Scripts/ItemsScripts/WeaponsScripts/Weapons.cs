using System;
using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;


namespace ItemScripts.WeaponScripts
{
    public class Weapons : Items
    {
        /// <summary>
        /// Types of weapons, currently only 2
        /// </summary>
        public enum WeaponTypes
        {
            Gun,
            Melee,
        }

        [Header("Pluggins")]
        [SerializeField] public MeshRenderer weaponModel;

    }
}
