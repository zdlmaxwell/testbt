using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BehaviorNode {
    public abstract NodeStatus Evaluate();
    public virtual void AddChildNode(BehaviorNode node) {
    
    }
}
