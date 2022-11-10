using UnityEngine;

public class GameModeController : MonoBehaviour
{
    public delegate void handler(bool i);
    #region changeD: GameModeController.ModeChangediFTo2D(if 2d)
    private bool Is2d;
    public static handler ModeChangediFTo2D;

    static GameModeController g;
    private void Awake()
    {
        Is2d = true;
        g = this;
        isCharacerActive = true;
    }
    public static void changeMode()
    {
        GameModeController g = FindObjectOfType<GameModeController>();
        g.Is2d=!g.Is2d;
        ModeChangediFTo2D?.Invoke(g.Is2d);
    }

    public static void SetModeTo(bool IsTarget2D)
    {
        GameModeController g = FindObjectOfType<GameModeController>();
        if (IsTarget2D!= g.Is2d) {
            g.Is2d = IsTarget2D;
            ModeChangediFTo2D?.Invoke(g.Is2d);
        }
    }
    #endregion

    #region changeCharacterActivation: GameModeController.CharacterChangedIfToActive(ifChangeToActive)

    public static handler CharacterChangedIfToActive;
    private bool isCharacerActive;
    public static void SetCharaActivation(bool isActive)
    {
        
        if (isActive != g.isCharacerActive)
        {
            g.isCharacerActive = isActive;
            CharacterChangedIfToActive?.Invoke(g.isCharacerActive);
        }
    }
    #endregion
    // if there are anything that changes timescalse before pause, and wants to continue it after pause, please set the timescale again in the resume function
    #region pause: GameModeController.PauseGame(Pause)

    public static handler PauseGame;
    public static void SetPause(bool ifPause)
    {
        PauseGame?.Invoke(ifPause);
    }
    #endregion
}
