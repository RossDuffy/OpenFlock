using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class FlockAgent3D : MonoBehaviour
{

    Flock3D agentFlock3D;
    public Flock3D AgentFlock {  get { return agentFlock3D; } }

    SphereCollider agentCollider;
    public SphereCollider AgentCollider {  get { return agentCollider;  } }
    
    // Start is called before the first frame update
    void Start()
    {
        agentCollider = GetComponent<SphereCollider>();
    }

    public void Initialize(Flock3D flock3D)
    {
        agentFlock3D = flock3D;
    }

    public void Move(Vector3 velocity)
    {
        transform.up = velocity;
        transform.position += (Vector3)velocity * Time.deltaTime;
    }
}
