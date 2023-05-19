using UnityEngine;
using UnityEngine.UI;

namespace Shmup {
    public class BossHealthBar : MonoBehaviour {
        [SerializeField] Boss boss;
        [SerializeField] Image healthBar;

        void Awake() {
            boss.OnHealthChanged += OnHealthChanged;
        }
        
        void OnHealthChanged() {
            healthBar.fillAmount = boss.GetHealthNormalized();
        }
    }
}