using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cory.TowerGame.Enemies
{
    public class Node : MonoBehaviour
    {
        [SerializeField] private Node[] nodes = new Node[0];

        private int nextNodeIndex;

        // get a node
        public Node NextNode
        {
            get 
            {
                // check if we are at the last node
                if (nodes.Length == 0) { return null; }

                Node nextNode = nodes[nextNodeIndex];

                // the next one after we try to increase
                // if their is another one go there
                if (nextNodeIndex + 1 != nodes.Length)
                {
                    nextNodeIndex++;
                } else
                {
                    // go back to the start
                    nextNodeIndex = 0;
                }

                return nextNode;    
            }
        }

        #region Debug
        /// <summary>
        /// Drawing a color wire sphere in the Editor
        /// </summary>
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.white;
            // offset off the ground
            Vector3 myPosition = transform.position + new Vector3(0f, 0.5f, 0f);
            Gizmos.DrawWireSphere(myPosition, 0.5f);

            foreach (var node in nodes)
            {
                // draw a line to connect the nodes
                Gizmos.DrawLine(myPosition, node.transform.position + new Vector3(0f, 0.5f, 0f));
            }

        }
        #endregion 
    }
}