using UnityEngine;
using UnityEngine.UI;

public class testSwitchActivation : MonoBehaviour
{
    public Button B;
    bool thing;

    private void Start()
    {
        B.onClick.AddListener(ctx);
    }

    private void ctx()
    {
        GameModeController.SetCharaActivation(thing);
        thing = !thing;
    }
}
