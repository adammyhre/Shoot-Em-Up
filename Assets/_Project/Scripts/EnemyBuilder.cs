using UnityEngine;
using UnityEngine.Splines;
using Utilities;

namespace Shmup {
    public class EnemyBuilder {
        GameObject enemyPrefab;
        SplineContainer spline;
        GameObject weaponPrefab;
        float speed;
        
        public EnemyBuilder SetBasePrefab(GameObject prefab) {
            enemyPrefab = prefab;
            return this;
        }
        
        public EnemyBuilder SetSpline(SplineContainer spline) {
            this.spline = spline;
            return this;
        }
        
        public EnemyBuilder SetWeaponPrefab(GameObject prefab) {
            weaponPrefab = prefab;
            return this;
        }
        
        public EnemyBuilder SetSpeed(float speed) {
            this.speed = speed;
            return this;
        }

        public GameObject Build() {
            GameObject instance = GameObject.Instantiate(enemyPrefab);
            
            SplineAnimate splineAnimate = instance.GetOrAdd<SplineAnimate>();
            splineAnimate.Container = spline;
            splineAnimate.AnimationMethod = SplineAnimate.Method.Speed;
            splineAnimate.ObjectUpAxis = SplineAnimate.AlignAxis.ZAxis;
            splineAnimate.ObjectForwardAxis = SplineAnimate.AlignAxis.YAxis;
            splineAnimate.MaxSpeed = speed;
            
            // Weapons in Part 3
            
            // Set instance transform to spline start position
            instance.transform.position = spline.EvaluatePosition(0f);
            // NOTE: if instantiating waves, could set the position along the spline in a staggered value 0f to 1f

            return instance;
        }
    }
}