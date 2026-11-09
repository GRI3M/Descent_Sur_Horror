using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [Header("Pluggins")]
    [SerializeField] Transform turret;
    [SerializeField] Transform playerTransform;
    [SerializeField] Transform turretShotSpawn;
    [SerializeField] GameObject turretShot;
    PlayerHealth playerHealth;

    [Header("Turret Values")]
    [SerializeField] float turretShotCharge = 2f;
    [SerializeField] float projectileDamage = 33f;
    [SerializeField] float projectileSpeed = 14f;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerHealth = FindAnyObjectByType<PlayerHealth>();
        StartCoroutine(ShootRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        turret.LookAt(playerTransform);
    }

    /// <summary>
    /// The coroutine of shooting turret shots
    /// </summary>
    /// <returns>How long between turret shots</returns>
    IEnumerator ShootRoutine()
    {
        while (playerHealth)
        {
            yield return new WaitForSeconds(turretShotCharge);
            Projectile newProjectile = Instantiate(turretShot, turretShotSpawn.position, turret.rotation).GetComponent<Projectile>();
            //newProjectile.transform.LookAt(playerTransform);
            newProjectile.Init(projectileDamage, projectileSpeed);
        }
    }
}
