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
        public BlackBoard blackboard = new BlackBoard();

        public Node.State Update()
        {
            //check if the node has executed correctly
            if (rootNode.state == Node.State.RUNNING)
            {
                treeState = rootNode.Update();
            }

            return treeState;
        }
#if UNITY_EDITOR
        public Node CreateNode(System.Type type)
        {
            //create a new node
            Node node = ScriptableObject.CreateInstance(type) as Node;
            node.name = type.Name;
            node.guid = GUID.Generate().ToString();
            
            Undo.RecordObject(this, "Behaviour Tree (Create Node)");

            nodeList.Add(node);
            if (!Application.isPlaying)
            {
                AssetDatabase.AddObjectToAsset(node, this);
                
            }
            Undo.RegisterCreatedObjectUndo(node, "Behaviour Tree (Create Node)");
            AssetDatabase.SaveAssets();
            return node;
        }

        public void DeleteNode(Node node)
        {
            Undo.RecordObject(this, "Behaviour Tree (Delete Node)");
            nodeList.Remove(node);
            Undo.DestroyObjectImmediate(node);
            AssetDatabase.SaveAssets();
        }

        public void AddChild(Node parent, Node Child)
        {
            DecoratorNode decorator = parent as DecoratorNode;

            if(decorator)
            {
                Undo.RecordObject(decorator, "Behaviour Tree (Add Child)");
                decorator.child = Child;
                EditorUtility.SetDirty(decorator);
            }

            CompositeNode composite = parent as CompositeNode;

            if (composite)
            {
                Undo.RecordObject(composite, "Behaviour Tree (Add Child)");
                composite.Children.Add(Child);
                EditorUtility.SetDirty(composite);
            }

            RootNode rootNode = parent as RootNode;

            if (rootNode)
            {
                Undo.RecordObject(rootNode, "Behaviour Tree (Add Child)");
                rootNode.child = Child;
                EditorUtility.SetDirty(rootNode);
            }
        }
        
        public void RemoveChild(Node parent, Node Child)
        {
            DecoratorNode decorator = parent as DecoratorNode;

            if (decorator)
            {
                Undo.RecordObject(decorator, "Behaviour Tree (Removed Child)");
                decorator.child = null;
                EditorUtility.SetDirty(decorator);
            }

            CompositeNode composite = parent as CompositeNode;

            if (composite)
            {
                Undo.RecordObject(composite, "Behaviour Tree (Removed Child)");
                composite.Children.Remove(Child);
                EditorUtility.SetDirty(composite);
            }

            RootNode rootNode = parent as RootNode;

            if (rootNode)
            {
                Undo.RecordObject(rootNode, "Behaviour Tree (Removed Child)");
                rootNode.child = null;
                EditorUtility.SetDirty(rootNode);
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
#endif
        public void Traverse(Node node, System.Action<Node> visitor)
        {
            if(node)
            {
                visitor.Invoke(node);
                var children = GetChildren(node);
                children.ForEach((n) => Traverse(n, visitor)); 
            }
        }
        public BehaviourTree Clone()
        {
            BehaviourTree tree = Instantiate(this);
            tree.rootNode = tree.rootNode.Clone();
            tree.nodeList = new List<Node>();
            Traverse(tree.rootNode, (n) =>
            {
                tree.nodeList.Add(n);
            });
            return tree;
        }

        public void Bind(AIAgent agent)
        {
            Traverse(rootNode, node =>
            {
                node.blackboard = blackboard;
                node.agent = agent;
            });
        }
    }
}


