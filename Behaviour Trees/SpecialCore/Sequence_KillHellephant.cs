using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequence_KillHellephant : Sequence
{
    Enemy targetedHellephant;

    public Sequence_KillHellephant(Enemy e)
    {
        targetedHellephant = e;

        children.Add(new Task_SetTarget(targetedHellephant));
        children.Add(new Task_IsEnemyVisible());

        Task weaponSelector = new Selector();
        weaponSelector.AddTask(new Task_UseShotgun());
        weaponSelector.AddTask(new Task_UsePistol());

        children.Add(weaponSelector);

        children.Add(new Task_FireAtEnemy());
    }

    public override TASK_RETURN_STATUS Run(Survivor_AI sAI)
    {
         base.Run(sAI);

        return TASK_RETURN_STATUS.SUCCESS;
    }
}
