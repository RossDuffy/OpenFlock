using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behaviour/2D/Alignment")]
public class AlignmentBehaviour : FilteredFlockBehaviour
{
    Vector2 currentVelocity;
    public float agentSmoothTime = 0f;

    public override Vector2 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
    {
        // if no neighbour do same
        if (context.Count == 0)
        {
            return agent.transform.up;
        }

        // average points together
        Vector2 alignmentMove = Vector2.zero;
        List<Transform> filteredContext = (filter == null) ? context : filter.Filter(agent, context);
        foreach (Transform item in filteredContext)
        {
            alignmentMove += (Vector2)item.transform.up;
        }
        alignmentMove /= context.Count;

        alignmentMove = Vector2.SmoothDamp(agent.transform.up, alignmentMove, ref currentVelocity, agentSmoothTime);
        return alignmentMove;
    }
}
