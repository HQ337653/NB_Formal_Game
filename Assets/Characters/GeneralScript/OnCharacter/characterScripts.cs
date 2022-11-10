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

        [SerializeField]
        CharaChangeUiEvents charaChangeUiEvents;
        List<Buff> buffs = new List<Buff>();

        List<Sprite> BuffIcons = new List<Sprite>();
        private void OnEnable()
        {
            charaChangeUiEvents.BuffIconInit(BuffIcons);
        }
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

        // add buff icon Ui
        public void AddBuffIcon(Sprite Icon)
        {
            BuffIcons.Add(Icon);
            charaChangeUiEvents.BuffIconAdd(Icon);
        }

        // remove buff icon Ui
        public void RemoveBuffIcon(Sprite Icon)
        {
            BuffIcons.Remove(Icon);
            charaChangeUiEvents.BuffIconRemove(Icon);
        }

        public void removeBuff(Buff buff)
        {
            buffs.Remove(buff);
        }
    }
}