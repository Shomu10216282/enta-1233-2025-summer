using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Vangard
{
    public class BulletManager : BaseBulletManager
    {
        [Header("External Scripts")]
        [SerializeField] private Camera Cam;
        [SerializeField] private VangardInputs Inputs;

        [Header("Raycast")]
        [SerializeField] private LayerMask RaycastMask;
        [SerializeField] private ShootType ShootingCalculation;

        [Header("Sound")]
        [SerializeField] private AudioSource ShootingSource;
        [SerializeField] private AudioClip ShootingSound;

        public enum ShootType
        {
            Raycast = 0,
            Physics = 1,
        }

        public int damage = 20;

        public void Update()
        {
            if (Inputs.Aim && Inputs.Shoot)
            {
                OnShootPressed();
            }
            Inputs.Shoot = false;
        }

        public void OnShootPressed()
        {
            Debug.Log("Shooting projectile");
            switch (ShootingCalculation)
            {
                case ShootType.Raycast:
                    DoRaycastShot();
                    break;
                case ShootType.Physics:
                    Debug.Log("StartShooting");
                    SpawnPhysicsBullet(Cam.transform);
                    ShootingSource.PlayOneShot(ShootingSound);
                    Debug.Log("GunShooting");
                    break;
                default:
                    Debug.LogError("Unexpected value");
                    break;
            }
        }

        public void DoRaycastShot()
        {
            Ray ray = new Ray(Cam.transform.position, Cam.transform.forward);
            if (Physics.Raycast(ray, out RaycastHit hit, 100f, RaycastMask))
            {
                Debug.Log("Raycast Hit: " + hit.collider.name);
                OnProjectileCollision(hit.point, hit.normal);

                var enemy = hit.collider.GetComponent<AgentMoveToTransform>();
                if (enemy != null)
                {
                    enemy.TakeDamage(damage);
                    Debug.Log("Hit enemy! Damage: " + damage);
                }
            }
            else
            {
                Debug.Log("Raycast Miss");
            }
        }

        public void OnDrawGizmos()
        {
            if (Inputs != null && Inputs.Aim && Cam != null)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawRay(Cam.transform.position, Cam.transform.forward * 100);
            }
        }

        public void CleanupParticle()
        {
            // Particle cleanup placeholder
        }
    }
}
