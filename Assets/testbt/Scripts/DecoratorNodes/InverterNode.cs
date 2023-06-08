using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InverterNode : DecoratorNode {
    public override NodeStatus Evaluate() {
        NodeStatus childStatus = childNode.Evaluate();

        if (childStatus == NodeStatus.Success)
            return NodeStatus.Failure;
        if (childStatus == NodeStatus.Failure)
            return NodeStatus.Success;

        return childStatus;
    }
}
