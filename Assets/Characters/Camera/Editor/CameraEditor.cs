using NBGame.CameraMovement;
using UnityEditor;
using UnityEngine;

namespace NBGame.editor
{
    [CustomEditor(typeof(CameraController))]
    public class CameraEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            CameraController script = (CameraController)target;
            script.zoomInFactor = EditorGUILayout.FloatField("zoom", script.zoomInFactor, GUILayout.Height(20));

        }
    }
}
