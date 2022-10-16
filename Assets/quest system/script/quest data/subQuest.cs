using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace NBGame.quest
{
    public class subQuest
    {
       public string description;
        public List<questRequirement> requirements;
        //public bool finished;

        //public delegate void d();
        //public d finishSub;
        //if the subquest is finished and the player cheak it
        bool cheaked;
        public subQuest(string des, List<questRequirement> require)
        {
            description = des;
            requirements = require;
         /*   foreach (questRequirement requirement in requirements)
            {
                requirement.requirementMeeted += cheakAll;
            }*/
            
        }

        /*private void cheakAll(bool finish)
        {
            bool pass = true;
            foreach (questRequirement requirement in requirements)
            {
                
                pass=requirement.finished&&pass;
                
            }
            if (pass)
            {
                Debug.Log(1);
                finishSub?.Invoke();
                finished = true;
            }
        }*/
    }
}