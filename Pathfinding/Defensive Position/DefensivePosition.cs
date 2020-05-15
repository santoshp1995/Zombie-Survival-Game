using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DefensivePosition_Name
{
    NULL,
    LVL1,
    LVL2,
    LVL3,
    LVL5,
    LVL6,
}

public class DefensivePosition : MonoBehaviour
{
    public DefensivePosition_Name name;

    public DefensePoint[] defensePoints;

    void Start()
    {
        defensePoints = GetComponentsInChildren<DefensePoint>();
    }
}
