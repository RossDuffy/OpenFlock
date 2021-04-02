using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Flock))]
public class FlockEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
    }

    /*public void OnSceneGUI()
    {

    }*/

    [DrawGizmo(GizmoType.Selected | GizmoType.NonSelected)]
    static void OnDrawGizmos(Flock flock, GizmoType gizmoType)
    {
        Gizmos.color = new Color(1, 1, 1, 0.75f);
        Gizmos.DrawCube(flock.transform.position, new Vector3(0.25f, 0.25f, 0.25f));
    }
}
