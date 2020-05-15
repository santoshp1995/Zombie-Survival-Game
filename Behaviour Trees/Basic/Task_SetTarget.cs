using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task_SetTarget : Task
{
    Enemy enemyTarget;
    public Task_SetTarget(Enemy e)
    {
        enemyTarget = e;
    }

    public override TASK_RETURN_STATUS Run(Survivor_AI sAI)
    {
        TASK_RETURN_STATUS output = TASK_RETURN_STATUS.FAILURE;

        if (enemyTarget.getState() == EnemyState.NORMAL)
        {
            sAI.GetBlackBoard().target = enemyTarget;
            output = TASK_RETURN_STATUS.SUCCESS;
        }
        return output;
    }
}
