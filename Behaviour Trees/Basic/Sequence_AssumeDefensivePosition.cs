using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequence_AssumeDefensivePosition : Sequence
{
    Task moveToDefensivePositions = new Sequence();

    public Sequence_AssumeDefensivePosition(DefensePoint target)
    {
        moveToDefensivePositions.AddTask(new Task_MoveToDefensivePosition(target));
    }

    public override TASK_RETURN_STATUS Run(Survivor_AI sAI)
    {
        base.Run(sAI);
      
        return TASK_RETURN_STATUS.SUCCESS;
    }
}
