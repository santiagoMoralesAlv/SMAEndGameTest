using UnityEngine;
using System.Collections;

namespace AI
{
    /// <summary>
    /// Execute the root, the firts node
    /// </summary>
	public class BehaviourRunner: MonoBehaviour
	{
		[SerializeField]
		private Root root; 

		[SerializeField]
		private float stepTime;

		private float elapsedTime;

		private void Update () //work with a time rate
		{
            elapsedTime += Time.deltaTime;
            if (elapsedTime >= stepTime)
            {
                root.Execute();
                elapsedTime = 0f;
            }
		}
	}
}
