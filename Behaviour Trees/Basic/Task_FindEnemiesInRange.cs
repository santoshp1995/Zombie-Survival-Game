using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task_FindEnemiesInRange : Task
{
	public override TASK_RETURN_STATUS Run (Survivor_AI sAI)
	{
		TASK_RETURN_STATUS output = TASK_RETURN_STATUS.SUCCESS;

		Collider[] cols = FindEnemiesInRange (sAI);


		//Enemy e = FindClosestTarget (sAI);
		BlackBoard blackBoard = sAI.GetBlackBoard ();

		if (cols != null)
		{
			blackBoard.enemiesInRange = cols;
		}

		return output;
	}




	Collider[] FindEnemiesInRange(Survivor_AI sAI)
	{
		int mask = 1 << LayerMask.NameToLayer ("Enemy");

		Collider[] cols = Physics.OverlapSphere (sAI.transform.position, sAI.enemySearchRadius, mask);


		return cols;
	}




}
