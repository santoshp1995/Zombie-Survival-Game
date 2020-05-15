using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task_FireAtEnemy : Task {

	public override TASK_RETURN_STATUS Run (Survivor_AI sAI)
	{
		TASK_RETURN_STATUS output = TASK_RETURN_STATUS.FAILURE;

		BlackBoard blackBoard = sAI.GetBlackBoard ();
		Enemy target = blackBoard.target;

		if (target != null)
		{
			sAI.GetSurvivor().Fire (target.transform.position + (Vector3.up * sAI.enemyHeightOffset));

			output = TASK_RETURN_STATUS.SUCCESS;
		}

		return output;
	}


}
