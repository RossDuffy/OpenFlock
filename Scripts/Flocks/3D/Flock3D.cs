using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flock3D : MonoBehaviour
{

    public FlockAgent3D agentPrefab3D;
    List<FlockAgent3D> agents3D = new List<FlockAgent3D>();
    public FlockBehaviour3D behaviour3D;

    [Range(10, 500)]
    public int startingCount = 250;
    const float AgentDensity = 0.08f;

    [Range(1f, 100f)]
    public float driveFactor = 10f;
    [Range(1f, 100f)]
    public float maxSpeed = 5f;
    [Range(1f, 10f)]
    public float neighbourRadius = 1.5f;
    [Range(0f, 1f)]
    public float avoidanceRadiusMultiplier = 0.5f;

    float squareMaxSpeed;
    float squareNeighbourRadius;
    float squareAvoidanceRadius;
    public float SquareAvoidanceRadius { get { return squareAvoidanceRadius; } }

    // Start is called before the first frame update
    void Start()
    {
        squareMaxSpeed = maxSpeed * maxSpeed;
        squareNeighbourRadius = neighbourRadius * neighbourRadius;
        squareAvoidanceRadius = squareNeighbourRadius * avoidanceRadiusMultiplier * avoidanceRadiusMultiplier;

        for (int i = 0; i < startingCount; i++)
        {
            FlockAgent3D newAgent3D = Instantiate(
                agentPrefab3D,
                Random.insideUnitSphere * startingCount * AgentDensity,
                Quaternion.Euler(Vector3.forward*Random.Range(0f, 360f)),
                transform
                );
            newAgent3D.name = "Agent3D " + i;
            newAgent3D.Initialize(this);
            agents3D.Add(newAgent3D);
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach(FlockAgent3D agent3D in agents3D)
        {
            List<Transform> context = GetNearbyObjects(agent3D);

            //agent.GetComponentInChildren<SpriteRenderer>().color = Color.Lerp(Color.white, Color.blue, context.Count / 6f);

            Vector3 move = behaviour3D.CalculateMove(agent3D, context, this);
            move *= driveFactor;
            if (move.sqrMagnitude > squareMaxSpeed)
            {
                move = move.normalized * maxSpeed;
            }
            agent3D.Move(move);
        }
    }

    List<Transform> GetNearbyObjects(FlockAgent3D agent3D)
    {
        List<Transform> context = new List<Transform>();
        Collider[] contextColliders = Physics.OverlapSphere(agent3D.transform.position, neighbourRadius);
        foreach(Collider c in contextColliders)
        {
            if (c != agent3D.AgentCollider)
            {
                context.Add(c.transform);
            }
        }
        return context;
    }
}
