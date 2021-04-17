using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behaviour/3D/Stay In Radius 3D")]
public class StayInRadiusBehaviour3D : FlockBehaviour3D
{

    public Vector3 centre;
    public float radius = 15f;

    Vector3 currentVelocity;
    public float agentSmoothTime = 0f;

    public override Vector3 CalculateMove(FlockAgent3D agent, List<Transform> context, Flock3D flock)
    {
        Vector3 centreOffset = centre - (Vector3)agent.transform.position;
        float t = centreOffset.magnitude / radius;
        if (t < 0.9f)
        {
            return Vector3.zero;
        }

        centreOffset = centreOffset * t * t;
        centreOffset = Vector3.SmoothDamp(agent.transform.up, centreOffset, ref currentVelocity, agentSmoothTime);
        return centreOffset;
    }
}
