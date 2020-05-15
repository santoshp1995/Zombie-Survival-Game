using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequence_KillSpecial : Sequence
{
	Enemy specialTarget;

	public Sequence_KillSpecial(Enemy e)
	{
		specialTarget = e;


		children.Add(new Task_SetTarget(specialTarget));
		children.Add(new Task_IsEnemyVisible());

		Task weaponSelector = new Selector();
        weaponSelector.AddTask(new Task_UseAssault());
        weaponSelector.AddTask(new Task_UseSniper());
		weaponSelector.AddTask(new Task_UsePistol());

		children.Add(weaponSelector);

		children.Add(new Task_FireAtEnemy());

	}


	public override TASK_RETURN_STATUS Run(Survivor_AI sAI)
	{
		base.Run(sAI);

		return TASK_RETURN_STATUS.SUCCESS;
	}


}

