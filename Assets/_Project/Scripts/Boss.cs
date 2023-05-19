using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Shmup {
    public class Boss : MonoBehaviour {
        [SerializeField] float maxHealth = 100f;
        [SerializeField] GameObject explosionPrefab;
        float health;
        
        Collider bossCollider;

        public List<BossStage> Stages;
        int currentStage = 0;

        public event Action OnHealthChanged;

        void Awake() => bossCollider = GetComponent<Collider>();

        void Start() {
            health = maxHealth;
            bossCollider.enabled = true;
            
            foreach (var system in Stages.SelectMany(stage => stage.enemySystems)) {
                system.OnSystemDestroyed.AddListener(CheckStageComplete);
            }
            
            InitializeStage();
        }
        
        public float GetHealthNormalized() => health / maxHealth;

        void CheckStageComplete() {
            if (Stages[currentStage].IsStageComplete()) {
                AdvanceToNextStage();
            }
        }

        void AdvanceToNextStage() {
            currentStage++;
            bossCollider.enabled = true;
            
            if (currentStage < Stages.Count) {
                InitializeStage();
            }
        }

        void InitializeStage() {
            Stages[currentStage].InitializeStage();
            bossCollider.enabled = !Stages[currentStage].IsBossInvulnerable;
        }

        void OnCollisionEnter(Collision other) {
            health -= 10;
            OnHealthChanged?.Invoke();
            if (health <= 0) {
                BossDefeated();
            }
        }

        void BossDefeated() {
            Debug.Log("Boss defeated!");
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        }
    }
}