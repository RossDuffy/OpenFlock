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
}
