namespace NBGame.saveSystem
{
    using NBGame.quest;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    [System.Serializable]
    public class playerInfo
    {
        public QuestState[] questStatesSave=new QuestState[0];
        public void saveQuestState(List<QuestState> states)
        {
            questStatesSave = new QuestState[states.Count];
            int i = 0;
            foreach (QuestState questState in states)
            {
                Debug.Log(questState);
                Debug.Log("????"+JsonUtility.ToJson(questState));
                questStatesSave[i++] = questState;
            }
        }
    }
}
