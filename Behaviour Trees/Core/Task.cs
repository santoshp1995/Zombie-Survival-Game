using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public enum TASK_RETURN_STATUS
{
	SUCCESS,
	FAILURE
}

public abstract class Task {

	protected List<Task> children;

	public Task()
	{
		children = new List<Task> ();
	}

	public void AddTask(Task t)
	{
		children.Add (t);
	}

	public void RemoveTask(Task t)
	{
		children.Remove (t);
	}

	public void ClearAllTasks()
	{
		children.Clear ();
	}


	public virtual TASK_RETURN_STATUS Run(Survivor_AI sAI)
	{
		return TASK_RETURN_STATUS.FAILURE;
	}

}
