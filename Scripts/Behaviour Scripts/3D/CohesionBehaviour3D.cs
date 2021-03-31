using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behaviour/3D/Cohesion 3D")]
public class CohesionBehaviour3D : FilteredFlockBehaviour3D
{
    public override Vector3 CalculateMove(FlockAgent3D agent, List<Transform> context, Flock3D flock)
    {
        // if no neighbour do nothing
        if (context.Count == 0)
        {
            return Vector3.zero;
        }

        // average points together
        Vector3 cohesionMove = Vector3.zero;
        List<Transform> filteredContext = (filter == null) ? context : filter.Filter(agent, context);
        foreach (Transform item in filteredContext)
        {
            cohesionMove += (Vector3)item.position;
        }
        cohesionMove /= context.Count;

        // create offset from agent position
        cohesionMove -= (Vector3)agent.transform.position;
        return cohesionMove;
    }
}
