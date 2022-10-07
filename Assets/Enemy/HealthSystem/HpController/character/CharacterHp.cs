using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NBGame.Player;
namespace NBGame.HealthSystem
{
    //to be put on the character
    //control all Hp related feature on 
    //show Hp on the ui
    public class CharacterHp : MonoBehaviour, Hp, CharaSideHp
    {
        public characterHealthObj CharacterInfo;
        [SerializeField]charaControllerThreeD controller;
        [SerializeField]CharaChangeUiEvents changeUiEvents;
       [SerializeField] teamScripts teamScripts;

        private void Awake()
        {
            CharacterInfo.CurrentHP = CharacterInfo.MaxHp;
            teamScripts = gameObject.transform.parent.gameObject.GetComponent<teamScripts>();
        }

        void OnEnable()
        {
            changeUiEvents?.AllHealthUiChanged((float)CharacterInfo.CurrentHP / (float)CharacterInfo.MaxHp, (float)CharacterInfo.currentEnergy / (float)(float)CharacterInfo.MaxEnergy, (float)CharacterInfo.currentSpecialVal / (float)CharacterInfo.specialVal);
        }

        //any change to HP energy and special val should use these methods
        #region method that changes those 3 bar
        public void changeEnergy(int i)
        {
            CharacterInfo.currentEnergy += i;
            if (CharacterInfo.currentEnergy > CharacterInfo.MaxEnergy)
            {
                CharacterInfo.currentEnergy = CharacterInfo.MaxEnergy;
            }
            else if (CharacterInfo.currentEnergy < 0)
            {
                CharacterInfo.currentEnergy = 0;
            }
            if (CharacterInfo.MaxEnergy > 0)
            {
                changeUiEvents.showEnegry(CharacterInfo.currentEnergy / CharacterInfo.MaxEnergy);
            }
            else
            {
                changeUiEvents.showEnegry(0);
            }

        }

        public void changeSpecialVal(int i)
        {
            CharacterInfo.currentSpecialVal += i;
            if (CharacterInfo.currentSpecialVal > CharacterInfo.specialVal)
            {
                CharacterInfo.currentSpecialVal = CharacterInfo.specialVal;
            }
            else if (CharacterInfo.currentSpecialVal < 0)
            {
                CharacterInfo.currentSpecialVal = 0;
            }

            //cheak val before sending 
            if (CharacterInfo.specialVal > 0)
            {
                changeUiEvents.showEnegry(CharacterInfo.currentSpecialVal / CharacterInfo.specialVal);
            }
            else
            {
                changeUiEvents.showSpecialBar(0);
            }

        }

        private void HpDecrease(int damageAmount)
        {
            CharacterInfo.CurrentHP -= damageAmount;
            if (CharacterInfo.CurrentHP < 0)
            {
                CharacterInfo.CurrentHP = 0;
                die();
            }
            if (CharacterInfo.MaxHp > 0)
            {
                changeUiEvents.showHp((float)CharacterInfo.CurrentHP / (float)CharacterInfo.MaxHp);
            }
            else
            {
                changeUiEvents.showHp(0);
            }
        }
        #endregion

        #region Damaged
        public void damage(int damageAmount,bool criticalAtk)
        {
            damage(damageAmount, criticalAtk, 10);
        }
        public delegate void eventName();
        public event eventName stun;
        public event eventName DashSuccesssful;
        public void damage(int damageAmount, bool criticalAtk, int poiseHealth)
        {
            if (controller.Dashing)
            {
                dashSuccessful();
            }
            else
            {
                // first loopthrough personal shield
                for (int i = 0; i < shieldsHp.Count; i++)
                {
                    shieldsHp[i].hp -= damageAmount;
                    if (shieldsHp[i].hp > 0)
                    {
                        return;
                    }
                    shieldBreak?.Invoke(shieldsHp[i].id);
                    damageAmount = shieldsHp[i].hp * -1;

                    shieldsHp.RemoveAt(i);
                    i--;
                }
                shieldID = 0;
                // then loop through team shield
                for (int i = 0; i < teamScripts.TeamshieldsHp.Count; i++)
                {
                    teamScripts.TeamshieldsHp[i].hp -= damageAmount;
                    if (teamScripts.TeamshieldsHp[i].hp > 0)
                    {
                        return;
                    }
                    teamScripts.BreakShield(teamScripts.TeamshieldsHp[i].id);
                    damageAmount = teamScripts.TeamshieldsHp[i].hp * -1;

                    teamScripts.TeamshieldsHp.RemoveAt(i);
                    i--;
                }
                teamScripts.shieldID = 0;
                // then cheak personal Hp
                if (damageAmount > 0)
                {
                    EffectsManager.DoFloatingText(gameObject.transform.position, damageAmount, EffectsManager.DamageTextType.PlayerDamage);
                    HpDecrease(damageAmount);
                    decreasePoiseHealth(poiseHealth);
                }
            }


        }

        void decreasePoiseHealth(int amount)
        {
            CharacterInfo.poiseHealth -= amount;
            if (CharacterInfo.poiseHealth<=0)
            {
                stun?.Invoke();
                CharacterInfo.poiseHealth = CharacterInfo.maxPoiseHealth;
            }
        }
        void dashSuccessful()
        {
            Debug.Log("dase successful");
            DashSuccesssful?.Invoke();
        }
        public void damageByPercent(int damagePercent)
        {
            damage((int)(CharacterInfo.MaxHp * (float)damagePercent * 0.01),false);
        }

        void die()
        {
            Debug.Log("die");
        }

        #endregion

        #region shieldRelated
        private List<HpAndID> shieldsHp = new List<HpAndID>();
        public delegate void shieldEvent(int ID);
        public event shieldEvent shieldBreak;
        private int shieldID = 0;
        //add shield Hp into list and return the id of that shield(for later events about that shield)
        public int addShield(int shieldAmount)
        {
            shieldID++;
            shieldsHp.Add(new HpAndID(shieldID, shieldAmount));
            return shieldID;
        }

        public void RemoveShield(int id)
        {
            shieldsHp.Remove(FindShield(id));
        }

        public HpAndID FindShield(int id)
        {
            for (int i = 0; i < shieldsHp.Count; i++)
            {
                if (shieldsHp[i].id == id)
                {
                    return shieldsHp[i];
                }
            }
           return null;
        }
        public class HpAndID
        {
            public int id;
            public int hp;
            public HpAndID(int ID, int HP)
            {
                id = ID;
                hp = HP;
            }
        }
        #endregion

       public void changeAtkSpeed(int i)
        {
            Debug.Log("not Implement");
        }

        public void changeMoveSpeed(int i)
        {
            Debug.Log("not Implement");
        }

    }
}
