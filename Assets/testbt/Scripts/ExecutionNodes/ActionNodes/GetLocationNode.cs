using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetLocationNode : BehaviorNode {

    private LocationTarget locationTarget;
    public GetLocationNode(Blackboard bb) {
        locationTarget = bb.GetValue<LocationTarget>("LocationTarget");
    }

    public override NodeStatus Evaluate() {

        if(locationTarget.targetLocation == null) {
            locationTarget.targetLocation = locationTarget.queueTarget.Peek();
        }

        if(locationTarget.curLocation == locationTarget.targetLocation && locationTarget.canLeaveCurLocation == true) {
            
            Transform transformLast = locationTarget.queueTarget.Dequeue();
            locationTarget.queueTarget.Enqueue(transformLast);
            locationTarget.canLeaveCurLocation = false;
            locationTarget.targetLocation = locationTarget.queueTarget.Peek();

            Debug.Log("====GetLocationNode:" + locationTarget.curLocation.name);

        }

        return NodeStatus.Success;

    }
}
