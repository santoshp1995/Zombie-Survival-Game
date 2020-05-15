using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task_UsePistol : Task
{
    public override TASK_RETURN_STATUS Run(Survivor_AI sAI)
    {
        TASK_RETURN_STATUS output = TASK_RETURN_STATUS.SUCCESS;

        sAI.GetSurvivor().SwitchWeapons(WEAPON_TYPE.PISTOL);

        return output;
    }
}

