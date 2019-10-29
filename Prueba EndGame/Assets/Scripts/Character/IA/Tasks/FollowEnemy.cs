
namespace AI
{
    /// <summary>
    /// Allow set the enemy like the new navegation destiny
    /// </summary>
    public class FollowEnemy : Node
    {
        public override void Execute()
        {
            (TargetAI.ControlMov as ControlMovIA).Mov(enemy.transform.position);
        }
    }
}
