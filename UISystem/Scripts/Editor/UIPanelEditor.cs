using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.UIElements;

[CustomEditor(typeof(UICustomPanel))]
public class UIPanelEditor : Editor
{
    private UICustomPanel _target;

    private void Awake()
    {
        _target = target as UICustomPanel;
    }

    public override void OnInspectorGUI()
    {
        EditorGUI.BeginChangeCheck();
        
        _target.fadeInDuration = EditorGUILayout.FloatField("FadeInDuration", _target.fadeInDuration);
        _target.fadeOutDuration = EditorGUILayout.FloatField("FadeOutDuration", _target.fadeOutDuration);
        
        _target.fadeOutAuto = EditorGUILayout.ToggleLeft("FadeOutAuto", _target.fadeOutAuto);
        if (_target.fadeOutAuto)
        {
            _target.waitTime = EditorGUILayout.FloatField("WaitTime", _target.waitTime);
        }

        if (EditorGUI.EndChangeCheck())
        {
            EditorUtility.SetDirty(_target);
        }
        
    }
}
