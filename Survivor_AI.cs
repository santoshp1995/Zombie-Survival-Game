using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Survivor_AI : MonoBehaviour
{
    Survivor survivor;

    Task brain;
    BlackBoard blackboard;

    public float enemyHeightOffset = 0.5f;
    public float enemySearchRadius = 50;
    public float fireBallSearchRadius = 50;

    public DefensePoint currDefensePoint;

    Task BT_Fire;

    // Start is called before the first frame update
    void Start()
    {
        survivor = GetComponent<Survivor>();

        blackboard = new BlackBoard();

        BT_Fire = new Sequence_DefaultFire();

        brain = BT_Fire;

        currDefensePoint = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (survivor.debugmode == DEBUGMODE.DISABLED)
        {
            brain.Run(this);
        }
    }

    public BlackBoard GetBlackBoard()
    {
        return blackboard;
    }

    public Survivor GetSurvivor()
    {
        return survivor;
    }

    public void SetBehaviorTree(Task t)
    {
        brain = t;
    }
}