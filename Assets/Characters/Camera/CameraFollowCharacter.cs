using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NBGame.CameraMovement
{
    public class CameraFollowCharacter : MonoBehaviour
    {
        public static CameraController cameraController;
        public static CameraFollowCharacter selfScript;
        public CameraController _cameraController;

        private float smoothTime = 0.03f;
        private float shiftFactor = 3.65f;
        public static GameObject FollowChara;
        public float hight = 0.93f;
        //Z axis of camera always constant 
        private float Z = -15;


        private Vector3 velocity = Vector3.zero;
        public float shiftz;
        private static float _zoomInFactor =0;

        //-4 will display chara with full screen
        //0 is defalt val
        public static float zoomInFactor { get { return _zoomInFactor; } set { _zoomInFactor = value; cameraController.zoomInFactor = value; } }


        private bool Is2D;
        // Start is called before the first frame update
        private void Awake()
        {
            selfScript = this;
            shiftFactor = 3.65f;
            GameModeController.ModeChangediFTo2D += change;
        }

        private void Start()
        {
            cameraController = _cameraController;
        }

        void LateUpdate()
        {
            if (FollowChara != null)
            {
                if (Is2D)
                {
                    transform.position = Vector3.SmoothDamp(transform.position, new Vector3(FollowChara.transform.position.x, (FollowChara.transform.position.y), Z + FollowChara.transform.position.z ), ref velocity, smoothTime);
                }
                else
                {
                    transform.position = Vector3.SmoothDamp(transform.position, new Vector3(FollowChara.transform.position.x, (FollowChara.transform.position.y + shiftFactor), Z + FollowChara.transform.position.z  +1), ref velocity, smoothTime);
                }
               // transform.position = Vector3.SmoothDamp(transform.position, new Vector3(FollowChara.transform.position.x, (FollowChara.transform.position.y + shiftY),Z+ FollowChara.transform.position.z+shiftz), ref velocity, smoothTime);
            }
        }

        void change(bool twoD)
        {
            Is2D = twoD;
            cameraController.Change(twoD);
        }


        public static void followChara(GameObject gameObj)
        {
            FollowChara = gameObj;
        }
        public static void ChangeZoom(float final, float time)
        {
            Debug.Log("1");
            selfScript. StartCoroutine(selfScript.zoom(time,zoomInFactor, final));
        }
       IEnumerator zoom(float time, float current, float target)
        {
            float currentTime = 0;
            float gapPerSecond = (target - current) / time;
            while (currentTime < time)
            {
                current += gapPerSecond * Time.unscaledDeltaTime;
                zoomInFactor = current;
                currentTime += Time.unscaledDeltaTime;
                yield return null;
            }
            yield break;
        }
    }
}
