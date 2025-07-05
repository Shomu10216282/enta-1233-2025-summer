using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Vangard
{
    public class PhysicsBullet : MonoBehaviour
    {
        [SerializeField] private float ProjectileSpeed;

        [SerializeField] private int ProjectileDamage;

        [SerializeField] private Rigidbody Rb;

        private BaseBulletManager bulletManager;
        public void Initialize(BaseBulletManager manager)
        {
            bulletManager = manager;
        }

        // Start is called before the first frame update
        void Start()
        {

            Rb.AddForce(transform.forward * ProjectileSpeed, ForceMode.Impulse);
        }

        private void OnTriggerEnter(Collider collision)
        {
            if (collision.gameObject.tag == bulletManager.TargetTag)
            {
                var enemy = collision.GetComponent<AgentMoveToTransform>();
                if (enemy != null)
                {
                    enemy.TakeDamage(ProjectileDamage);
                    Debug.Log("Hit enemy! Damage: " + ProjectileDamage);
                }
                
                //ContactPoint contact = collision.GetContact(index: 0);
                bulletManager.OnProjectileCollision(position: collision.ClosestPoint(transform.position), rotation: collision.ClosestPoint(transform.position));
                Destroy(gameObject);
            }

            //var enemy = collision.collider.GetComponent<AgentMoveToTransform>();
            //if (enemy != null)
            //{
            //    enemy.TakeDamage(ProjectileDamage);
            //    Debug.Log("Hit enemy! Damage: " + ProjectileDamage);
            //}
            //ContactPoint contact = collision.GetContact(index: 0);
            //bulletManager.OnProjectileCollision(position: contact.point, rotation: contact.point);
            //Destroy(gameObject);
        }

    }
}