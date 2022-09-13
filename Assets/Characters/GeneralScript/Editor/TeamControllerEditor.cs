using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using NBGame.Player;
namespace NBGame.editor
{
    [CustomEditor(typeof(TeamController))]
    public class TeamControllerEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            TeamController a = (TeamController)target;
            if (GUILayout.Button("Load"))
            {
                a.Load();
            }
        }
    }
}