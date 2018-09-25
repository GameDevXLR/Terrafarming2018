using UnityEngine;
using UnityEditor;

using UnityEditor.SceneManagement;


[CustomEditor(typeof(ResourcesManager))]
public class ResourceManagerEditor : Editor {


    SerializedProperty energyProp;

    ResourcesManager res;



    private void OnEnable()
    {
        res = (ResourcesManager)target;
        energyProp = serializedObject.FindProperty("energy");
    }

    public override void OnInspectorGUI()
    {

        serializedObject.Update();
        res.Energy = EditorGUILayout.IntSlider(energyProp.intValue, 0, res.MaxEnergy);
        if (!energyProp.hasMultipleDifferentValues)
            ProgressBar(energyProp.intValue / res.MaxEnergy, "Energy");

        res.MaxEnergy = EditorGUILayout.IntField("Experience", res.MaxEnergy);


        // Apply changes to the serializedProperty - always do this in the end of OnInspectorGUI.
        serializedObject.ApplyModifiedProperties();
        DrawDefaultInspector();
    }


    // Custom GUILayout progress bar.
    void ProgressBar(float value, string label)
    {
        // Get a rect for the progress bar using the same margins as a textfield:
        Rect rect = GUILayoutUtility.GetRect(18, 18, "TextField");
        EditorGUI.ProgressBar(rect, value, label);
        EditorGUILayout.Space();
    }

}
