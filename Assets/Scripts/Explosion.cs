using System.Collections.Generic;
using UnityEngine;
using Enemy;

public class Explosion : MonoBehaviour
{
    [Header("Damage Values")]
    [SerializeField] float range = 1.5f;
    [SerializeField] float damage = 55f;

    void Start()
    {
        ExplodePlayer();
        ExplodeEnemies();
    }

    /// <summary>
    /// Creates Gizmo references to show the explosion range
    /// </summary>
    void OnDrawGizmos()
    {
        Gizmos.color = Color.orangeRed;
        Gizmos.DrawWireSphere(transform.position,range);
    }

    /// <summary>
    /// Finds hit colliders of all enemy type creatures and deals damage to them individually
    /// </summary>
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

    /// <summary>
    /// Finds the player hitbox and deals damage to it and then leaves players alone.
    /// Might need to change this if it needs to fit for multiplayer, but it will probably match
    /// Enemy script above.
    /// </summary>
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
