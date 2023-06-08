using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



public class TestBT1 : MonoBehaviour
{
    public Robot robot;
    public GameObject hud;
    // Start is called before the first frame update
    public LocationTarget locationTarget = new LocationTarget();
    public GameObject t1;
    public GameObject t2;
    public GameObject t3;
    public GameObject t4;

    private BehaviorNode root = new RootNode();
    private BehaviorNode rootBattery = new RootNode();

    Blackboard blackboard = new Blackboard();
    void Start()
    {
        locationTarget.queueTarget.Enqueue(t1.transform);
        locationTarget.queueTarget.Enqueue(t2.transform);
        locationTarget.queueTarget.Enqueue(t3.transform);

        blackboard.SetValue<Transform>("Transform", transform);
        blackboard.SetValue<LocationTarget>("LocationTarget", locationTarget);
        blackboard.SetValue<Transform>("hud", hud.transform);
        blackboard.SetValue<Robot>("robot", robot);

        hud.SetActive(false);
        RepeatNode rNode = new RepeatNode(locationTarget.queueTarget.Count);
        root.AddChildNode(rNode);

        SequenceNode sqNode = new SequenceNode();
        rNode.AddChildNode(sqNode);

        GetLocationNode getLocNode = new GetLocationNode(blackboard);
        sqNode.AddChildNode(getLocNode);

        SelectorNode seNode = new SelectorNode();
        sqNode.AddChildNode(seNode);

        IsLocationNode isLNode = new IsLocationNode(blackboard);
        seNode.AddChildNode(isLNode);

        MoveNode mMode = new MoveNode(blackboard, 5f);
        seNode.AddChildNode(mMode);

        IsFindNode isFNode = new IsFindNode(blackboard, 2);
        sqNode.AddChildNode(isFNode);

        //======================
        SequenceNode sqNode2 = new SequenceNode();
        rootBattery.AddChildNode(sqNode2);

        SelectorNode seNode2 = new SelectorNode();
        sqNode2.AddChildNode(seNode2);

        IsLocationNode isLNode2 = new IsLocationNode(blackboard);
        seNode2.AddChildNode(isLNode2);

        MoveNode mMode2 = new MoveNode(blackboard, 10f);
        seNode2.AddChildNode(mMode2);

        IsChargeBatteryNode isCNode2 = new IsChargeBatteryNode(blackboard, 2);
        sqNode2.AddChildNode(isCNode2);
    }

    // Update is called once per frame
    void Update()
    {
        if (robot.isBatteryLow() == true) {
            locationTarget.targetLocation = t4.transform;
            rootBattery.Evaluate();
        } else {
            locationTarget.targetLocation = locationTarget.queueTarget.Peek();
            root.Evaluate();
        }
    }
}
