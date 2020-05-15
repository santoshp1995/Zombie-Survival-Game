using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task_MoveBack : Task
{
    public override TASK_RETURN_STATUS Run(Survivor_AI sAI)
    {

        TASK_RETURN_STATUS output = TASK_RETURN_STATUS.FAILURE;

        base.Run(sAI);

        if(sAI.GetBlackBoard().target.state == EnemyState.DEAD)
        {
            sAI.GetSurvivor().MoveTo(sAI.GetBlackBoard().currentSurvivorPosition);

            output = TASK_RETURN_STATUS.SUCCESS;
        }

        return output;
    }

}
