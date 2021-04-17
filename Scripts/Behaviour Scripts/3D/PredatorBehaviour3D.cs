using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behaviour/3D/Predator 3D")]
public class PredatorBehaviour3D : FilteredFlockBehaviour3D
{
    [Range(1f, 15f)]
    public float chaseRadius = 5.0f;

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
        Vector3 chaseMove = Vector3.zero;
        int nAvoid = 0;
        List<Transform> filteredContext = (filter == null) ? context : filter.Filter(agent, context);
        foreach (Transform item in filteredContext)
        {
            if (Vector3.SqrMagnitude(item.position - agent.transform.position) < chaseRadius)
            {
                nAvoid++;
                chaseMove += (Vector3)(item.position - agent.transform.position);
            }
        }
        if (nAvoid > 0)
            chaseMove /= nAvoid;

        chaseMove = Vector3.SmoothDamp(agent.transform.up, chaseMove, ref currentVelocity, agentSmoothTime);
        return chaseMove;
    }
}
