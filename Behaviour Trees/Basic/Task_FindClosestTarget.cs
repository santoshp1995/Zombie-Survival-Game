using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task_FindClosestTarget : Task
{
    public override TASK_RETURN_STATUS Run(Survivor_AI sAI)
    {
        TASK_RETURN_STATUS output = TASK_RETURN_STATUS.FAILURE;

        Enemy e = FindClosestTarget(sAI);

        if (e != null)
        {
            BlackBoard b = sAI.GetBlackBoard();

            b.target = e;

            output = TASK_RETURN_STATUS.SUCCESS;
        }

        return output;
    }

    Enemy FindClosestTarget(Survivor_AI sAI)
    {
        Enemy output = null;
        float closestSoFar = Mathf.Infinity;
        List<Enemy> enemies = GameManager.getAllEnemies();

        for (int i = 0; i < enemies.Count; i++)
        {
            Enemy e = enemies[i];

            if (e.getState() != EnemyState.DEAD)
            {
                float dist = (e.transform.position - sAI.GetSurvivor().transform.position).magnitude;
                if (dist < closestSoFar && dist < sAI.GetSurvivor().currentWeapon.getRange())
                {
                    output = e;
                    closestSoFar = dist;
                }
            }
        }

        return output;
    }
}
