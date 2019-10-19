using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Rule3
{
    private const float PERCIVED_VELOCITY_FACTOR = 8f;

    public static Vector3 MatchVelocityOfPercivedBoids(List<BoidBehaviour> boidsList, BoidBehaviour percivingBoid, float perciveDistance)
    {
        Vector3 percivedVelocity = Vector3.zero;
        int percivedBoidsCount = 0;

        foreach(var boid in boidsList)
        {
            if (percivingBoid == boid)
                continue;

            if (Vector3.Distance(boid.transform.position, percivingBoid.transform.position) > perciveDistance)
                continue;

            percivedBoidsCount++;
            percivedVelocity = percivedVelocity + boid.CurrentVelocity;
        }

        percivedVelocity /= percivedBoidsCount;

        return (percivedVelocity - percivingBoid.CurrentVelocity) / PERCIVED_VELOCITY_FACTOR;
    }
}
