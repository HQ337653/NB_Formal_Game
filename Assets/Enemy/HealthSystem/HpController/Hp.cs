using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace NBGame.HealthSystem
{
    public interface Hp
    {
        public void damage(int damageAmount, bool criticalAtk);

        public void damage(int damageAmount, bool criticalAtk,int poise);

        public void damageByPercent(int damagePercent);
    }
}
