using UnityEngine;
using AI;
using UnityEditor.Experimental.GraphView;
using System;
public class NodeView : UnityEditor.Experimental.GraphView.Node
{
    public Action<NodeView> OnNodeSelected;
    public AI.Node node;
    public Port input;
    public Port output;
    public NodeView(AI.Node node)
    {
        this.node = node;
        this.title = node.name;
        this.viewDataKey = node.guid;
        style.left = node.pos.x;
        style.top = node.pos.y;

        CreateInputPorts();
        CreateOutputPorts();
    }

    private void CreateInputPorts()
    {
        if(node is ActionNode)
        {
            input = InstantiatePort(Orientation.Horizontal, Direction.Input, Port.Capacity.Single, typeof(bool));
        }
        else if(node is CompositeNode)
        {
            input = InstantiatePort(Orientation.Horizontal, Direction.Input, Port.Capacity.Single, typeof(bool));
        }
        else if (node is DecoratorNode)
        {
            input = InstantiatePort(Orientation.Horizontal, Direction.Input, Port.Capacity.Single, typeof(bool));
        }
        else if (node is RootNode)
        {
           
        }

        if (input!= null)
        {
            input.portName = "";
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
            output = InstantiatePort(Orientation.Horizontal, Direction.Output, Port.Capacity.Multi, typeof(bool));
        }
        else if (node is DecoratorNode)
        {
            output = InstantiatePort(Orientation.Horizontal, Direction.Output, Port.Capacity.Single, typeof(bool));
        }
        else if (node is RootNode)
        {
            output = InstantiatePort(Orientation.Horizontal, Direction.Output, Port.Capacity.Single, typeof(bool));
        }
        if (output != null)
        {
            output.portName = "";
            output.portColor = Color.red;
            outputContainer.Add(output);

        }

    }

    public override void SetPosition(Rect newPos)
    {
        base.SetPosition(newPos);
        node.pos.x = newPos.xMin;
        node.pos.y = newPos.yMin;
    }

    public override void OnSelected()
    {
        base.OnSelected();

        if(OnNodeSelected != null)
        {
            OnNodeSelected.Invoke(this);
        }
    }
}
