using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NBGame.HealthSystem;

namespace NBGame.Player
{
    //help to acess different part of the character
    //also control extra script such as buff
    public class characterScripts : MonoBehaviour
    {
        
        public GameObject colliderObject;
        public GameObject position;
        public GameObject graphic;
        public CharacterHp HpScript;


        List<Buff> buffs = new List<Buff>();
        public void addBuff(Buff buff)
        {
            for(int i =0; i< buffs.Count; i++)
            {
                Buff b = buffs[i];
                if (b.GetType() == buff.GetType())
                {
                    Buff overlayedbuff=  buffs[i];
                    buffs[i] = buff;
                    buff.overlying(b,this);
                    overlayedbuff.overlayed();
                    return;
                }
            }
            buffs.Add(buff);
            buff.initiate(this);
        }


        public void removeBuff(Buff buff)
        {
            buffs.Remove(buff);
        }
    }
}