using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behaviour/3D/Obstacle Avoidance 3D")]
public class ObstacleAvoidanceBehaviour3D : FilteredFlockBehaviour3D
{
    [Range(1f, 15f)]
    public float obstacleAvoidRadius = 5.0f;

    Vector3 currentVelocity;
    public float agentSmoothTime = 0f;

    public override Vector3 CalculateMove(FlockAgent3D agent, List<Transform> context, Flock3D flock)
    {
        // if no neighbour do nothing
        if (context.Count == 0)
        {
            return Vector3.zero;
        }

        // average points together
        Vector3 avoidanceMove = Vector3.zero;
        int nAvoid = 0;
        List<Transform> filteredContext = (filter == null) ? context : filter.Filter(agent, context);
        foreach (Transform item in filteredContext)
        {
            SphereCollider obstacleCollider = item.GetComponent<SphereCollider>();
            if (Vector3.SqrMagnitude(obstacleCollider.ClosestPoint(agent.transform.position) - (Vector3)agent.transform.position) < obstacleAvoidRadius)
            {
                nAvoid++;
                avoidanceMove += (Vector3)(agent.transform.position - item.position);
            }
        }
        if (nAvoid > 0)
            avoidanceMove /= nAvoid;

        avoidanceMove = Vector3.SmoothDamp(agent.transform.up, avoidanceMove, ref currentVelocity, agentSmoothTime);
        return avoidanceMove;
    }
}
