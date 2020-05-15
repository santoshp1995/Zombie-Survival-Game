using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task_IsEnemyVisible : Task {


	public override TASK_RETURN_STATUS Run (Survivor_AI sAI)
	{
		TASK_RETURN_STATUS output = TASK_RETURN_STATUS.FAILURE;


		BlackBoard blackBoard = sAI.GetBlackBoard ();
		bool b = isTargetVisible (sAI, blackBoard.target);

		if (b == true)
		{
			output = TASK_RETURN_STATUS.SUCCESS;
		}


		return output;
	}


	bool isTargetVisible(Survivor_AI sAI, Enemy e)
	{
		bool output = false;

		if (e != null)
		{
			Survivor survivor = sAI.GetSurvivor();
			RaycastHit hit;

			Vector3 offset = (Vector3.up * 0.5f);

			Vector3 dir = e.transform.position - survivor.transform.position;
			dir += offset;

			dir.Normalize ();

			int layerMask = 1 << LayerMask.NameToLayer ("Player");
			layerMask = ~layerMask;

			if (Physics.Raycast (survivor.transform.position + offset, dir, out hit, 1000.0f, layerMask))
			{
				if (hit.collider.gameObject.layer == LayerMask.NameToLayer ("Enemy"))
				{

					//if (hit.collider.gameObject.GetInstanceID () == e.gameObject.GetInstanceID ())
					//{
						output = true;
					//}
				}
			}
		}
		return output;
	}

}
