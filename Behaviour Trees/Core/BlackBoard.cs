using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackBoard 
{
    public Enemy target;
	public bool isTargetSpecial;
	public Collider[] enemiesInRange;
	public Collider[] fireballsInRange;
	public Vector3 fleeDirection;
	public Transform formationPos;
	public float fleeDistance;
	public Transform targetLocation;
    public Vector3 currentSurvivorPosition;
    public Fireball incomingFireball;
    public bool isNorthEastTowerBought = false;
    public bool isNorthWestTowerBought = false;
    public bool isSouthEastTowerBought = false;
    public bool isSouthWestTowerBought = false;
}
