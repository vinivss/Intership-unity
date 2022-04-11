using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AI
{
    // bueprint for the Composite Nodes. can be if statement or loops, mostly work as conditionals for its multiple children
    public abstract class CompositeNode : Node
    {
        [HideInInspector] public List<Node> Children = new List<Node>();
        public override Node Clone()
        {
            CompositeNode node = Instantiate(this);
            node.Children =  Children.ConvertAll(c => c.Clone());
            return node;
        }
    }
}

