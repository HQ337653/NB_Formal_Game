using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NBGame.quest
{
    public class Quest
    {
        //public bool active;
        public string title;
        //which sub quest it is in
        //public int phase;
        public List<subQuest> subQuests;
        public int questID;
        //if the quest is open to the player
       // public bool enabled;
       //public bool finished;
       public Quest(string Title, List<subQuest> SubQuests)
        {
            title=Title;
            subQuests=SubQuests;
            //active=false;
            //phase=0;
           /* foreach(subQuest subQuest in SubQuests)
            {
                subQuest.finishSub += move;
            }*/
        }

        /* public void move()
         {

             if (phase + 1<subQuests.Count)
             {
                 phase = +1;
             }
             else
             {
                 finished = true;
             }

             //throw new NotImplementedException();
         }*/
    }

}