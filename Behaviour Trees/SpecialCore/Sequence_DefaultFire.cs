using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequence_DefaultFire : Sequence
{
    public Sequence_DefaultFire()
    {
        Task enemySelector = new Selector();

        enemySelector.AddTask(new Task_FindClosestTarget());
        children.Add(new Task_UsePistol());
        children.Add(enemySelector);
        children.Add(new Task_IsEnemyVisible());
        children.Add(new Task_FireAtEnemy());
    }


    public override TASK_RETURN_STATUS Run(Survivor_AI sAI)
    {
        base.Run(sAI);

        return TASK_RETURN_STATUS.SUCCESS;
    }
}
