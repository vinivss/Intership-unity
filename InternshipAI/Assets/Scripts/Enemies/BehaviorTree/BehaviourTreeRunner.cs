using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI;
//thing that will actually execute the Behaviour tree
public class BehaviourTreeRunner : MonoBehaviour
{
   public BehaviourTree tree;
    // Start is called before the first frame update
    void Start()
    {
        tree = tree.Clone();
        tree.Bind(GetComponent<AIAgent>());
    }

    // Update is called once per frame
    void Update()
    {
        tree.Update();
    }
}
