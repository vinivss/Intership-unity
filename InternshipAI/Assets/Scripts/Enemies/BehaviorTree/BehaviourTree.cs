using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace AI
{
    //This tree will manage all of the nodes, their creations and other things
    [CreateAssetMenu(fileName = "Behaviour Tree", menuName = "Enemy AI/Behaviour Tree", order = 1)]
    public class BehaviourTree : ScriptableObject
    {
        public Node rootNode;
        public List<Node> nodeList = new List<Node>();
        public Node.State treeState = Node.State.RUNNING;


        public Node.State Update()
        {
            //check if the node has executed correctly
            if (rootNode.state == Node.State.RUNNING)
            {
                treeState = rootNode.Update();
            }

            return treeState;
        }
        public Node CreateNode(System.Type type)
        {
            //create a new node
            Node node = ScriptableObject.CreateInstance(type) as Node;
            node.name = type.Name;
            node.guid = GUID.Generate().ToString();
            nodeList.Add(node);
            AssetDatabase.AddObjectToAsset(node, this);
            AssetDatabase.SaveAssets();
            return node;
        }

        public void DeleteNode(Node node)
        {
            nodeList.Remove(node);
            AssetDatabase.RemoveObjectFromAsset(node);
            AssetDatabase.SaveAssets();
        }

        public void AddChild(Node parent, Node Child)
        {
            DecoratorNode decorator = parent as DecoratorNode;

            if(decorator)
            {
                decorator.child = Child;
            }

            CompositeNode composite = parent as CompositeNode;

            if (composite)
            {
                composite.Children.Add(Child);
            }

            RootNode rootNode = parent as RootNode;

            if (rootNode)
            {
                rootNode.child = Child;
            }
        }
        
        public void RemoveChild(Node parent, Node Child)
        {
            DecoratorNode decorator = parent as DecoratorNode;

            if (decorator)
            {
                decorator.child = null;
            }

            CompositeNode composite = parent as CompositeNode;

            if (composite)
            {
                composite.Children.Remove(Child);
            }

            RootNode rootNode = parent as RootNode;

            if (rootNode)
            {
                rootNode.child = null;
            }
        }

        public List<Node> GetChildren(Node parent)
        {
            DecoratorNode decorator = parent as DecoratorNode;
            List<Node> children = new List<Node>();
            if (decorator && decorator.child != null)
            {
                children.Add(decorator.child);
            }

            CompositeNode composite = parent as CompositeNode;

            if (composite)
            {
                return composite.Children;
            }

            RootNode rootNode = parent as RootNode;

            if (rootNode && rootNode.child != null)
            {
                children.Add(rootNode.child);
            }

            return children;
        }

        public BehaviourTree Clone()
        {
            BehaviourTree tree = Instantiate(this);
            tree.rootNode = tree.rootNode.Clone();
            return tree;
        }
    }
}


