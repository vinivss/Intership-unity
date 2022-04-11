using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI
{
    public class GameManager : MonoBehaviour
    {
        public List<Transform> waypoints;
        private StateController[] _controllers;

        private void Start()
        {
            _controllers = FindObjectsOfType<StateController>();
            foreach(var controller in _controllers)
            {
                controller.InitializeAI(true, waypoints);
            }
        }
    }
}
