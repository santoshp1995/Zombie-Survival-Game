using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task_IsTargetAlive : Task
{
    public override TASK_RETURN_STATUS Run(Survivor_AI sAI)
    {
        TASK_RETURN_STATUS output = TASK_RETURN_STATUS.FAILURE;

        BlackBoard bd = sAI.GetBlackBoard();

        if(bd.target != null)
        {
            if(bd.target.getState() == EnemyState.NORMAL)
            {
                output = TASK_RETURN_STATUS.SUCCESS;
            }
        }
        return output;
    }
}
