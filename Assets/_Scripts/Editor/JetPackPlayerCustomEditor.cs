using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

[CustomEditor(typeof(JetPackPlayer))]
public class JetPackPlayerCustomEditor : Editor
{

    SerializedProperty terrainsProperty;

    JetPackPlayer res;

    TerrainEnum terrains;


    private void OnEnable()
    {
        res = (JetPackPlayer)target;
        terrainsProperty = serializedObject.FindProperty("terrains");
    }

    public override void OnInspectorGUI()
    {

        serializedObject.Update();
        //terrains = (TerrainEnum)EditorGUILayout.EnumMaskField("Terrains", enumValue: terrains);
        terrains = (TerrainEnum)EditorGUILayout.EnumFlagsField(terrains);
        res.Terrains = terrains;
        serializedObject.ApplyModifiedProperties();
        DrawDefaultInspector();
    }
}