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
            charaTest script = (charaTest)target;
            base.OnInspectorGUI();

            script.SpeedFactor = EditorGUILayout.FloatField("Move", script.SpeedFactor, GUILayout.Height(20));
            script.AtkSpeed = EditorGUILayout.FloatField("Atk", script.AtkSpeed, GUILayout.Height(20));
        }
    }
}