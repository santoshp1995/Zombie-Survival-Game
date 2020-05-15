using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task_Complete : Task
{
    public override TASK_RETURN_STATUS Run(Survivor_AI sAI)
    {
        sAI.SetBehaviorTree(new Sequence_DefaultFire());

        return TASK_RETURN_STATUS.SUCCESS;
    }
}
