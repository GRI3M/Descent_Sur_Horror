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
            agent.SetDestination(player.transform.position);
        }

        
    }
    
}
