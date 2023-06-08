using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ControlNode : BehaviorNode {
    protected List<BehaviorNode> childNodes = new List<BehaviorNode>();

    public override void AddChildNode(BehaviorNode node) {
        childNodes.Add(node);
    }
}
