using UnityEngine;

namespace AI
{
    /// <summary>
    /// check if the enemy is near
    /// </summary>
    public class IsEnemyNear : SelectWithOption
    {
        [SerializeField]
        private float distance;

        public override bool Check()
        {
            if (Vector3.Magnitude(TargetAI.gameObject.transform.position - Enemy.gameObject.transform.position) < distance)
            {
                return true;
            }
            else { //if the enemy is far, then stop shooting
                if (targetAI.Rifle.Shooting)
                {
                    targetAI.Rifle.StopShoot();
                }
                return false;
            }
            
        }
    }
}
