using UnityEngine;
using AI;
using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;
using UnityEditor.UIElements;
using System;
using UnityEditor;
public class NodeView : UnityEditor.Experimental.GraphView.Node
{
    public Action<NodeView> OnNodeSelected;
    public AI.Node node;
    public Port input;
    public Port output;
    public NodeView(AI.Node node) :base("Assets/EditorWindows/NodeView.uxml")
    {
        this.node = node;
        this.title = node.name;
        this.viewDataKey = node.guid;
        style.left = node.pos.x;
        style.top = node.pos.y;

        CreateInputPorts();
        CreateOutputPorts();
        SetupClasses();
        Label descriptionLabel = this.Q<Label>("description");
        descriptionLabel.bindingPath = "description";
        descriptionLabel.Bind(new SerializedObject(node));
    }

    private void SetupClasses()
    {
        if (node is ActionNode)
        {
            AddToClassList("action");
        }
        else if (node is CompositeNode)
        {
            AddToClassList("composite");
        }
        else if (node is DecoratorNode)
        {
            AddToClassList("decorator");
        }
        else if (node is RootNode)
        {
            AddToClassList("root");
        }
    }

    private void CreateInputPorts()
    {
        if(node is ActionNode)
        {
            input = InstantiatePort(Orientation.Vertical, Direction.Input, Port.Capacity.Single, typeof(bool));
        }
        else if(node is CompositeNode)
        {
            input = InstantiatePort(Orientation.Vertical, Direction.Input, Port.Capacity.Single, typeof(bool));
        }
        else if (node is DecoratorNode)
        {
            input = InstantiatePort(Orientation.Vertical, Direction.Input, Port.Capacity.Single, typeof(bool));
        }
        else if (node is RootNode)
        {
           
        }

        if (input!= null)
        {
            input.portName = "";
            input.style.flexDirection = FlexDirection.Column;
            input.portColor = Color.blue;
            inputContainer.Add(input);

        }

    }

    private void CreateOutputPorts()
    {
        if (node is ActionNode)
        {

        }
        else if (node is CompositeNode)
        {
            output = InstantiatePort(Orientation.Vertical, Direction.Output, Port.Capacity.Multi, typeof(bool));
        }
        else if (node is DecoratorNode)
        {
            output = InstantiatePort(Orientation.Vertical, Direction.Output, Port.Capacity.Single, typeof(bool));
        }
        else if (node is RootNode)
        {
            output = InstantiatePort(Orientation.Vertical, Direction.Output, Port.Capacity.Single, typeof(bool));
        }
        if (output != null)
        {
            output.portName = "";
            output.style.flexDirection = FlexDirection.ColumnReverse;
            output.portColor = Color.red;
            outputContainer.Add(output);

        }

    }

    public override void SetPosition(Rect newPos)
    {
        base.SetPosition(newPos);
        Undo.RecordObject(node, "Behaviour Tree (Set Pos)");
        node.pos.x = newPos.xMin;
        node.pos.y = newPos.yMin;
        EditorUtility.SetDirty(node);
    }

    public override void OnSelected()
    {
        base.OnSelected();

        if(OnNodeSelected != null)
        {
            OnNodeSelected.Invoke(this);
        }
    }

    public void SortChildren()
    {
        CompositeNode composite = node as CompositeNode;

        if(composite)
        {
            composite.Children.Sort(SortByHorizontalPosition);
        }

    }

    private int SortByHorizontalPosition(AI.Node left, AI.Node right)
    {
        return left.pos.x < right.pos.x ? -1 : 1;
    }

    public void UpdateState()
    {
        RemoveFromClassList("running");
        RemoveFromClassList("fail");
        RemoveFromClassList("success");
        if (Application.isPlaying)
        {
            switch (node.state)
            {
                case AI.Node.State.RUNNING:
                    if (node.started)
                    {
                        AddToClassList("running");
                    }
                    break;
                case AI.Node.State.FAIL:
                    AddToClassList("fail");
                    break;
                case AI.Node.State.SUCCESS:
                    AddToClassList("success");
                    break;
            }
        }

    }
}
