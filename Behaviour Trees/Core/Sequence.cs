using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Sequence : Task {

	public override TASK_RETURN_STATUS Run (Survivor_AI sAI)
	{
		TASK_RETURN_STATUS output = TASK_RETURN_STATUS.SUCCESS;

		for (int i = 0; i < children.Count; i++)
		{
			Task child = children [i];

			if (child.Run (sAI) == TASK_RETURN_STATUS.FAILURE)
			{
				output = TASK_RETURN_STATUS.FAILURE;
				break;
			}
		}

		return output;
	}


}
