using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behaviour/2D/Go To Flag")]
public class GoToBehaviour : FilteredFlockBehaviour
{
    [Range(0f, 100f)]
    public float goToRadius = 50.0f;

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
        Vector2 goToFlagMove = Vector2.zero;
        int nAvoid = 0;
        List<Transform> filteredContext = (filter == null) ? context : filter.Filter(agent, context);
        //Vector3 closestFlag = filteredContext[0].position;
        foreach (Transform item in filteredContext)
        {
            if (Vector2.SqrMagnitude(item.position - agent.transform.position) < goToRadius)
            {
                nAvoid++;
                goToFlagMove += (Vector2)(item.position - agent.transform.position);
            }
        }
        if (nAvoid > 0)
            goToFlagMove /= nAvoid;

        goToFlagMove = Vector2.SmoothDamp(agent.transform.up, goToFlagMove, ref currentVelocity, agentSmoothTime);
        return goToFlagMove;
    }
}
