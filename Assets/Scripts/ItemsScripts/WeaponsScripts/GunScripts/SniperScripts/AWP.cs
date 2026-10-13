using UnityEngine;

namespace ItemScripts
{
    public class AWP : Sniper
    {
        public AWP()
        {
            capacity = 5;
            reloadSpeed = 3.5f;
            fireRate = 1.57f;
            rechamber = true;
        }
    }
}
