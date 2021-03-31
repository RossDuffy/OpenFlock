using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behaviour/3D/Steered Cohesion 3D")]
public class SteeredCohesionBehaviour3D : FilteredFlockBehaviour3D
{

    Vector3 currentVelocity;
    public float agentSmoothTime = 0.5f;

    public override Vector3 CalculateMove(FlockAgent3D agent, List<Transform> context, Flock3D flock)
    {
        // if no neighbour do nothing
        if (context.Count == 0)
        {
            return Vector3.zero;
        }

        // average points together
        Vector3 steeredCohesionMove = Vector3.zero;
        List<Transform> filteredContext = (filter == null) ? context : filter.Filter(agent, context);
        foreach (Transform item in filteredContext)
        {
            steeredCohesionMove += (Vector3)item.position;
        }
        steeredCohesionMove /= context.Count;

        // create offset from agent position
        steeredCohesionMove -= (Vector3)agent.transform.position;
        steeredCohesionMove = Vector3.SmoothDamp(agent.transform.up, steeredCohesionMove, ref currentVelocity, agentSmoothTime);
        return steeredCohesionMove;
    }
}
