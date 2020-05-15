using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequence_FleeZombie : Sequence
{
   public Sequence_FleeZombie()
    {
        Sequence flee = new Sequence();
        flee.AddTask(new Task_Flee());
        flee.AddTask(new Sequence_DefaultFire());
        flee.AddTask(new Task_MoveBack());

        children.Add(flee);

    }

    public override TASK_RETURN_STATUS Run(Survivor_AI sAI)
    {
        base.Run(sAI);

        return TASK_RETURN_STATUS.SUCCESS;
    }
}
