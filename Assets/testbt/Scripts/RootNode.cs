using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum NodeStatus {
    Success,   // ��ʾ�ڵ�ɹ�ִ��
    Failure,   // ��ʾ�ڵ�ִ��ʧ��
    Running    // ��ʾ�ڵ�����������
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
