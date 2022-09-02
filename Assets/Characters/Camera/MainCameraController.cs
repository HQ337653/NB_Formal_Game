using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraController : MonoBehaviour
{

    
        public float rotateFactor = 14f;
        public bool is2D = false;
        public Camera cam;
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
                cam.orthographic = true;
                cam.orthographicSize = TwoDF;
            }
            else
            {
                cam.orthographic = false;
                cam.fieldOfView = ThreeDF;
            }
        }

    }

