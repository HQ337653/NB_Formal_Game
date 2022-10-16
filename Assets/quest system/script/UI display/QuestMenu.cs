using NBGame.quest;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NBGame.quest;
using System.Reflection;

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
            Debug.Log(gameObject.name);
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