using UnityEngine;

namespace Shmup {
    public abstract class WeaponStrategy : ScriptableObject {
        [SerializeField] int damage = 10;
        [SerializeField] float fireRate = 0.5f;
        [SerializeField] protected float projectileSpeed = 10f;
        [SerializeField] protected float projectileLifetime = 4f;
        [SerializeField] protected GameObject projectilePrefab;
        
        public int Damage => damage;
        public float FireRate => fireRate;

        public virtual void Initialize() {
            // no-op
        }

        public abstract void Fire(Transform firePoint, LayerMask layer);
    }
}