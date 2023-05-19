using UnityEngine;
using Utilities;

namespace Shmup {
    [CreateAssetMenu(fileName = "PlayerTrackingShot", menuName = "Shmup/WeaponStrategy/PlayerTrackingShot")]
    public class TrackingShot : WeaponStrategy {
        [SerializeField] float trackingSpeed = 1f;
        
        Transform target;
        
        public override void Initialize() {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
        
        public override void Fire(Transform firePoint, LayerMask layer) {
            var projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
            projectile.transform.SetParent(firePoint);
            projectile.layer = layer;
            
            var projectileComponent = projectile.GetComponent<Projectile>();
            projectileComponent.SetSpeed(projectileSpeed);
            projectileComponent.Callback = () => {
                // get direction to target with same Z as firePoint
                Vector3 direction = (target.position - projectile.transform.position).With(z:0).normalized;
                
                // rotate forward, with Z as the UP direction (ie. 0, 0, 1 aka Vector3.forward)
                Quaternion rotation = Quaternion.LookRotation(direction, Vector3.forward);
                projectile.transform.rotation = Quaternion.Slerp(projectile.transform.rotation, rotation, trackingSpeed * Time.deltaTime);
            };
            
            Destroy(projectile, projectileLifetime);
        }
    }
}