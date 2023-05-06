using System;
using UnityEngine;
using Utilities;

namespace Shmup {
    public abstract class Weapon : MonoBehaviour {
        [SerializeField] protected WeaponStrategy weaponStrategy;
        [SerializeField] protected Transform firePoint;
        [SerializeField, Layer] protected int layer;
        
        void OnValidate() => layer = gameObject.layer;
        
        void Start() => weaponStrategy.Initialize();
        
        public void SetWeaponStrategy(WeaponStrategy strategy) {
            weaponStrategy = strategy;
            weaponStrategy.Initialize();
        }
    }
}