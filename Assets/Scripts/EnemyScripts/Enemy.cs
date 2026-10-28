using StarterAssets;
using UnityEngine;
using UnityEngine.AI;
using Player;
using Unity.VisualScripting;

namespace Enemy
{
    public class Enemy : MonoBehaviour
    {
        FirstPersonController player;
        private NavMeshAgent agent;

        const string PLAYER_STR = "Player";

        void Awake()
        {
            agent = GetComponent<NavMeshAgent>();
        }

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            player = FindAnyObjectByType<FirstPersonController>();
        }

        // Update is called once per frame
        void Update()
        {
            if(!player) return;
            agent.SetDestination(player.transform.position);
        }

        void OnTriggerEnter(Collider other)
        {
            if(other.tag == PLAYER_STR)
            {
                EnemyHealthManager enemyHealth = GetComponent<EnemyHealthManager>();
                enemyHealth.SelfDestruct();
            }
        }

    }
    
}
