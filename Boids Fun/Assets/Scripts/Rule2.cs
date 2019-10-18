using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rule2 : MonoBehaviour
{
    private const float minDistanceToKeepFromObstacles = 7.5f;

    public static Vector3 MoveAwayFromNearbyObjects(List<BoidBehaviour> boidList, BoidBehaviour percivingBoid)
    {
        Vector3 result = Vector3.zero;

        foreach(var boid in boidList)
        {
            if(percivingBoid != boid)
            {
                if(Mathf.Abs((boid.transform.position - percivingBoid.transform.position).magnitude) < minDistanceToKeepFromObstacles)
                {
                    result = result - (boid.transform.position - percivingBoid.transform.position);
                }
            }
        }

        return result;
    }
}
