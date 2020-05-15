using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task_EquipProperWeapon : Task
{
    public override TASK_RETURN_STATUS Run(Survivor_AI sAI)
    {
        TASK_RETURN_STATUS output = TASK_RETURN_STATUS.SUCCESS;


        if (sAI.GetBlackBoard().target.getEnemyType() == EnemyType.ZOMBUNNY)
        {
            sAI.GetSurvivor().SwitchWeapons(WEAPON_TYPE.PISTOL);
        }

        if(sAI.GetBlackBoard().target.getEnemyType() == EnemyType.HELLEPHANT)
        {
            sAI.GetSurvivor().SwitchWeapons(WEAPON_TYPE.SNIPER);
        }

        if(sAI.GetBlackBoard().target.getEnemyType() == EnemyType.CLOWN)
        {
            sAI.GetSurvivor().SwitchWeapons(WEAPON_TYPE.PISTOL);
        }

        return output;
    }
}
