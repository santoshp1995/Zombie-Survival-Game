using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task_RunAll : Task
{
    public override TASK_RETURN_STATUS Run(Survivor_AI sAI)
    {
        for(int i = 0; i < children.Count; i++)
        {
            Task child = children[i];

            child.Run(sAI);
        }

        return TASK_RETURN_STATUS.SUCCESS;
    } 
}


