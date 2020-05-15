using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task_SpendGold : Task
{
    public override TASK_RETURN_STATUS Run(Survivor_AI sAI)
    {
        TASK_RETURN_STATUS output = TASK_RETURN_STATUS.FAILURE;

        if(GameManager.GetBreakTimeRemaining() > 0)
        {
            SpendGoldOnAmmo();

            output = TASK_RETURN_STATUS.SUCCESS;
        }

        return output;

    }

    void SpendGoldOnAmmo()
    {
        if(GameManager.GetAmmo(WEAPON_TYPE.SNIPER) <= 6 && GameManager.GetCurrentGold() >= GameManager.GetSniperAmmoCost())
        {
            GameManager.PurchaseAmmo(WEAPON_TYPE.SNIPER);
        }

        else if(GameManager.GetAmmo(WEAPON_TYPE.SHOTGUN) <= 3 && GameManager.GetCurrentGold() >= GameManager.GetShotgunAmmoCost())
        {
            GameManager.PurchaseAmmo(WEAPON_TYPE.SHOTGUN);
        }

        else if(GameManager.GetAmmo(WEAPON_TYPE.ASSAULT) <= 15 &&  GameManager.GetCurrentGold() >= GameManager.GetAssaultAmmoCost())
        {
            GameManager.PurchaseAmmo(WEAPON_TYPE.ASSAULT);
        }
    }
}
