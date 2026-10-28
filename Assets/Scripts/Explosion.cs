using UnityEngine;
using Enemy;

public class Explosion : MonoBehaviour
{
    [SerializeField] float range = 1.5f;
    [SerializeField] float damage = 55f;

    void Start()
    {
        Explode();
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.orangeRed;
        Gizmos.DrawWireSphere(transform.position,range);
    }

    void Explode()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, range);

        foreach(Collider hitCollider in hitColliders)
        {
            PlayerHealth playerHealth = hitCollider.GetComponent<PlayerHealth>();
            EnemyHealthManager enemyHealth = hitCollider.GetComponent<EnemyHealthManager>();
            if(!playerHealth && !enemyHealth) continue;

            if(playerHealth) playerHealth.TakeDamage(damage);
            else enemyHealth.TakeDamage(damage);
            break;
        }
        
    }
}
