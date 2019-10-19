using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuleHunted : MonoBehaviour
{
    private const float minDistanceToKeepFromObstacles = 10f;
    private const float MOVE_AWAY_FACTOR = 10f;

    public static Vector3 MoveAwayFromPredators(List<BoidBehaviour> boidList, BoidBehaviour percivingBoid)
    {
        Vector3 result = Vector3.zero;

        foreach (var boid in boidList)
        {
            if (percivingBoid == boid)
                continue;

            if (boid.BoidType != BoidType.Predator)
                continue;

            if (Mathf.Abs((boid.transform.position - percivingBoid.transform.position).magnitude) < minDistanceToKeepFromObstacles)
            {
                result = result - (boid.transform.position - percivingBoid.transform.position) / MOVE_AWAY_FACTOR;
            }
        }

        return result;
    }
}
