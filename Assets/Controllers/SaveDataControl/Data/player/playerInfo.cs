using NBGame.quest;
using System.Collections;
using System.Collections.Generic;
using NBGame.backpack;
using UnityEngine;
using System.Linq;

namespace NBGame.saveSystem
{
    [System.Serializable]
    public class playerInfo
    {
        public int[] id=new int[2];
        /// <summary>
        /// readOnly, for changeing, use saveQuestState instead
        /// </summary>
        public QuestState[] questStatesSave;
        public void saveQuestState(List<QuestState> states)
        {
            questStatesSave = new QuestState[states.Count];
            int i = 0;
            foreach (QuestState questState in states)
            {
                questStatesSave[i++] = questState;
            } 
        }

        /// <summary>
        /// readOnly, for changeing, use saveBackpack instead
        /// </summary>
        public backpackItem[] backpackSave;
        public void saveBackpack(Dictionary<itemType, int> backpack)
        {
            backpackSave = new backpackItem[backpack.Count];
            int i = 0;
            foreach (KeyValuePair<itemType, int> backpackItem in backpack)
            {
                backpackSave[i++] = new backpackItem(backpackItem.Key, backpackItem.Value);
            }
            
        }
        public int[] i2d = new int[2];


        [System.Serializable]
        public class backpackItem
        {
            public int amount;
            public itemType type;
            public backpackItem(itemType j, int i)
            {
                amount = i;
                type = j;   
            }
        }
    }
    
}
