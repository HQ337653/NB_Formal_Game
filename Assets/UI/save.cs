using TMPro;
using UnityEngine;
using UnityEngine.UI;
using NBGame.saveSystem;
// b is for the save button
public class save : MonoBehaviour
{
    Button b;
    void Start()
    {
        b = GetComponent<Button>();
        b.onClick.AddListener(click);

    }

    private void click()
    {
        GameSaveLoader.Save(); 
    }
}

