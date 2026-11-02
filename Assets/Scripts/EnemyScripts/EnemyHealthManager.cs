using UnityEditor.Build;
using UnityEngine;

namespace Enemy
{
    public class EnemyHealthManager : MonoBehaviour
    {
        [Header("Enemy Health Values")]
        [SerializeField] public float Basehealth = 100f;
        float currentHealth;
        
        [Header("Pluggins")]
        [SerializeField] public GameObject criminalExplosion;

        [Header("Enemy Values")]
        bool isDestructing;



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
