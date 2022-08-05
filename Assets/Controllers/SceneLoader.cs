using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//load the scene based on name
//load(SceneLoader.scene.sceneName)is recommended 
public class SceneLoader 
{
    public enum scene
    {
        SampleGameScene, PreparingScene
    }
    public static void load(scene s)
    {
        SceneManager.LoadScene(s.ToString());
    }
    public static void load(string dontUseItIfNotNessery)
    {
        SceneManager.LoadScene(dontUseItIfNotNessery);
    }
}
