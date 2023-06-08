using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectorNode : ControlNode {

    public override NodeStatus Evaluate() {
        foreach (var node in childNodes) {
            NodeStatus status = node.Evaluate();
            if (status == NodeStatus.Success)
                return NodeStatus.Success;
            if (status == NodeStatus.Running)
                return NodeStatus.Running;
        }
        return NodeStatus.Failure;
    }
}
