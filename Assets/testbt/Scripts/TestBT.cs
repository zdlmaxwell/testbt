using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LocationTarget {
    public Transform curLocation = null;
    public Queue<Transform> queueTarget = new Queue<Transform>();
    public bool canLeaveCurLocation = false;
    public Transform targetLocation = null;
}

public class TestBT : MonoBehaviour
{
    public GameObject hud;
    // Start is called before the first frame update
    public LocationTarget locationTarget = new LocationTarget();
    public GameObject t1;
    public GameObject t2;
    public GameObject t3;

    private BehaviorNode root = new RootNode();
    Blackboard blackboard = new Blackboard();
    void Start()
    {
        locationTarget.queueTarget.Enqueue(t1.transform);
        locationTarget.queueTarget.Enqueue(t2.transform);
        locationTarget.queueTarget.Enqueue(t3.transform);

        blackboard.SetValue<Transform>("Transform", transform);
        blackboard.SetValue<LocationTarget>("LocationTarget", locationTarget);
        blackboard.SetValue<Transform>("hud", hud.transform);

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

        IsFindNode isFNode = new IsFindNode(blackboard, 4);
        sqNode.AddChildNode(isFNode);
    }

    // Update is called once per frame
    void Update()
    {
        root.Evaluate();

    }
}
