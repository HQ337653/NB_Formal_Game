using UnityEngine;
using UnityEditor;
using NBGame.Player;
namespace NBGame.editor
{
    [CustomEditor(typeof(charaTest))]
    public class CharaFourEdictor : Editor
    {
        public override void OnInspectorGUI()
        {
            /* if (GUILayout.Button("aaaaaa"))
             {

             }*/
            charaTest script = (charaTest)target;
            base.OnInspectorGUI();

            //script.AtkSpeed = EditorGUILayout.FloatField("AtkSpeed", 1, GUILayout.Height(20));
            // GUILayout.Button("aaaaaa");
            script.SpeedFactor = EditorGUILayout.FloatField("Move", script.SpeedFactor, GUILayout.Height(20));
            script.AtkSpeed = EditorGUILayout.FloatField("Atk", script.AtkSpeed, GUILayout.Height(20));
            // float x = EditorGUILayout.FloatField("AtkSpeed", 1, GUILayout.Height(20));
        }
    }
}