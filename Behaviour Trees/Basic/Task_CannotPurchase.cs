using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task_CannotPurchase : Task
{
    public override TASK_RETURN_STATUS Run(Survivor_AI sAI)
    {
        base.Run(sAI);

        return TASK_RETURN_STATUS.SUCCESS;
    }
}
