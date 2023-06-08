using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitNode : BehaviorNode {
    private float duration;
    private float timer;

    public WaitNode(float duration) {
        this.duration = duration;
        this.timer = 0f;
    }

    public override NodeStatus Evaluate() {
        // ʵ�ֵȴ�һ��ʱ����߼�
        timer += Time.deltaTime;
        if (timer >= duration) {
            timer = 0f;
            return NodeStatus.Success;
        }
        return NodeStatus.Running;
    }
}