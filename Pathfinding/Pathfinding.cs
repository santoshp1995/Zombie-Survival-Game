using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinding
{
    // class data
    private List<PathNode> openList = new List<PathNode>();
    private List<PathNode> closedList = new List<PathNode>();

    public List<PathNode> CreatePath(Vector3 startPoint, Vector3 endPoint)
    {
        List<PathNode> path = null;

        PathNode start = FindClosestNode(startPoint); // get closest node near the designated start point
        PathNode end = FindClosestNode(endPoint); // get closest node near the designated end point

        path = AStarSearch(start, end);

        return path;
    }

    List<PathNode> AStarSearch(PathNode start, PathNode end)
    {
        PathNode current = null;
        List<PathNode> neighbors = null;
        List<PathNode> finalPath = null;
        
        // add the first node(current) to the open List
        openList.Add(start);

        while (openList.Count > 0)
        {
            current = openList[0];

            for(int i = 1; i < openList.Count; i++)
            {
                if(openList[i].GetFScore() < current.GetFScore() || openList[i].GetFScore() == current.GetFScore()
                    && openList[i].GetHCost() < current.GetHCost())
                {
                    // set the current node to the specific node
                    current = openList[i];
                }
            }

            // remove current node from the open list and add it to the closed list
            openList.Remove(current);
            closedList.Add(current);

            if(current == end)
            {
                // walk through the found nodes to get proper path
                finalPath = PathWalk(start, end);

                break;
            }

            // get the neighbors of the current node
            neighbors = current.GetNeighbors();

            // check to make sure the node isn't contanied in the closed list
            foreach (PathNode node in neighbors)
            {
                if(closedList.Contains(node))
                {
                    // go the next neighbor
                    continue;
                }

                float dist = current.GetGCost() + Vector3.Distance(current.transform.position, node.transform.position);


                if(dist < node.GetGCost() || !openList.Contains(node))
                {
                    // Calculate the F score
                    node.SetGCost(dist);
                    node.SetHCost(Vector3.Distance(node.transform.position, end.transform.position));
                    node.SetFScore(node.GetGCost() + node.GetHCost());

                    // set the parent node
                    node.SetParentNode(current);

                    if(!openList.Contains(node))
                    {
                        openList.Add(node);
                    }
                }
            }
        }

        return finalPath;
    }


    // function called when the A* algo completes and finds the suitable path
    // this function will walk through all of the parent nodes
    List<PathNode> PathWalk(PathNode start, PathNode end)
    {
        List<PathNode> path = new List<PathNode>();
        PathNode current = end; // start at the end, the algo walks from the end(target) to start(origin) of the pathfinding

        while(current != start)
        {
            path.Add(current);
            current = current.GetParentNode();
        }

        path.Reverse();

        return path;
    }
 
    PathNode FindClosestNode(Vector3 point)
    {
        PathNode node = null;

        PathNode[] possibleNodes = GameObject.FindObjectsOfType<PathNode>();

        float dist = Mathf.Infinity;

        for(int i = 0; i < possibleNodes.Length; i++)
        {
            float d = Vector3.Distance(point, possibleNodes[i].transform.position);

            if(d < dist)
            {
                dist = d;
                node = possibleNodes[i];
            }
        }
        return node;
    }

    PathNode FindDestinationNode(Vector3 point)
    {
        PathNode node = null;

        PathNode[] possibleNodes = GameObject.FindObjectsOfType<PathNode>();

        for(int i = 0; i < possibleNodes.Length; i++)
        {
           if(point == possibleNodes[i].transform.position)
            {
                node = possibleNodes[i];
            }
        }

        return node;
    }
}
