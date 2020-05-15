using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathNode : MonoBehaviour
{
    private List<PathNode> neighbors;
    private float FScore;
    private float GCost;
    private float HCost;
    private float maxDistance = 25.0f;
    private PathNode parent = null;

    // Start is called before the first frame update
    void Start()
    {
        neighbors = new List<PathNode>();

        PathNode[] possibleNeighbors = GameObject.FindObjectsOfType<PathNode>();

        FindNeighbors(possibleNeighbors);
    }

    // Update is called once per frame
    void Update()
    {
        //DebugShowConnections();
    }


    void DebugShowConnections()
    {
        for(int i = 0; i < neighbors.Count; i++)
        {
            Debug.DrawLine(transform.position, neighbors[i].transform.position, Color.green);
        }
    }

    void FindNeighbors(PathNode[] possibleNeighbors)
    {
        for(int i = 0; i < possibleNeighbors.Length; i++)
        {
            PathNode p = possibleNeighbors[i];

            // is it myself.... ?
            if(p.GetInstanceID() != this.GetInstanceID())
            {
                float distance = Vector3.Distance(gameObject.transform.position, p.transform.position);

                Vector3 direction = p.transform.position - gameObject.transform.position;
                direction.Normalize();

                if(distance < maxDistance)
                {
                    RaycastHit hit;

                    if(Physics.Raycast(transform.position, direction, out hit, maxDistance))
                    {
                        GameObject objHit = hit.transform.gameObject;

                        if(objHit.GetInstanceID() == p.gameObject.GetInstanceID())
                        {
                            neighbors.Add(p);
                        }
                    }
                }
            }
        }
    }

    public List<PathNode> GetNeighbors()
    {
        return neighbors;
    }

    public void SetFScore(float score)
    {
        FScore = score;
    }

    public float GetFScore()
    {
        return FScore;
    }

    public void SetGCost(float g_cost)
    {
        GCost = g_cost;
    }

    public float GetGCost()
    {
        return GCost;
    }

    public void SetHCost(float h_cost)
    {
        HCost = h_cost;
    }

    public float GetHCost()
    {
        return HCost;
    }

    public void SetParentNode(PathNode _parent)
    {
        parent = _parent;
    }

    public PathNode GetParentNode()
    {
        return parent;
    }
}
