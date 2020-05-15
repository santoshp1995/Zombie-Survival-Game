using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task_RepairGates : Task
{
    public override TASK_RETURN_STATUS Run(Survivor_AI sAI)
    {
        TASK_RETURN_STATUS output = TASK_RETURN_STATUS.FAILURE;

        base.Run(sAI);

      
        if(GameManager.GetCurrentGold() >= GameManager.GetGateRepairCost())
        { 
            if(!GameManager.GetGate(GATE_POSITION.NORTH).Alive())
            {
                GameManager.RepairGate(GATE_POSITION.NORTH);

                output = TASK_RETURN_STATUS.SUCCESS;
            }

            else if(!GameManager.GetGate(GATE_POSITION.SOUTH).Alive())
            {
                GameManager.RepairGate(GATE_POSITION.SOUTH);

                output = TASK_RETURN_STATUS.SUCCESS;
            }

            else if(!GameManager.GetGate(GATE_POSITION.EAST).Alive())
            {
                GameManager.RepairGate(GATE_POSITION.EAST);

                output = TASK_RETURN_STATUS.SUCCESS;
            }

            else if(!GameManager.GetGate(GATE_POSITION.WEST).Alive())
            {
                GameManager.RepairGate(GATE_POSITION.WEST);

                output = TASK_RETURN_STATUS.SUCCESS;
            }
        }

        return output;
    }
}
