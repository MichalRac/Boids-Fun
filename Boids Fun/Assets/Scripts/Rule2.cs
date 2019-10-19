﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Rule2
{
    private const float minDistanceToKeepFromObstacles = 2.5f;

    public static Vector3 MoveAwayFromNearbyObjects(List<BoidBehaviour> boidList, BoidBehaviour percivingBoid)
    {
        Vector3 result = Vector3.zero;

        foreach(var boid in boidList)
        {
            if (percivingBoid == boid)
                continue;

            if (Mathf.Abs((boid.transform.position - percivingBoid.transform.position).magnitude) < minDistanceToKeepFromObstacles)
            {
                result = result - (boid.transform.position - percivingBoid.transform.position);
            }
        }

        return result;
    }
}
