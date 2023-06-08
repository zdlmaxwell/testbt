using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallelNode : ControlNode {

    public override NodeStatus Evaluate() {
        bool anyRunning = false;
        bool allSuccess = true;

        foreach (var node in childNodes) {
            NodeStatus status = node.Evaluate();

            if (status == NodeStatus.Failure) {
                allSuccess = false;
            } else if (status == NodeStatus.Running) {
                anyRunning = true;
            }
        }

        if (allSuccess)
            return NodeStatus.Success;
        if (anyRunning)
            return NodeStatus.Running;
        return NodeStatus.Failure;
    }
}
