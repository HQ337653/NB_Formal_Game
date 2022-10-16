using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;
using NBGame.saveSystem;
using NBGame.UI;
using System;

namespace NBGame.quest
{
    // overall controller of the quest system
    public class questController : MonoBehaviour, playerInfoLoader
    {
     public static  Dictionary<int, QuestState> questStateDictionary = new Dictionary<int, QuestState>();
        public static Dictionary<int, Quest> questDictionary = new Dictionary<int, Quest>();
        private void Awake()
        {
            makeQuest1();
        }
        
        private void makeQuest1()
        {
            List<subQuest> subQuests = new List<subQuest>();


            questRequirement re1 = new questRequirement();
            re1.description = "red 1";
            questRequirement re2 = new questRequirement();
            re2.description = "red 2";
            List<questRequirement> res = new List<questRequirement>();
            res.Add(re1);
            res.Add(re2);
            subQuest q1 = new subQuest("fight red monster ", res);
            subQuests.Add(q1);


            questRequirement re21 = new questRequirement();
            re21.description = "blue 1";
            List<questRequirement> res1 = new List<questRequirement>();
            res1.Add(re21);
            subQuest q2 = new subQuest("fight blue monster ", res1);
            subQuests.Add(q2);


            Quest Q = new Quest("test", subQuests);
            QuestState questState = new QuestState(Q);
            questDictionary.Add(0, Q);
            //  questStateDictionary.Add(0, questState);
            // questState.finishQuest += () => { questFinished(0); };

            creatEmptyQ();
            // questD.displayQuest(Qstate);

        }

        private void questFinished(int index)
        {
            throw new NotImplementedException();
        }

        public void creatEmptyQ()
        {
            foreach (KeyValuePair<int, Quest> quest in questDictionary)
            {
                QuestState q = new QuestState(quest.Value);
                questStateDictionary.Add(q.index, q);
            }
        }

        public void LoadGame(playerInfo data)
        {
            Debug.Log("load!!");
            //creatEmptyQ();
            Debug.Log(JsonUtility.ToJson(data));
            Debug.Log(JsonUtility.ToJson(data.questStatesSave));
            Debug.Log(data.questStatesSave);
            foreach (QuestState questState in data.questStatesSave)
            {
                Debug.Log("jdcjwel");
                Debug.Log(questState);
                Debug.Log(JsonUtility.ToJson(questState));

                questState.Base = questDictionary[questState.index];
                questStateDictionary[questState.index] = questState;
            }
        }

        

        public void saveGame(ref playerInfo data)
        {
            Debug.Log("save!!");
            List<QuestState> questSaves = new List<QuestState>();

            foreach (KeyValuePair<int, QuestState> questState in questStateDictionary)
            {
                Debug.Log("!!!!!");
                questSaves.Add(questState.Value);
                Debug.Log(JsonUtility.ToJson(questState.Value));
                Debug.Log(questState);
            }
            data.saveQuestState(questSaves);

        }
    }
}