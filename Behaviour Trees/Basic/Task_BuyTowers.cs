using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task_BuyTowers : Task
{
    public override TASK_RETURN_STATUS Run(Survivor_AI sAI)
    {
        TASK_RETURN_STATUS output = TASK_RETURN_STATUS.FAILURE;

        base.Run(sAI);

        if(GameManager.GetCurrentGold() >= GameManager.GetBulletTowerCost())
        {
            if(!sAI.GetBlackBoard().isNorthEastTowerBought)
            {
                GameManager.PurchaseTower(TOWER_TYPE.BULLET_TOWER, TOWER_POSITION.NORTHEAST);
                sAI.GetBlackBoard().isNorthEastTowerBought = true;
            }

            else if(!sAI.GetBlackBoard().isNorthWestTowerBought)
            {
                GameManager.PurchaseTower(TOWER_TYPE.BULLET_TOWER, TOWER_POSITION.NORTHWEST);
                sAI.GetBlackBoard().isNorthWestTowerBought = true;
            }
            

            else if(!sAI.GetBlackBoard().isSouthEastTowerBought)
            {
                GameManager.PurchaseTower(TOWER_TYPE.BULLET_TOWER, TOWER_POSITION.SOUTHEAST);
                sAI.GetBlackBoard().isSouthEastTowerBought = true;
            }

            else if(!sAI.GetBlackBoard().isSouthWestTowerBought)
            {
                GameManager.PurchaseTower(TOWER_TYPE.BULLET_TOWER, TOWER_POSITION.SOUTHWEST);
                sAI.GetBlackBoard().isSouthWestTowerBought = true;
            }

            else
            {
                Debug.Log("Every Tower Bought");
            }
         
            output = TASK_RETURN_STATUS.SUCCESS;
        }

        return output;
    }
}
