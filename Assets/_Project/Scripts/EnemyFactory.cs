using UnityEngine;
using UnityEngine.Splines;

namespace Shmup {
    public class EnemyFactory {
        public GameObject CreateEnemy(EnemyType enemyType, SplineContainer spline) {
            EnemyBuilder builder = new EnemyBuilder()
                .SetBasePrefab(enemyType.enemyPrefab)
                .SetSpline(spline)
                .SetSpeed(enemyType.speed);

            // Weapons in Part 3
            
            return builder.Build();
        }
        
        // More factory methods, for example enemies that do not follow a spline
    }
}