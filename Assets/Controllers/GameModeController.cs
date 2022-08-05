using UnityEngine;

//call an event(bool) when the game state is switched 
public class GameModeController : MonoBehaviour
{
    
    public delegate void handler(bool i);
    public static handler ModeChangediFTo2D;

    private bool Is2d;

    public static handler CharacterChangedIfToActive;
    private bool isCharacerActive;
    private void Awake()
    {
        Is2d = true;
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

    public static void SetCharaActivation(bool isActive)
    {
        
        GameModeController g = FindObjectOfType<GameModeController>();
        if (isActive != g.isCharacerActive)
        {
            g.isCharacerActive = isActive;
            CharacterChangedIfToActive?.Invoke(g.isCharacerActive);
        }
    }
}
