using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : Task {


	public override TASK_RETURN_STATUS Run (Survivor_AI sAI)
	{
		TASK_RETURN_STATUS output = TASK_RETURN_STATUS.FAILURE;

		for (int i = 0; i < children.Count; i++)
		{
			Task child = children [i];

			if (child.Run (sAI) == TASK_RETURN_STATUS.SUCCESS)
			{
				output = TASK_RETURN_STATUS.SUCCESS;
				break;
			}
		}

		return output;
	}


}
