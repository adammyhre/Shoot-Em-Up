using UnityEngine;

namespace Shmup {
    public class HealthItem : Item {
        void OnTriggerEnter(Collider other) {
            other.GetComponent<Player>().AddHealth((int) amount);
            Destroy(gameObject);
        }
    }
}