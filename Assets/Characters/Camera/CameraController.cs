using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NBGame.CameraMovement
{
    public class CameraController : MonoBehaviour
    {
        public float rotateFactor = 14f;
        public bool is2D = false;
        public Camera cam;
        public GameObject follow;
        //public BoolObj ThreeD;
        //field of view 
        public float TwoDF;
        public float ThreeDF;


        // Start is called before the first frame update
        private void Awake()
        {
            TwoDF = 3f;
            ThreeDF = 8f;
            GameModeController.ModeChangediFTo2D += Change;
        }


        void Change(bool TwoD)
        {
            if (TwoD)
            {
                transform.rotation = Quaternion.Euler(0f, 0f, 0f);

                cam.orthographic = true;
                //cam.fieldOfView = TwoDF;
                cam.orthographicSize = TwoDF;
            }
            else
            {
                transform.rotation = Quaternion.Euler(rotateFactor, 0f, 0f);
                cam.orthographic = false;
                cam.fieldOfView = ThreeDF;
            }
        }

    }
}
