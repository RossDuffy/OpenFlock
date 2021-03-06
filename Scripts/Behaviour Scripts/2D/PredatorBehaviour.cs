using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behaviour/2D/Predator")]
public class PredatorBehaviour : FilteredFlockBehaviour
{
    [Range(1f, 15f)]
    public float chaseRadius = 5.0f;

    Vector2 currentVelocity;
    public float agentSmoothTime = 0f;

    public override Vector2 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
    {
        // if no neighbour do nothing
        if (context.Count == 0)
        {
            return Vector2.zero;
        }

        // average points together
        Vector2 chaseMove = Vector2.zero;
        int nAvoid = 0;
        List<Transform> filteredContext = (filter == null) ? context : filter.Filter(agent, context);
        foreach (Transform item in filteredContext)
        {
            if (Vector2.SqrMagnitude(item.position - agent.transform.position) < chaseRadius)
            {
                nAvoid++;
                chaseMove += (Vector2)(item.position - agent.transform.position);
            }
        }
        if (nAvoid > 0)
            chaseMove /= nAvoid;

        chaseMove = Vector2.SmoothDamp(agent.transform.up, chaseMove, ref currentVelocity, agentSmoothTime);
        return chaseMove;
    }
}
