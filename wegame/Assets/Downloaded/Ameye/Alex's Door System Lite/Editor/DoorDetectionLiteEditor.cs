// DoorDetectionLiteEditor.cs
// Created by Alexander Ameye
// Version 3.0.0

using UnityEngine;
using StylesHelper;
using UnityEditor;

[CustomEditor(typeof(DoorDetectionLite)), CanEditMultipleObjects]
public class DoorDetectionLiteEditor : Editor
{
    SerializedProperty textPrefabProp, crosshairProp;
    SerializedProperty reachProp, characterProp;
    SerializedProperty debugRayColorProp;

    public void OnEnable()
    {
        textPrefabProp = serializedObject.FindProperty("TextPrefab");
        crosshairProp = serializedObject.FindProperty("CrosshairPrefab");

        reachProp = serializedObject.FindProperty("Reach");
        characterProp = serializedObject.FindProperty("Character");

        debugRayColorProp = serializedObject.FindProperty("DebugRayColor");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        GUIStyle style = new GUIStyle()
        {
            richText = true
        };

        EditorGUILayout.Space();
        EditorGUILayout.LabelField("<b>UI Settings</b>", style);
        EditorGUILayout.PropertyField(textPrefabProp, new GUIContent("Text Prefab", "The image or text that will be shown whenever the player is in reach of the door."));
        EditorGUILayout.PropertyField(crosshairProp, new GUIContent("Crosshair Prefab", "The image or text that is shown in the middle of the the screen."));


        EditorGUILayout.Space();
        EditorGUILayout.LabelField("<b>Raycast Settings</b>", style);
        EditorGUILayout.PropertyField(reachProp, new GUIContent("Reach", "How close the player has to be in order to be able to open/close the door."));
        EditorGUILayout.PropertyField(characterProp, new GUIContent("Character"));

        EditorGUILayout.PropertyField(debugRayColorProp, new GUIContent("Debug Ray Color", "The color of the debugray that will be shown in the scene view window when playing the game."));

        EditorGUILayout.Space();
        EditorGUILayout.LabelField(Styles.VersionLabel, Styles.centeredVersionLabel);
        serializedObject.ApplyModifiedProperties();


        if (Application.isPlaying) return;

        serializedObject.ApplyModifiedProperties();
    }
}
