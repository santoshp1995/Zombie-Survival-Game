using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task_BuySurvivors : Task
{
    public override TASK_RETURN_STATUS Run(Survivor_AI sAI)
    {
        TASK_RETURN_STATUS output = TASK_RETURN_STATUS.FAILURE;

        base.Run(sAI);

        if(GameManager.GetCurrentGold() >= GameManager.GetSurvivorCost())
        {
            GameManager.PurchaseSurvivor();
            
            output = TASK_RETURN_STATUS.SUCCESS;
        }

        return output;
    }
}
