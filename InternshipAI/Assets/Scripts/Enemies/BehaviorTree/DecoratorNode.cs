using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 namespace AI
{
    //blueprint for Decorator Nodes. these nodes "augment" the return value of their Single Child
    public abstract class DecoratorNode : Node
    {
        [HideInInspector] public Node child;
        public override Node Clone()
        {
            DecoratorNode node = Instantiate(this);
            node.child = child.Clone();
            return node;
        }
    }
}

