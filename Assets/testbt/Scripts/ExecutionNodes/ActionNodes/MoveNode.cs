using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveNode : BehaviorNode {
    private Vector3 targetPosition;

    private Transform curTransform;
    private float moveSpeed;
    private LocationTarget locationTarget;
    public MoveNode(Blackboard bb, float speed) {
        curTransform = bb.GetValue<Transform>("Transform");
        moveSpeed = speed;
        locationTarget = bb.GetValue<LocationTarget>("LocationTarget");
    }

    public override NodeStatus Evaluate() {
        Transform targetTransform = locationTarget.targetLocation;
        if (targetTransform == null) {
            return NodeStatus.Failure;
        }

        // ��ȡ��ǰλ�ú�Ŀ��λ��
        //Vector3 currentPosition = transform.position;
        Vector3 targetPosition = targetTransform.position;

        // �����ƶ�����;���
        Vector3 moveDirection = (targetPosition - curTransform.position).normalized;
        float distance = Vector3.Distance(curTransform.position, targetPosition);

        // ִ���ƶ�
        curTransform.Translate(moveDirection * moveSpeed * Time.deltaTime);

        // ����Ƿ񵽴�Ŀ��λ��
        if (distance <= 0.1f) {
            Debug.Log("MoveNode done");
            locationTarget.curLocation = locationTarget.targetLocation;
            locationTarget.canLeaveCurLocation = false;
            return NodeStatus.Success;
        }

        return NodeStatus.Running;
    }
}
