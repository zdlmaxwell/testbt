using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
public class SequenceNode : ControlNode {

    public override NodeStatus Evaluate() {
        foreach (var node in childNodes) {
            NodeStatus status = node.Evaluate();
            if (status != NodeStatus.Success) {
                //Debug.Log("======SequenceNode:" + status);
                return status;
            }
        }
        return NodeStatus.Success;
    }
}
