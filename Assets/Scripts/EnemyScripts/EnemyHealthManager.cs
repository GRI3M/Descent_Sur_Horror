using UnityEditor.Build;
using UnityEngine;

namespace Enemy
{
    public class EnemyHealthManager : MonoBehaviour
    {
        [SerializeField] public float Basehealth = 100f;
        [SerializeField] public GameObject criminalExplosion;
        bool isDestructing;

        float currentHealth;

        void Awake()
        {
            currentHealth = Basehealth;
        }
        public void TakeDamage(float damageAmount)
        {
            currentHealth -= damageAmount;

            if(currentHealth <= 0)
            {
                SelfDestruct();
            }
        }

        public void SelfDestruct()
        {
            if(isDestructing) return;
            isDestructing = true;

            Instantiate(criminalExplosion, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
    
}
