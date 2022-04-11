using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI;

    // will just shoot messages to the console
    public class DebugLogNode : ActionNode
    {
        public string message;
        protected override void OnStart()
        {
            Debug.Log($"OnStart{message}");

        }

        protected override void OnStop()
        {
            Debug.Log($"OnStop{message}");
        }

        protected override State OnUpdate()
        {
            Debug.Log($"OnStop{message}");
            return State.SUCCESS;
        }
    }

