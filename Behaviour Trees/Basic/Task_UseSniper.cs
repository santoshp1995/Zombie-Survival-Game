using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task_UseSniper : Task
{
    public override TASK_RETURN_STATUS Run(Survivor_AI sAI)
    {

        TASK_RETURN_STATUS output = TASK_RETURN_STATUS.FAILURE;

        if (GameManager.GetAmmo(WEAPON_TYPE.SNIPER) > 0)
        {
            BlackBoard bd = sAI.GetBlackBoard();

            Weapon w = sAI.GetSurvivor().GetWeapon(WEAPON_TYPE.SNIPER);

            float distFromTarget = Vector3.Distance(bd.target.transform.position,
                sAI.transform.position);

            if (distFromTarget < w.getRange())
            {
                sAI.GetSurvivor().SwitchWeapons(WEAPON_TYPE.SNIPER);
                output = TASK_RETURN_STATUS.SUCCESS;
            }
        }
        return output;
    }
}
