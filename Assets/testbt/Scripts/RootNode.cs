using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum NodeStatus {
    Success,   // 表示节点成功执行
    Failure,   // 表示节点执行失败
    Running    // 表示节点正在运行中
}

public class RootNode : BehaviorNode {
    private BehaviorNode childNode;

    public override void AddChildNode(BehaviorNode node) {
        childNode = node;
    }

    public override NodeStatus Evaluate() {
        if (childNode != null) {
            return childNode.Evaluate();
        }

        return NodeStatus.Failure;
    }
}
