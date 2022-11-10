using NBGame.quest;
using System.Collections.Generic;
using UnityEngine;
// display all the quest in a vertical layout, user can press on it to see the detail of the quest
namespace NBGame.UI
{
    public class QuestMenu : MonoBehaviour
    {
        [SerializeField]
        GameObject questPrefeb;
        [SerializeField]
        questDisplay questDisplay;

        private void Start()
        {
            showQuest();
        }
       public void showQuest()
        {
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }
            Dictionary<int, QuestState> q = questController.questStateDictionary;
            foreach (KeyValuePair<int, QuestState> questState in q)
            {
                GameObject g = Instantiate(questPrefeb);
                g.transform.SetParent(transform);
                questIconDisplay qI= g.GetComponent<questIconDisplay>();
                qI.show(questState.Key);
                qI.button.onClick.AddListener(delegate { questDisplay.displayQuest(questState.Key); });
                //questPrefeb.transform.SetParent(transform);
            }
        }
    }
}