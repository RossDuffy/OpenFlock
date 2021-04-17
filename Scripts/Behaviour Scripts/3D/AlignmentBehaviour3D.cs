using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behaviour/3D/Alignment 3D")]
public class AlignmentBehaviour3D : FilteredFlockBehaviour3D
{
    Vector3 currentVelocity;
    public float agentSmoothTime = 0f;

    public override Vector3 CalculateMove(FlockAgent3D agent, List<Transform> context, Flock3D flock)
    {
        // if no neighbour do same
        if (context.Count == 0)
        {
            return agent.transform.up;
        }

        // average points together
        Vector3 alignmentMove = Vector3.zero;
        List<Transform> filteredContext = (filter == null) ? context : filter.Filter(agent, context);
        foreach (Transform item in filteredContext)
        {
            alignmentMove += (Vector3)item.transform.up;
        }
        alignmentMove /= context.Count;

        alignmentMove = Vector3.SmoothDamp(agent.transform.up, alignmentMove, ref currentVelocity, agentSmoothTime);
        return alignmentMove;
    }
}

/*
 * For giving an FOV get the vector between this boid and the comparison boid
 * Check if the angle is greater than a certain amount from this boid's forward direction
 * If angle is too great, don't consider that comparison boid in calculations
 * 
 */
