using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace AI
{
    /// <summary>
    /// Is the firts node, this start the tree
    /// </summary>
    public class Root : Node
    {
        [SerializeField]
        private Node child; //the next node

        private void Awake()
        {
            SetChilds();
        }

        /// <summary>
        /// Set and replica the basic parameters
        /// </summary>
        private void SetChilds()
        {
            Node[] nodes =  this.GetComponents<Node>();
            List<GameObject> enemys = GameObject.FindGameObjectsWithTag("Character").ToList();

            enemy = enemys.Find(t_enemy => t_enemy.GetComponent<Character>().CharacterName == "Player").GetComponent<Character>();

            foreach (Node t_node in nodes) {
                t_node.TargetAI = TargetAI;
                t_node.Enemy = enemy;
            }
        }

        /// <summary>
        /// Execute the child
        /// </summary>
        public override void Execute() {
            child.Execute();
        }

    }
}