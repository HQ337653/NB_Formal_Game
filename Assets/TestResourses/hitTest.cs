using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NBGame.HealthSystem;
using System;
namespace NBGame.quest
{
    public class hitTest : EnemyHp
    {
        public int x;
        public test t;
        public override void damage(int damageAmount, bool criticalAtk)
        {
            thing();
        }

        private void thing()
        {
            if (x == 1)
            {
                
                questController.questStateDictionary[0].setRequirementState(0, 0, true);
            }
            else if(x == 2)
            {
                
                questController.questStateDictionary[0].setRequirementState(0, 1, true);
            }
            else
            {
                
                questController.questStateDictionary[0].setRequirementState(1, 0, true);
            }
        }

        public void damage(int damageAmount, bool criticalAtk, int poise)
        {
            thing();
        }
    }
}