using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatNode : DecoratorNode {
    private int repeatCount;
    private int currentCount;

    public RepeatNode(int count) {
        repeatCount = count;
        currentCount = 0;
    }

    public override NodeStatus Evaluate() {
        if (currentCount < repeatCount) {
            NodeStatus childStatus = childNode.Evaluate();
            if (childStatus == NodeStatus.Success || childStatus == NodeStatus.Failure) {
                Debug.Log("=======repeated node:"+ currentCount + " done");
                currentCount++;
            }
            return NodeStatus.Running;
        } else {
            return NodeStatus.Success;
        }
    }
}
