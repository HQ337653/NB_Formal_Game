using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NBGame.HealthSystem;
namespace NBGame.Player
{
    //to be put on the character
    //control all Hp related feature on 
    //show Hp on the ui
    public class CharacterHp : MonoBehaviour, Hp, CharaSideHp
    {
        [SerializeField]
        public characterHealthObj CharacterInfo;

        private CharaChangeUiEvents changeUiEvents;

        private void Awake()
        {
            changeUiEvents = GetComponentInChildren<CharaChangeUiEvents>();
            CharacterInfo.CurrentHP = CharacterInfo.MaxHp;
        }

        void OnEnable()
        {
            changeUiEvents?.AllHealthUiChanged((float)CharacterInfo.CurrentHP / (float)CharacterInfo.MaxHp, (float)CharacterInfo.currentEnergy / (float)(float)CharacterInfo.MaxEnergy, (float)CharacterInfo.currentSpecialVal / (float)CharacterInfo.specialVal);
        }
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

        public void damage(int damageAmount)
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
                Debug.Log((float)CharacterInfo.CurrentHP / (float)CharacterInfo.MaxHp);
            }
            else
            {
                changeUiEvents.showHp(0);
            }
        }

        public void damageByPercent(int damagePercent)
        {
            damage((int)(CharacterInfo.MaxHp * (float)damagePercent * 0.01));
        }

        void die()
        {

        }


    }
}
