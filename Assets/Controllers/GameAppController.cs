using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

//this class sets the frame rate, graphic, and windows resolution
public class GameAppController : MonoBehaviour
{
    public enum frameRate
    {
        Thirty=30, Sixty=60, OneTwenty=120,
    }
    public void ChangeFrameRate(frameRate rate)
    {
        Application.targetFrameRate = (int)rate;
    }

    void Start()
    {
        //SetResizeavkeWindow();
        ChangeScreenSize(Level.one);
    }
//#if UNITY_WIN
    public enum Level
    {
        one,two, three,full
    }
    public void ChangeScreenSize(Level level)
    {
        if (level==Level.one)
        {
            Screen.SetResolution(1280,720,false);
        }else if (level==Level.two)
        {
            Screen.SetResolution(1920, 1080, false);
        }
        else if (level == Level.three)
        {
            Screen.SetResolution(2560, 1440, false);
        }
        else
        {
            Screen.fullScreen = true;
        }
    }
    public void SetResizeavkeWindow()
    {
       // PlayerSettings.resizableWindow=true;

    }

//#endif

}
