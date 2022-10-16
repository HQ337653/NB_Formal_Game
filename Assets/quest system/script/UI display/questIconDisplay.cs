using NBGame.quest;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
//display the quest in the quest menu
public class questIconDisplay : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI textMeshProUGUI;
    public Button button;
   public int index;
  public void show(int questDictionaryIndex)
    {
        index = questDictionaryIndex;
        textMeshProUGUI.text = questController.questStateDictionary[questDictionaryIndex].Base.title;
    }
}
