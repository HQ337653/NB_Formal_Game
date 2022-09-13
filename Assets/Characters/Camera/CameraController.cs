using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NBGame.CameraMovement
{

    public class CameraController : MonoBehaviour
    {
          private float _zoomInFactor=0;
           public float zoomInFactor { get { return _zoomInFactor; } set { 
                   _zoomInFactor = value;
                   cam.orthographicSize = (value)+TwoDF;
                   MainCam.orthographicSize = cam.orthographicSize;
                   cam.fieldOfView = (value ) + ThreeDF;
                   MainCam.fieldOfView = cam.fieldOfView; } }
           private float rotateFactor = 14f;
           [SerializeField]
           private Camera cam;
           [SerializeField]
           private Camera MainCam;
           [SerializeField]
           private float TwoDF = 3f;
        [SerializeField]
           private float ThreeDF = 8f;



           // Start is called before the first frame update
           private void Awake()
           {
               TwoDF = 3f;
               ThreeDF = 8f;
           }


          public void Change(bool TwoD)
           {
               if (TwoD)
               {
                   transform.rotation = Quaternion.Euler(0f, 0f, 0f);

                   cam.orthographic = true;;
                   cam.orthographicSize = TwoDF;

                   MainCam.orthographic = true;
                   MainCam.orthographicSize = TwoDF;
               }
               else
               {
                   transform.rotation = Quaternion.Euler(rotateFactor, 0f, 0f);
                   cam.orthographic = false;
                   cam.fieldOfView = ThreeDF;

                   MainCam.orthographic = false;
                   MainCam.fieldOfView = ThreeDF;
               }
           }

       
    }
}
