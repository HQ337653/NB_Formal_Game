using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NBGame.CameraMovement
{
    public class CameraAnchor : MonoBehaviour
    {
        public float smoothTime = 0.03f;
        public float rotateFactor = 14f;
        public float shiftFactor = 3.65f;
        public bool is2D = false;
        public GameObject Follow;

        public float TwoDF;
        public float ThreeDF;

        public float hight = 0.93f;
        //Z axis of camera always constant 
        private float Z = -15;
        private float shiftY = 0;

        [SerializeField] private float speed = 0.09f;

        private Vector3 velocity = Vector3.zero;
        Vector3 Position;
        public float shiftz;


        // Start is called before the first frame update
        private void Awake()
        {
            shiftFactor = 3.65f;
            GameModeController.ModeChangediFTo2D += change;
        }
        void Start()
        {
            speed = 0.1f;
            TwoDF = 50f;
            ThreeDF = 15f;
            //CharaterController.SwitchD += Change;
            is2D = false;
        }

        void LateUpdate()
        {
            if (Follow != null)
            {
                transform.position = Vector3.SmoothDamp(transform.position, new Vector3(Follow.transform.position.x, (Follow.transform.position.y + shiftY),Z+Follow.transform.position.z+shiftz), ref velocity, smoothTime);
            }
        }

        void change(bool twoD)
        {
            if (twoD)
            {
                shiftY = 0;
            }
            else
            {
                shiftY = shiftFactor;
            }
        }

        public void follow(GameObject gameObj)
        {
            Follow = gameObj;
        }


    }
}
