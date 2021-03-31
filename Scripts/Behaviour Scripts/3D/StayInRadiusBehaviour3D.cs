using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behaviour/3D/Stay In Radius 3D")]
public class StayInRadiusBehaviour3D : FlockBehaviour3D
{

    public Vector3 centre;
    public float radius = 15f;

    public override Vector3 CalculateMove(FlockAgent3D agent, List<Transform> context, Flock3D flock)
    {
        Vector3 centreOffset = centre - (Vector3)agent.transform.position;
        float t = centreOffset.magnitude / radius;
        if (t < 0.9f)
        {
            return Vector3.zero;
        }

        return centreOffset * t * t;
    }
}
