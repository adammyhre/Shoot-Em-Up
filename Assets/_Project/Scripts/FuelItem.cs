using UnityEngine;

namespace Shmup {
    public class FuelItem : Item {
        void OnTriggerEnter(Collider other) {
            other.GetComponent<Player>().AddFuel(amount);
            Destroy(gameObject);
        }
    }
}