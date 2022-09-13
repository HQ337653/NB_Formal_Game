using NBGame.CameraMovement;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace NBGame.editor
{
    [CustomEditor(typeof(CameraFollowCharacter))]
    public class cameraAnchorEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            //CameraFollowCharacter.cameraController = (CameraController)(EditorGUILayout.ObjectField("cameraController", CameraFollowCharacter.cameraController, typeof(CameraController), true));
            CameraFollowCharacter.zoomInFactor = EditorGUILayout.FloatField("zoom", CameraFollowCharacter.zoomInFactor, GUILayout.Height(20));

        }
    }
}

