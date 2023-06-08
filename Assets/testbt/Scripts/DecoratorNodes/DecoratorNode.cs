using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DecoratorNode : BehaviorNode {
    protected BehaviorNode childNode;

    public override void AddChildNode(BehaviorNode node) {
        childNode = node;
    }
}
