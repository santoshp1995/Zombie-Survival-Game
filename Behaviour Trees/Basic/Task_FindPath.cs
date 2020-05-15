using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task_FindPath : Task
{
    Pathfinding pathfinder = new Pathfinding();

    Vector3 targetPoint = new Vector3();


    public Task_FindPath(Vector3 destination, Survivor_AI sAI)
    {
        targetPoint = destination;

        Run(sAI);
    }

    public override TASK_RETURN_STATUS Run(Survivor_AI sAI)
    {
        TASK_RETURN_STATUS output = TASK_RETURN_STATUS.SUCCESS;

        FindPath(sAI, sAI.GetSurvivor().transform.position, targetPoint);
        

        return output;
    }

    void FindPath(Survivor_AI sAI, Vector3 startPoint, Vector3 endPoint)
    {
        List<PathNode> path = pathfinder.CreatePath(startPoint, endPoint);

        if (path != null)
        {
            for (int i = 0; i < path.Count; i++)
            {
                if(sAI.transform.position != path[i].transform.position)
                {
                    sAI.GetSurvivor().MoveTo(path[i].transform.position);
                }

                else
                {
                    // pop the current node of the list
                    path.Remove(path[i]);
                }
            }
        }
    }
}
