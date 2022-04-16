using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI

{
    // base node that we will use for the tree. We therefore need it to be abstract (a class that is not fully implemented [expecting overrides]).
    public abstract class Node : ScriptableObject
    {
        //enum that stores all the possible conditions of the Node
        public enum State
        {
            RUNNING,
            FAIL,
            SUCCESS

        }

        //initialize it to Running
       [HideInInspector] public State state = State.RUNNING;
        //forth possible not quite state, it tells me if this node has been executed
       [HideInInspector] public bool started = false;
        //having a randomized GUI id
       [HideInInspector] public string guid;
        // position in the GUI
       [HideInInspector] public Vector2 pos;
        //pos of the black board
        [HideInInspector] public BlackBoard blackboard;
        //ai agent
        [HideInInspector]public AIAgent agent;
        //Scriptable object binding
        [TextArea] public string description;


        public State Update()
        {
            //check if the state has been started
            if (!started)
            {
                OnStart();
                started = true;
            }

            state = OnUpdate();

            // check to see if the node has finished
            if (state == State.FAIL || state == State.SUCCESS)
            {
                OnStop();
                started = false;
            }


            return state;
        }

        public virtual Node Clone()
        {
            return Instantiate(this);
        }
        //all subtypes of node will implement these functions
        protected abstract void OnStart();
        protected abstract void OnStop();
        protected abstract State OnUpdate();
    }
}