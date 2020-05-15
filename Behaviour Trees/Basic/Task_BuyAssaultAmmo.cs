using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task_BuyAssaultAmmo : Task
{
    public override TASK_RETURN_STATUS Run(Survivor_AI sAI)
    {
        TASK_RETURN_STATUS output = TASK_RETURN_STATUS.FAILURE;

        base.Run(sAI);

        if(GameManager.GetCurrentGold() >= GameManager.GetAssaultAmmoCost())
        {
            GameManager.PurchaseAmmo(WEAPON_TYPE.ASSAULT);

            output = TASK_RETURN_STATUS.SUCCESS;
        }

        return output;
    }
}
