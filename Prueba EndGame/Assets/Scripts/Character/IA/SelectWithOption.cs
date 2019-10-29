using UnityEngine;

namespace AI
{
    /// <summary>
    /// can execute two ways, depend on a check
    /// </summary>
    public abstract class SelectWithOption : Node
    {
        [SerializeField]
        private Node successTree;

        [SerializeField]
        private Node failTree;

        public abstract bool Check();

        /// <summary>
        /// Check and execute the correct way
        /// </summary>
        public override void Execute() 
        {
            if (Check())
            {
                successTree.Execute();
            }
            else
            {
                failTree.Execute();
            }
        }
    }
}