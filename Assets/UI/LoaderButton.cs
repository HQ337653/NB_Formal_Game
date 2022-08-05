using UnityEngine;
using UnityEngine.UI;

//load the scene named gamedata-(index).txt,change the scene to game scene.
public class LoaderButton : MonoBehaviour
{
    Button b;
    public int index;

    private void Awake()
    {
        b = GetComponent<Button>();
        b.onClick.AddListener(click);
    }

    private void click()
    {
        GameSaveLoader.Load(index);
        SceneLoader.load(SceneLoader.scene.SampleGameScene);
        GameModeController.SetCharaActivation(true);
    }
}
