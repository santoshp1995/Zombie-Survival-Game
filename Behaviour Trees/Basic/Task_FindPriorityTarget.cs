using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task_FindPriorityTarget : Task
{
    public override TASK_RETURN_STATUS Run(Survivor_AI sAI)
    {
        TASK_RETURN_STATUS output = TASK_RETURN_STATUS.FAILURE;

        Enemy e = FindPriorityTarget(sAI);

        if (e != null)
        {
            BlackBoard b = sAI.GetBlackBoard();

            b.target = e;

            output = TASK_RETURN_STATUS.SUCCESS;
        }
        return output;
    }

    Enemy FindPriorityTarget(Survivor_AI sAI)
    {
        Enemy result = null;
        
        List<Enemy> bunniesList = GameManager.getZomBunnyList();
        List<Enemy> hellephantsList = GameManager.getHellephantList();
        List<Enemy> clownsList = GameManager.getClownList();
        
        if (bunniesList.Count > 0)
        {
            result = FindClosestBunny(sAI, bunniesList);
        }

        if(clownsList.Count > 0 && bunniesList.Count == 0)
        {
            result = FindClosestClown(sAI, clownsList);
        }

        if (hellephantsList.Count > 0 && bunniesList.Count == 0)
        {
            result = FindClosestHellephant(sAI, hellephantsList);
        }

        return result;
    }

    Enemy FindClosestBunny(Survivor_AI sAI, List<Enemy> bunnies)
    {
        Enemy output = null;
        float closestSoFar = Mathf.Infinity;

        for (int i = 0; i < bunnies.Count; i++)
        {
            Enemy e = bunnies[i];

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
        if (output != null) { //Debug.Log("Survivor " + sAI.GetSurvivor().name + 
                              //" is Targeting enemy position " + output.transform.position
        }
        return output;
    }

    Enemy FindClosestHellephant(Survivor_AI sAI, List<Enemy> hellephant)
    {
        Enemy output = null;
        float closestSoFar = Mathf.Infinity;

        for (int i = 0; i < hellephant.Count; i++)
        {
            Enemy e = hellephant[i];

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

        //if (output != null) { Debug.Log("Enemy Type: " + output.name); }
        return output;
    }

    Enemy FindClosestClown(Survivor_AI sAI, List<Enemy> clowns)
    {
        Enemy output = null;

        float closestSoFar = Mathf.Infinity;

        for (int i = 0; i < clowns.Count; i++)
        {
            Enemy e = clowns[i];

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

