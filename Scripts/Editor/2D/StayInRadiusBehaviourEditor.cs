using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(StayInRadiusBehaviour))]
public class StayInRadiusBehaviourEditor : Editor
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
        StayInRadiusBehaviour targ = (StayInRadiusBehaviour)target;

        Vector3 centre = (Vector3)targ.centre;
        Vector3 normal = new Vector3(0f, 0f, 1f);
        float radius = targ.radius;

        Handles.DrawWireDisc(centre, normal, radius);
    }
}
