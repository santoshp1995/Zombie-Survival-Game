using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task_Flee : Task
{
    public override TASK_RETURN_STATUS Run(Survivor_AI sAI)
    {
        TASK_RETURN_STATUS output = TASK_RETURN_STATUS.FAILURE;

        if(sAI.GetBlackBoard().target.state != EnemyState.DEAD)
        {
            Vector3 runTo = sAI.GetSurvivor().transform.position + ((sAI.GetSurvivor().transform.position -
           sAI.GetBlackBoard().target.gameObject.transform.position) * 5);

            sAI.GetSurvivor().MoveTo(runTo);

            output = TASK_RETURN_STATUS.SUCCESS;
        }

        return output;
    }
}
