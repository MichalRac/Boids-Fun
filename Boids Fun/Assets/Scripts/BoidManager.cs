using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidManager : MonoBehaviour
{
    [SerializeField] private BoidBehaviour boidPrefab;
    [SerializeField] private float perciveDistance = 7.5f;
    private List<BoidBehaviour> boidList = new List<BoidBehaviour>();
    private List<BoidBehaviour> predatorList = new List<BoidBehaviour>();

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CreateBoid();
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            CreatePredator();
        }

        foreach (var boid in boidList)
        {
            StandardBoidMovement(boid);
        }

        foreach(var predator in predatorList)
        {
            PredatorBoidMovement(predator);
        }
    }

    // Creates boid and adds to list
    private void CreateBoid()
    {
        for (int i = 0; i < 5; i++)
        {
            var newBoid = Instantiate(boidPrefab, transform);
            newBoid.transform.position = new Vector3(Random.Range(-30f, 30f), Random.Range(-30f, 30f));
            newBoid.BoidType = BoidType.Standard;
            boidList.Add(newBoid);
        }
    }

    private void CreatePredator()
    {
        var newBoid = Instantiate(boidPrefab, transform);
        newBoid.transform.position = new Vector3(Random.Range(-30f, 30f), Random.Range(-30f, 30f));
        newBoid.BoidType = BoidType.Predator;
        newBoid.GetComponent<MeshRenderer>().material.color = Color.black;
        newBoid.transform.localScale = new Vector3(1.25f, 1.25f, 1.25f);
        predatorList.Add(newBoid);
    }

    private void StandardBoidMovement(BoidBehaviour boid)
    {
        Vector3 defaultMovement, component1, component2, component3, componentHunted;

        //component1 = Rule1.FindPointTowardsGlobalMassCentre(boidList, boid);
        component1 = Rule1.FindPointTowardsLocalMassCentre(boidList, boid, perciveDistance);
        component2 = Rule2.MoveAwayFromNearbyObjects(boidList, boid);
        component3 = Rule3.MatchVelocityOfPercivedBoids(boidList, boid, perciveDistance);
        componentHunted = RuleHunted.MoveAwayFromPredators(predatorList, boid);

        boid.CurrentVelocity = boid.CurrentVelocity + component1 + component2 + component3 + componentHunted;
        boid.transform.position = boid.transform.position + boid.CurrentVelocity;
    }

    private void PredatorBoidMovement(BoidBehaviour boid)
    {
        Vector3 component1, component2, component3;

        component1 = Rule1.FindPointTowardsLocalMassCentre(boidList, boid, perciveDistance * 5);
        component3 = Rule3.MatchVelocityOfPercivedBoids(boidList, boid, perciveDistance * 5);

        boid.CurrentVelocity = boid.CurrentVelocity + component1 + component3;
        boid.transform.position = boid.transform.position + boid.CurrentVelocity;
    }
}
