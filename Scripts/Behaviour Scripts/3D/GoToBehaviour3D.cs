using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behaviour/3D/Go To Flag 3D")]
public class GoToBehaviour3D : FilteredFlockBehaviour3D
{
    [Range(0f, 100f)]
    public float goToRadius = 50.0f;

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
        Vector3 goToFlagMove = Vector3.zero;
        int nAvoid = 0;
        List<Transform> filteredContext = (filter == null) ? context : filter.Filter(agent, context);
        //Vector3 closestFlag = filteredContext[0].position;
        foreach (Transform item in filteredContext)
        {
            if (Vector3.SqrMagnitude(item.position - agent.transform.position) < goToRadius)
            {
                nAvoid++;
                goToFlagMove += (Vector3)(item.position - agent.transform.position);
            }
        }
        if (nAvoid > 0)
            goToFlagMove /= nAvoid;

        goToFlagMove = Vector3.SmoothDamp(agent.transform.up, goToFlagMove, ref currentVelocity, agentSmoothTime);
        return goToFlagMove;
    }
}
