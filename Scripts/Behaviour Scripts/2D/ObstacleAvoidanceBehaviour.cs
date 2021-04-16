using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behaviour/2D/Obstacle Avoidance")]
public class ObstacleAvoidanceBehaviour : FilteredFlockBehaviour
{

    Vector2 currentVelocity;
    public float agentSmoothTime = 0.02f;

    public override Vector2 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
    {
        // if no neighbour do nothing
        if (context.Count == 0)
        {
            return Vector2.zero;
        }

        // average points together
        Vector2 avoidanceMove = Vector2.zero;
        int nAvoid = 0;
        List<Transform> filteredContext = (filter == null) ? context : filter.Filter(agent, context);
        foreach (Transform item in filteredContext)
        {
            if (agent.AgentCollider.IsTouching(item.GetComponent<Collider2D>()))
            {
                nAvoid++;
                avoidanceMove += (Vector2)(agent.transform.position - item.position);
            }
        }
        if (nAvoid > 0)
            avoidanceMove /= nAvoid;

        avoidanceMove = Vector2.SmoothDamp(agent.transform.up, avoidanceMove, ref currentVelocity, agentSmoothTime);
        return avoidanceMove;
    }
}