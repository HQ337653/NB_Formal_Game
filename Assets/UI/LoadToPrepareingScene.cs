using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadToPrepareingScene : MonoBehaviour
{

    public bool ShouldChange;
    private void Start()
    {
        if (ShouldChange)
        {
            SceneLoader.load(SceneLoader.scene.PreparingScene);
        }
        else
        {
            GameModeController.CharacterChangedIfToActive(true);

        }
    }
}
