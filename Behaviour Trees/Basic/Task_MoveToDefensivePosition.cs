using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task_MoveToDefensivePosition : Task
{
    DefensePoint currentPoint = null;

    Task BT_PathFind = new Sequence();

    public Task_MoveToDefensivePosition(DefensePoint targetPoint)
    {
        currentPoint = targetPoint;
     //   BT_PathFind.AddTask(new Task_FindPath(currentPoint.transform.position));
    }

    public override TASK_RETURN_STATUS Run(Survivor_AI sAI)
    {
        TASK_RETURN_STATUS output = TASK_RETURN_STATUS.SUCCESS;

        Debug.Log("Testing");

        return output;
    }
}
