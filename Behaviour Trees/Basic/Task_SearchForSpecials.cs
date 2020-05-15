using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task_SearchForSpecials : Task {



	public override TASK_RETURN_STATUS Run (Survivor_AI sAI)
	{
		TASK_RETURN_STATUS output = TASK_RETURN_STATUS.FAILURE;

		Enemy bear = FindBearsInRange (sAI);


		BlackBoard blackBoard = sAI.GetBlackBoard ();
		blackBoard.isTargetSpecial = false;

		if (bear != null)
		{
			blackBoard.target = bear;
			blackBoard.isTargetSpecial = true;
			output = TASK_RETURN_STATUS.SUCCESS;
		}

		return output;
	}




	Enemy FindBearsInRange(Survivor_AI sAI)
	{
		Enemy e = null;

		float searchRange = sAI.enemySearchRadius;

		List<Enemy> bears = GameManager.getZomBearList ();

		for (int i = 0; i < bears.Count; i++)
		{
			Enemy bear = bears [i];

			if (bear.getState () != EnemyState.DEAD)
			{
				if (Vector3.Distance (sAI.transform.position, bear.transform.position) < searchRange)
				{
					e = bear;
				}
			}
		}

		return e;
	}

}
