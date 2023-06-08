using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackNode : BehaviorNode {
    private GameObject target;

    public AttackNode(GameObject target) {
        this.target = target;
    }

    public override NodeStatus Evaluate() {
        // 实现攻击目标的逻辑
        Debug.Log("Attacking target: " + target.name);
        return NodeStatus.Success;
    }
}
