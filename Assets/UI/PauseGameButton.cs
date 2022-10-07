using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGameButton : MonoBehaviour
{
    bool paused;
    public void Pause()
    {
        paused = !paused;
        if (paused)
        {
            resume();
        }
        else
        {
            pause();
        }
    }

     void pause()
    {
        Time.timeScale = 0;
        GameModeController.PauseGame(true);
    }

    void resume()
    {
        Time.timeScale = 1;
        GameModeController.PauseGame(false);
    }
}
