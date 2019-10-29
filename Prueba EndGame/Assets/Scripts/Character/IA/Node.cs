using UnityEngine;
using System.Collections;

namespace AI
{
	public abstract class Node : MonoBehaviour 
	{

        [SerializeField]
        protected Character targetAI;// The character controlled by this system
        protected Character enemy; 
        
        public Character TargetAI
        {
            get { return targetAI; }
            set { targetAI = value; }
        }
        public Character Enemy
        {
            get { return enemy; }
            set { enemy = value; }
        }

        public abstract void Execute ();
	}
}