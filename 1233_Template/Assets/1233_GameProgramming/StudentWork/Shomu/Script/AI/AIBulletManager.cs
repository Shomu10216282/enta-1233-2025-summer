using System.Collections;
using UnityEngine;
using Vangard;

public class AIBulletManager : BaseBulletManager
{
    [SerializeField] private Transform BulletSpawnPoint;
    [SerializeField] private float fireRate = 2f; 
    [SerializeField] private float attackRange = 10f;


    [Header("Sound")]
    [SerializeField] private AudioSource ShootingSource;
    [SerializeField] private AudioClip ShootingSound;

    private Transform player;
    private float lastShotTime;

    private void Start()
    {
        player = PlayerLocatorSingleton.Instance.transform;
    }

    private void Update()
    {
        if (player == null) return;

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= attackRange && Time.time - lastShotTime > fireRate)
        {
            Shoot();
            lastShotTime = Time.time;
        }
    }

    private void Shoot()
    {
        if (BulletSpawnPoint != null)
        {
            SpawnPhysicsBullet(BulletSpawnPoint);
        }
    }
}
