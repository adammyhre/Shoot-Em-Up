using System;
using UnityEngine;

namespace Shmup {
    public class Projectile : MonoBehaviour {
        [SerializeField] float speed;
        [SerializeField] GameObject muzzlePrefab;
        [SerializeField] GameObject hitPrefab;

        Transform parent;
        
        public void SetSpeed(float speed) => this.speed = speed;
        public void SetParent(Transform parent) => this.parent = parent;

        public Action Callback;
        
        void Start() {
            if (muzzlePrefab != null) {
                var muzzleVFX = Instantiate(muzzlePrefab, transform.position, Quaternion.identity);
                muzzleVFX.transform.forward = gameObject.transform.forward;
                muzzleVFX.transform.SetParent(parent);
                
                DestroyParticleSystem(muzzleVFX);
                
            }
        }
        
        void Update() {
            transform.SetParent(null);
            transform.position += transform.forward * (speed * Time.deltaTime);
            
            Callback?.Invoke();
        }

        void OnCollisionEnter(Collision collision) {
            if (hitPrefab != null) {
                ContactPoint contact = collision.contacts[0];
                var hitVFX = Instantiate(hitPrefab, contact.point, Quaternion.identity);
                
                DestroyParticleSystem(hitVFX);
            }
            
            var plane = collision.gameObject.GetComponent<Plane>();
            if (plane != null) {
                plane.TakeDamage(10);
            }

            Destroy(gameObject);
        }
        
        void DestroyParticleSystem(GameObject vfx) {
            var ps = vfx.GetComponent<ParticleSystem>();
            if (ps == null) {
                ps = vfx.GetComponentInChildren<ParticleSystem>();
            }
            Destroy(vfx, ps.main.duration);
        }
    }
}