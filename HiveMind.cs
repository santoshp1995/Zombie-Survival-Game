using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiveMind : MonoBehaviour
{
    private static HiveMind instance;

    Survivor_AI[] survivorAIs;

    Fireball[] fireballs;

    Task BT_Default_Fire;

    public DefensivePosition[] defensivePositions;

    SpawnController spawnControl;

    // Start is called before the first frame update
    void Start()
    {
        survivorAIs = GameObject.FindObjectsOfType<Survivor_AI>();
        BT_Default_Fire = new Sequence_DefaultFire();

        fireballs = GameObject.FindObjectsOfType<Fireball>();

        defensivePositions = GameObject.FindObjectsOfType<DefensivePosition>();

        Invoke("SearchForBears", 1.0f);
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            instance.Setup();
        }
    }

    void Setup()
    {
        spawnControl = GameObject.FindObjectOfType<SpawnController>();
    }

    // Update is called once per frame
    void Update()
    {
        survivorAIs = GameObject.FindObjectsOfType<Survivor_AI>();

        fireballs = GameObject.FindObjectsOfType<Fireball>();
      
        SearchForHellephants();

        UpdateDefensivePositions();
        
        SpendGold();
    }

    void SpendGold()
    {
        if(GameManager.GetBreakTimeRemaining() > 0)
        {
            // let the first survivor on list make the purchasing decesions
            Survivor_AI sAI = survivorAIs[0];

            ResetSurvivorsBT(); // reset before making purchases
            sAI.SetBehaviorTree(new Sequence_SpendGold());
        }
    }


    void SearchForBears()
    {
        List<Enemy> bears = GameManager.getZomBearList();
        
        if (bears.Count > 0)
        {
            ResetSurvivorsBT();

            foreach (Enemy bear in bears)
            {
                Survivor_AI sAI = FindClosestSurvivorToTarget(bear);

                if (CheckWeapons())
                {
                    Task BT_Kill_Special = new Sequence_KillSpecial(bear);

                    sAI.SetBehaviorTree(BT_Kill_Special);
                }
            }


        }

        Invoke("SearchForBears", 1.0f);
    }

  
    void SearchForFireballs()
    {
        if(fireballs.Length > 0)
        {
            foreach(Fireball f in fireballs)
            {
                float range = 1.0f;

                Survivor_AI sAI = FindClosestSurvivorToFireBall(f);

                float distance = Vector3.Distance(sAI.GetSurvivor().transform.position, f.transform.position);

                if(distance < range)
                {
                    ResetSurvivorsBT();

                    sAI.GetBlackBoard().incomingFireball = f;

                    sAI.GetBlackBoard().currentSurvivorPosition = sAI.GetSurvivor().transform.position;

                    Task BT_Evade_Fireball = new Sequence_EvadeFireballs();

                    sAI.SetBehaviorTree(BT_Evade_Fireball);

                }
            }


        }
    }

    void SurvivorFlee()
    {
        List<Enemy> enemies = GameManager.getAllEnemies();

        if(enemies.Count > 0)
        {
            foreach(Enemy e in enemies)
            {
                float range = 5.0f;

                Survivor_AI sAI = FindClosestSurvivorToTarget(e);

                float distance = Vector3.Distance(sAI.GetSurvivor().transform.position, e.transform.position);

                if(distance < range)
                {
                    ResetSurvivorsBT();

                    Task BT_Flee_Zombie = new Sequence_FleeZombie();

                    sAI.GetBlackBoard().target = e;

                    sAI.GetBlackBoard().currentSurvivorPosition = sAI.GetSurvivor().transform.position;

                    sAI.SetBehaviorTree(BT_Flee_Zombie);
                }
            }
        }
    }



    void SearchForHellephants()
    {
        List<Enemy> hellephants = GameManager.getHellephantList();

        if (hellephants.Count > 0 && GameManager.getZomBearList().Count == 0)
        {
            ResetSurvivorsBT();

            foreach (Enemy hellephant in hellephants)
            {
                Survivor_AI sAI = FindClosestSurvivorToTarget(hellephant);

                if (CheckWeapons())
                {
                    Task BT_Kill_Hellephant = new Sequence_KillHellephant(hellephant);

                    sAI.SetBehaviorTree(BT_Kill_Hellephant);
                }
            }
        }
    }

    //void SearchForLootDrops()
    //{
    //    List<Loot> drops = GameManager.GetLootList();

    //    if(drops.Count > 0)
    //    {
    //        ResetSurvivorsBT();

    //        foreach(Loot loot in drops)
    //        {
    //            Survivor_AI sAI = FindClosestSurvivorToLoot(loot);

    //            Task_
    //        }
    //    }
    //}

    void ResetSurvivorsBT()
    {
        foreach(Survivor_AI sAI in survivorAIs)
        {
            sAI.SetBehaviorTree(BT_Default_Fire);
        }
    }


    void UpdateDefensivePositions()
    {

        if(GameManager.GetCurrentWaveNumber() == 0)
        {
            ResetDefensePositions();
           
            DefensivePosition dPos = GetDefensivePositions(DefensivePosition_Name.LVL1);

            DefensivePositionSetup(dPos);

            ResetSurvivorsBT();
        }

        // Level 2 setup
        else if(GameManager.GetCurrentWaveNumber() == 1 && GameManager.GetBreakTimeRemaining() > 0 && 
            GameManager.getAllEnemies().Count == 0)
        {

            ResetDefensePositions();

            DefensivePosition dPos = GetDefensivePositions(DefensivePosition_Name.LVL2);

            DefensivePositionSetup(dPos);

            ResetSurvivorsBT();
        }

        // Level 3 setup
        else if(GameManager.GetCurrentWaveNumber() == 2 && GameManager.GetBreakTimeRemaining() > 0 &&
            GameManager.getAllEnemies().Count == 0)
        {
            ResetDefensePositions();


            DefensivePosition dPos = GetDefensivePositions(DefensivePosition_Name.LVL3);

            DefensivePositionSetup(dPos);

            ResetSurvivorsBT();
        }

        // Level 5 setup
        else if(GameManager.GetCurrentWaveNumber() == 4 && GameManager.GetBreakTimeRemaining() > 0 &&
            GameManager.getAllEnemies().Count == 0)
        {
            ResetDefensePositions();

            DefensivePosition dPos = GetDefensivePositions(DefensivePosition_Name.LVL5);

            DefensivePositionSetup(dPos);

            ResetSurvivorsBT();
        }

        // Level 6 set up
        else if(GameManager.GetCurrentWaveNumber() == 5 && GameManager.GetBreakTimeRemaining() > 0 &&
            GameManager.getAllEnemies().Count == 0)
        {
            ResetDefensePositions();

            DefensivePosition dPos = GetDefensivePositions(DefensivePosition_Name.LVL6);

            DefensivePositionSetup(dPos);

            ResetSurvivorsBT();
        }

        // Level 7 set up
        
    }

    void DefensivePositionSetup(DefensivePosition pos)
    {
        for (int i = 0; i < pos.defensePoints.Length; i++)
        {
            Survivor_AI targetAI = null;

            for (int j = 0; j < survivorAIs.Length; j++)
            {
                Survivor_AI sAI = survivorAIs[j];

                if (sAI.currDefensePoint == null)
                {
                    targetAI = sAI;
                    targetAI.currDefensePoint = pos.defensePoints[i];
                    targetAI.SetBehaviorTree(new Task_FindPath(targetAI.currDefensePoint.transform.position, targetAI));
                    break;
                }
            }
        }
    }

    DefensivePosition GetDefensivePositions(DefensivePosition_Name name)
    {
        DefensivePosition output = null;

        for(int i = 0; i < defensivePositions.Length; i++)
        {
            if(defensivePositions[i].name == name)
            {
                output = defensivePositions[i];
            }
        }

        return output;
    }

    void ResetDefensePositions()
    {
        foreach(Survivor_AI sAI in survivorAIs)
        {
            sAI.currDefensePoint = null;
        }
    }

    Survivor_AI FindClosestSurvivorToTarget(Enemy e)
    {
        float closestDist = Mathf.Infinity;
        Survivor_AI closestSuvivor = null;

        foreach (Survivor_AI sAI in survivorAIs)
        {
            float dist = Vector3.Distance(sAI.transform.position, e.transform.position);

            if (dist < closestDist)
            {
                closestSuvivor = sAI;
                closestDist = dist;
            }
        }

        return closestSuvivor;
    }

    Survivor_AI FindClosestSurvivorToFireBall(Fireball f)
    {
        float closestDist = Mathf.Infinity;
        Survivor_AI closestSurvivor = null;

        foreach(Survivor_AI sAI in survivorAIs)
        {
            float dist = Vector3.Distance(sAI.transform.position, f.transform.position);

            if(dist < closestDist)
            {
                closestSurvivor = sAI;
                closestDist = dist;
            }
        }

        return closestSurvivor;
    }

    Survivor_AI FindClosestSurvivorToLoot(Loot loot)
    {
        float closestDist = Mathf.Infinity;
        Survivor_AI closestSurvivor = null;

        foreach(Survivor_AI sAI in survivorAIs)
        {
            float dist = Vector3.Distance(sAI.transform.position, loot.transform.position);

            if(dist < closestDist)
            {
                closestSurvivor = sAI;
                closestDist = dist;
            }
        }
        return closestSurvivor;
    }

    bool CheckWeapons()
    {
        bool output = false;

        int assaultAmmo = GameManager.GetAmmo(WEAPON_TYPE.ASSAULT);
        int sniperAmmo = GameManager.GetAmmo(WEAPON_TYPE.SNIPER);

        if(assaultAmmo > 0 || sniperAmmo > 0)
        {
            output = true;
        }

        return output;
    }
}
