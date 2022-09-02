using NBGame.Player;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NBGame.Player
{
    public class teamScripts : MonoBehaviour
    {
        [SerializeField] TeamController TeamControllerScript;

        private void Awake()
        {
            TeamControllerScript.TeamCharacterChanged += changeTeamCharacter;
            TeamControllerScript.CharacterChanged += changeCharacter;
        }
        #region changeCharacter
        private void changeTeamCharacter()
        {
            //throw new NotImplementedException();
        }

        public delegate void Event(Transform transform);
        public event Event CharacterOnSceneChanged;
        private void changeCharacter(int index)
        {
            CharacterOnSceneChanged?.Invoke(TeamControllerScript.characters[index].GetComponent<characterScripts>().position.transform);

        }

        #endregion

        #region buff
        List<TeamBuff> buffs = new List<TeamBuff>();
        public void addBuff(TeamBuff buff)
        {
            // if there already have buff with same type, overlay, else add it to list and initiate
            for (int i = 0; i < buffs.Count; i++)
            {
                TeamBuff b = buffs[i];
                if (b.GetType() == buff.GetType())
                {
                    TeamBuff overlayedbuff = buffs[i];
                    buffs[i] = buff;
                    buff.overlying(b, this);
                    overlayedbuff.overlayed();
                    return;
                }
            }
            buffs.Add(buff);
            buff.initiate(this);
        }

        

        public void removeBuff(TeamBuff buff)
        {
            buffs.Remove(buff);
        }

        #endregion

        #region ObjectFollowingCharacter
        public void addObject(GameObject TargetObject)
        {
            FollowChara s = (TargetObject.AddComponent<FollowChara>());
            s.controllerScript = this;
            s.changeTarget(TeamControllerScript.characters[TeamControllerScript.currentCharacter].GetComponent<characterScripts>().position.transform);

        }
        public class FollowChara : MonoBehaviour
        {
            //is the object stick to the object or move smoothly 
            bool followRigidly;//not done yet
            Vector3 offset;//not done yet
            public teamScripts controllerScript;
            private void Start()
            { 
                controllerScript.CharacterOnSceneChanged += changeTarget;
                transform.localPosition = Vector3.zero;
            }

            private void OnDestroy()
            {
                controllerScript.CharacterOnSceneChanged -= changeTarget;
                Destroy(this);
            }
            public void changeTarget(Transform tatget)
            {
                gameObject.transform.parent = tatget;
            }


        }
        #endregion

        #region Teamshield
        public delegate void shieldEvent(int ID);
        public event shieldEvent TeamShieldBreak;

        public void BreakShield(int id)
        {
            TeamShieldBreak?.Invoke(id);
        }
        public List<HpAndID> TeamshieldsHp = new List<HpAndID>();
        public int shieldID = 0;
        public int addShield(int shieldAmount)
        {
            shieldID++;
            TeamshieldsHp.Add(new HpAndID(shieldID, shieldAmount));
            return shieldID;
        }

        public void RemoveShield(int id)
        {
            TeamshieldsHp.Remove(FindShield(id));
        }

        public HpAndID FindShield(int id)
        {
            for (int i = 0; i < TeamshieldsHp.Count; i++)
            {
                if (TeamshieldsHp[i].id == id)
                {
                    return TeamshieldsHp[i];
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

    }
}

