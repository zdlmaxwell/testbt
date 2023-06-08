using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class IsFindNode : BehaviorNode {

    Blackboard blackboard = null;
    GameObject hud;
    private float timerLocal;
    private float timer;
    private LocationTarget locationTarget;
    public IsFindNode(Blackboard bb, int t) {
        blackboard = bb;
        hud = blackboard.GetValue<Transform>("hud").gameObject;
        timer = t;
        timerLocal = t;
        locationTarget = bb.GetValue<LocationTarget>("LocationTarget");
    }
    public override NodeStatus Evaluate() {

        if (hud.activeSelf == false) {
            Debug.Log("IsFindNode start");
            hud.SetActive(true);
            hud.GetComponent<TextMeshProUGUI>().text = "find apple";
        }
        // 更新计时器
        timerLocal -= Time.deltaTime;
        
        if (timerLocal <= 0f) {
            Debug.Log("IsFindNode done");
            hud.SetActive(false);
            locationTarget.canLeaveCurLocation = true;
            timerLocal = timer;
            return NodeStatus.Success;  
        }
        return NodeStatus.Running;
    }
}
