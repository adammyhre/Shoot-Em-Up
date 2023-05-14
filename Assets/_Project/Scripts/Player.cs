using UnityEngine;

namespace Shmup {
    public class Player : Plane {
        [SerializeField] float maxFuel;
        [SerializeField] float fuelConsumptionRate;
        
        float fuel;
        
        void Start() => fuel = maxFuel;

        public float GetFuelNormalized() => fuel / maxFuel;
        
        void Update() {
            fuel -= fuelConsumptionRate * Time.deltaTime;
        }
        
        public void AddFuel(float amount) {
            fuel += amount;
            if (fuel > maxFuel) {
                fuel = maxFuel;
            }
        }

        protected override void Die() {
            // TODO: Implement VFX?  Freeze Controls?
        }
    }
}