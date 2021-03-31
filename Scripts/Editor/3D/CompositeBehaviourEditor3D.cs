using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CompositeBehaviour3D))]
public class CompositeBehaviorEditor3D : Editor
{
    public override void OnInspectorGUI()
    {
        CompositeBehaviour3D cb = (CompositeBehaviour3D)target;
        if (cb.behaviours == null || cb.behaviours.Length == 0)
        {
            EditorGUILayout.HelpBox("No Behaviors in array.", MessageType.Warning);
        }
        else
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Number", GUILayout.MinWidth(60f), GUILayout.MaxWidth(60f));
            EditorGUILayout.LabelField("Behaviors", GUILayout.MinWidth(60f));
            EditorGUILayout.LabelField("Weights", GUILayout.MinWidth(60f), GUILayout.MaxWidth(60f));
            EditorGUILayout.EndHorizontal();

            EditorGUI.BeginChangeCheck();
            for (int i = 0; i < cb.behaviours.Length; i++)
            {
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField(i.ToString(), GUILayout.MinWidth(60f), GUILayout.MaxWidth(60f));
                cb.behaviours[i] = (FlockBehaviour3D)EditorGUILayout.ObjectField(cb.behaviours[i], typeof(FlockBehaviour3D), false, GUILayout.MinWidth(60f));
                cb.weights[i] = EditorGUILayout.FloatField(cb.weights[i], GUILayout.MinWidth(60f), GUILayout.MaxWidth(60f));
                EditorGUILayout.EndHorizontal();
            }

            if (EditorGUI.EndChangeCheck())
            {
                EditorUtility.SetDirty(cb);
            }
        }

        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("Add Behavior"))
        {
            AddBehavior(cb);
            EditorUtility.SetDirty(cb);
        }
        EditorGUILayout.EndHorizontal();

        if (cb.behaviours != null && cb.behaviours.Length > 0)
        {
            EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button("Remove Behavior"))
            {
                RemoveBehavior(cb);
                EditorUtility.SetDirty(cb);
            }
            EditorGUILayout.EndHorizontal();
        }
    }

    private void AddBehavior(CompositeBehaviour3D cb)
    {
        int oldCount = (cb.behaviours != null) ? cb.behaviours.Length : 0;
        FlockBehaviour3D[] newBehaviors = new FlockBehaviour3D[oldCount + 1];
        float[] newWeights = new float[oldCount + 1];
        for (int i = 0; i < oldCount; i++)
        {
            newBehaviors[i] = cb.behaviours[i];
            newWeights[i] = cb.weights[i];
        }
        newWeights[oldCount] = 1f;
        cb.behaviours = newBehaviors;
        cb.weights = newWeights;
    }

    private void RemoveBehavior(CompositeBehaviour3D cb)
    {
        int oldCount = cb.behaviours.Length;
        if (oldCount == 1)
        {
            cb.behaviours = null;
            cb.weights = null;
            return;
        }
        else
        {
            FlockBehaviour3D[] newBehaviors = new FlockBehaviour3D[oldCount - 1];
            float[] newWeights = new float[oldCount - 1];
            for (int i = 0; i < oldCount - 1; i++)
            {
                newBehaviors[i] = cb.behaviours[i];
                newWeights[i] = cb.weights[i];
            }
            cb.behaviours = newBehaviors;
            cb.weights = newWeights;
        }
    }
}