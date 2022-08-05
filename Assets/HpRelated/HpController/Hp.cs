using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace NBGame.HealthSystem
{
    public interface Hp
    {
        public void damage(int damageAmount);

        public void damageByPercent(int damagePercent);
    }
}
