using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vangard;

namespace Vangard
{
    public class BaseBulletManager : MonoBehaviour
    {
        [Header("Physics Bullets")]
        [SerializeField] protected PhysicsBullet PhysicsBulletPrefab;
        [Header("Particle")]
        [SerializeField] protected RaycastBullet BulletParticle;
        [SerializeField] public string TargetTag;

        protected void SpawnPhysicsBullet(Transform shootersTransform)
        {
            PhysicsBullet BulletShoot = Instantiate(PhysicsBulletPrefab, shootersTransform.position, shootersTransform.rotation);

            BulletShoot.Initialize(this);
        }

        public void OnProjectileCollision(Vector3 position, Vector3 rotation)
        {
            SpawnParticle(position, rotation);
        }


        public void SpawnParticle(Vector3 position, Vector3 rotation)
        {
            Instantiate(BulletParticle, position, Quaternion.Euler(rotation));
        }


    }
}