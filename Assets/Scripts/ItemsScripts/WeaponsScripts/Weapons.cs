using System;
using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;


namespace ItemScripts.WeaponScripts
{
    public class Weapons : Items
    {
        public enum WeaponTypes
        {
            Gun,
            Melee,
        }

        [SerializeField] public MeshRenderer weaponModel;

    }
}
