using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsLocationNode : BehaviorNode {

    Blackboard blackboard = null;
    private LocationTarget locationTarget;
    public IsLocationNode(Blackboard bb) {
        blackboard = bb;
        locationTarget = bb.GetValue<LocationTarget>("LocationTarget");
    }
    public override NodeStatus Evaluate() {
        if(locationTarget.curLocation == locationTarget.targetLocation) {
            return NodeStatus.Success;
        }

        return NodeStatus.Failure;
    }
}
