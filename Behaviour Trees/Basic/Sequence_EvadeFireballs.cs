using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequence_EvadeFireballs : Sequence
{
    public Sequence_EvadeFireballs()
    {
        Sequence evadeFireballs = new Sequence();
        evadeFireballs.AddTask(new Task_Flee());
        evadeFireballs.AddTask(new Task_CheckFireballStatus());
        evadeFireballs.AddTask(new Task_MoveBack());

        children.Add(evadeFireballs);
    }


    public override TASK_RETURN_STATUS Run(Survivor_AI sAI)
    {
        base.Run(sAI);

        return TASK_RETURN_STATUS.SUCCESS;
    }
}
