using System;
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

        public GameObject weaponModel;

    }
}
