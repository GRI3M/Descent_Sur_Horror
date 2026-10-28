using System.Collections.Generic;
using UnityEngine;
using Enemy;

public class Explosion : MonoBehaviour
{
    [SerializeField] float range = 1.5f;
    [SerializeField] float damage = 55f;

    void Start()
    {
        ExplodePlayer();
        ExplodeEnemies();
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.orangeRed;
        Gizmos.DrawWireSphere(transform.position,range);
    }

    void ExplodeEnemies()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, range);
        HashSet<EnemyHealthManager> damagedEnemies = new HashSet<EnemyHealthManager>();

        foreach(Collider hitCollider in hitColliders)
        {
            EnemyHealthManager enemyHealth = hitCollider.GetComponent<EnemyHealthManager>();

            if(!enemyHealth || !damagedEnemies.Add(enemyHealth)) continue;

            enemyHealth.TakeDamage(damage);
        }
            
    }

    void ExplodePlayer()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, range);

        foreach(Collider hitCollider in hitColliders)
        {
            PlayerHealth playerHealth = hitCollider.GetComponent<PlayerHealth>();
            if(!playerHealth) continue;

            playerHealth.TakeDamage(damage);
            break;

        }
        
    }
}
