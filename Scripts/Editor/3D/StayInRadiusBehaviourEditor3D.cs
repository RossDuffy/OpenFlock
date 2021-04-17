using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(StayInRadiusBehaviour3D))]
public class StayInRadiusBehaviourEditor3D : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
    }

    private void OnEnable()
    {
        SceneView.duringSceneGui += OnSceneGUI;
    }

    private void OnDisable()
    {
        SceneView.duringSceneGui -= OnSceneGUI;
    }

    public void OnSceneGUI(SceneView sceneView)
    {
        StayInRadiusBehaviour3D targ = (StayInRadiusBehaviour3D)target;

        Vector3 centre = (Vector3)targ.centre;
        float radius = targ.radius;

        Vector3 normal = new Vector3(0f, 0f, 1f);
        Handles.DrawWireDisc(centre, normal, radius);

        normal = new Vector3(0f, 1f, 0f);
        Handles.DrawWireDisc(centre, normal, radius);

        normal = new Vector3(1f, 0f, 0f);
        Handles.DrawWireDisc(centre, normal, radius);
    }
}
