using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class IsChargeBatteryNode : BehaviorNode {

    Blackboard blackboard = null;
    GameObject hud;
    private float timerLocal;
    private float timer;
    private LocationTarget locationTarget;
    Robot robot;
    public IsChargeBatteryNode(Blackboard bb, int t) {
        blackboard = bb;
        hud = blackboard.GetValue<Transform>("hud").gameObject;
        timer = t;
        timerLocal = t;
        locationTarget = bb.GetValue<LocationTarget>("LocationTarget");
        robot = bb.GetValue<Robot>("robot");
    }
    public override NodeStatus Evaluate() {

        if (hud.activeSelf == false) {
            Debug.Log("IsChargeBatteryNode start");
            hud.SetActive(true);
            TextMeshProUGUI t = hud.GetComponent<TextMeshProUGUI>();
            t.text = "charging battery";
        }
        // 更新计时器
        timerLocal -= Time.deltaTime;
        
        if (timerLocal <= 0f) {
            Debug.Log("IsChargeBatteryNode done");
            robot.chargeBattery();
            hud.SetActive(false);
            locationTarget.canLeaveCurLocation = true;
            timerLocal = timer;
            return NodeStatus.Success;  
        }
        return NodeStatus.Running;
    }
}
