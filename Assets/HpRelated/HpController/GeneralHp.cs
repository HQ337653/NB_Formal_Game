using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NBGame.HealthSystem
{
    public class GeneralHp : MonoBehaviour, Hp
    {
        public delegate void SimpleEventHandler();
        public static SimpleEventHandler DieEvent;
        private GeneralHpObj notNeede;
        public virtual void damage(int damageAmount)
        {

            notNeede.CurrentHP -= damageAmount;
            if (notNeede.CurrentHP < 0)
            {
                notNeede.CurrentHP = 0;
                Die();
            }
        }

        public virtual void damageByPercent(int damagePercent)
        {
            damage((int)(notNeede.MaxHp * (float)damagePercent * 0.01));
        }

        private void Die()
        {
            if (DieEvent != null)
            {
                DieEvent();
            }

        }
    }
}
