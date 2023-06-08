using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackNode : BehaviorNode {
    private GameObject target;

    public AttackNode(GameObject target) {
        this.target = target;
    }

    public override NodeStatus Evaluate() {
        // ʵ�ֹ���Ŀ����߼�
        Debug.Log("Attacking target: " + target.name);
        return NodeStatus.Success;
    }
}
