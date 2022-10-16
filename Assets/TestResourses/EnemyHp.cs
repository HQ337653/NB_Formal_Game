using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NBGame.HealthSystem;
namespace NBGame.HealthSystem
{    public class EnemyHp : MonoBehaviour, Hp
    {

        public virtual void damage(int damageAmount, bool criticalAtk, int poise)
        {
            EffectsManager.DoFloatingText(gameObject.transform.position, damageAmount, EffectsManager.DamageTextType.enemyDamage);
        }

        public virtual void damage(int damageAmount, bool criticalAtk)
        {
            EffectsManager.DoFloatingText(gameObject.transform.position, damageAmount, EffectsManager.DamageTextType.enemyDamage);
        }

        public virtual void damageByPercent(int damagePercent)
        {
            
        }
    }
}
